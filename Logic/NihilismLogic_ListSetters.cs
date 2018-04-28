using HamstarHelpers.Utilities.Network;
using Nihilism.Data;
using Nihilism.NetProtocol;
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
	}
}
