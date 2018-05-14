﻿using HamstarHelpers.Utilities.Network;
using Nihilism.Data;
using Nihilism.NetProtocol;
using System.Linq;
using Terraria;


namespace Nihilism.Logic {
	partial class NihilismLogic {
		public void SyncData() {
			var mymod = NihilismMod.Instance;

			if( Main.netMode == 1 ) {
				PacketProtocol.QuickSyncToServerAndClients<WorldFiltersProtocol>();
			} else if( Main.netMode == 2 ) {
				if( !mymod.SuppressAutoSaving ) {
					this.SaveWorldData( NihilismMod.Instance );
				}
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
		}

		public void SetItemWhitelistEntry( string item_name ) {
			this.Data.ItemWhitelist[ item_name ] = true;
		}


		public void SetRecipesBlacklistPattern( string pattern ) {
			this.Data.RecipesBlacklistPattern = pattern;
			NihilismLogic._ItemsBlacklistPattern = null;
		}

		public void SetRecipeWhitelistEntry( string item_name ) {
			this.Data.RecipeWhitelist[item_name] = true;
		}


		public void SetNpcLootBlacklistPattern( string pattern ) {
			this.Data.NpcLootBlacklistPattern = pattern;
			NihilismLogic._NpcLootBlacklistPattern = null;
		}

		public void SetNpcLootWhitelistEntry( string npc_name ) {
			this.Data.NpcLootWhitelist[npc_name] = true;
		}


		public void SetNpcBlacklistPattern( string pattern ) {
			this.Data.NpcBlacklistPattern = pattern;
			NihilismLogic._NpcsBlacklistPattern = null;
		}

		public void SetNpcWhitelistEntry( string npc_name ) {
			this.Data.NpcWhitelist[npc_name] = true;
		}


		////////////////

		public void SetCurrentFiltersAsDefaults( NihilismMod mymod ) {
			mymod.Config.DefaultItemsBlacklistPattern = this.Data.ItemsBlacklistPattern;
			mymod.Config.DefaultRecipesBlacklistPattern = this.Data.RecipesBlacklistPattern;
			mymod.Config.DefaultNpcLootBlacklistPattern = this.Data.NpcLootBlacklistPattern;
			mymod.Config.DefaultNpcBlacklistPattern = this.Data.NpcBlacklistPattern;

			mymod.Config.DefaultRecipeWhitelist = this.Data.RecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultItemWhitelist = this.Data.ItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultNpcWhitelist = this.Data.NpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultNpcLootWhitelist = this.Data.NpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );

			this.SaveWorldData( mymod );
		}

		public void ResetFiltersFromDefaults( NihilismMod mymod ) {
			this.Data.ItemsBlacklistPattern = mymod.Config.DefaultItemsBlacklistPattern;
			this.Data.RecipesBlacklistPattern = mymod.Config.DefaultRecipesBlacklistPattern;
			this.Data.NpcLootBlacklistPattern = mymod.Config.DefaultNpcLootBlacklistPattern;
			this.Data.NpcBlacklistPattern = mymod.Config.DefaultNpcBlacklistPattern;

			this.Data.RecipeWhitelist = mymod.Config.DefaultRecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.Data.ItemWhitelist = mymod.Config.DefaultItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.Data.NpcWhitelist = mymod.Config.DefaultNpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.Data.NpcLootWhitelist = mymod.Config.DefaultNpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
		}
	}
}