using HamstarHelpers.Utilities.Network;
using Nihilism.Data;
using Nihilism.NetProtocol;
using System.Linq;
using Terraria;


namespace Nihilism.Logic {
	partial class NihilismLogic {
		private void SyncData() {
			if( Main.netMode == 1 ) {
				PacketProtocol.QuickSyncToServerAndClients<WorldFiltersProtocol>();
			} else if( Main.netMode == 2 ) {
				this.SaveWorldData( NihilismMod.Instance );
				PacketProtocol.QuickSendToClient<WorldFiltersProtocol>( -1, -1 );
			}
		}


		////////////////

		internal void SetFiltersNoSync( NihilismFilterData filters ) {
			NihilismLogic.ResetCachedPatterns();

			this.Data = filters;
		}


		////////////////

		public void SetItemsBlacklistPattern( string pattern ) {
			this.Data.ItemsBlacklistPattern = pattern;
			NihilismLogic._ItemsBlacklistPattern = null;

			this.SyncData();
		}

		public void SetItemWhitelistEntry( string item_name ) {
			this.Data.ItemWhitelist[ item_name ] = true;

			this.SyncData();
		}


		public void SetRecipesBlacklistPattern( string pattern ) {
			this.Data.RecipesBlacklistPattern = pattern;
			NihilismLogic._ItemsBlacklistPattern = null;

			this.SyncData();
		}

		public void SetRecipeWhitelistEntry( string item_name ) {
			this.Data.RecipeWhitelist[item_name] = true;

			this.SyncData();
		}


		public void SetNpcLootBlacklistPattern( string pattern ) {
			this.Data.NpcLootBlacklistPattern = pattern;
			NihilismLogic._NpcLootBlacklistPattern = null;

			this.SyncData();
		}

		public void SetNpcLootWhitelistEntry( string npc_name ) {
			this.Data.NpcLootWhitelist[npc_name] = true;

			this.SyncData();
		}


		public void SetNpcBlacklistPattern( string pattern ) {
			this.Data.NpcBlacklistPattern = pattern;
			NihilismLogic._NpcsBlacklistPattern = null;

			this.SyncData();
		}

		public void SetNpcWhitelistEntry( string npc_name ) {
			this.Data.NpcWhitelist[npc_name] = true;

			this.SyncData();
		}


		////////////////

		public void SetCurrentFiltersAsDefaults() {
			var mymod = NihilismMod.Instance;
			var world_data = this.Data;

			mymod.Config.DefaultItemsBlacklistPattern = world_data.ItemsBlacklistPattern;
			mymod.Config.DefaultRecipesBlacklistPattern = world_data.RecipesBlacklistPattern;
			mymod.Config.DefaultNpcLootBlacklistPattern = world_data.NpcLootBlacklistPattern;
			mymod.Config.DefaultNpcBlacklistPattern = world_data.NpcBlacklistPattern;

			mymod.Config.DefaultRecipeWhitelist = world_data.RecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultItemWhitelist = world_data.ItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultNpcWhitelist = world_data.NpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultNpcLootWhitelist = world_data.NpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
		}

		public void ResetFiltersFromDefaults() {
			var mymod = NihilismMod.Instance;
			var world_data = this.Data;

			world_data.ItemsBlacklistPattern = mymod.Config.DefaultItemsBlacklistPattern;
			world_data.RecipesBlacklistPattern = mymod.Config.DefaultRecipesBlacklistPattern;
			world_data.NpcLootBlacklistPattern = mymod.Config.DefaultNpcLootBlacklistPattern;
			world_data.NpcBlacklistPattern = mymod.Config.DefaultNpcBlacklistPattern;

			world_data.RecipeWhitelist = mymod.Config.DefaultRecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			world_data.ItemWhitelist = mymod.Config.DefaultItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			world_data.NpcWhitelist = mymod.Config.DefaultNpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			world_data.NpcLootWhitelist = mymod.Config.DefaultNpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
		}
	}
}
