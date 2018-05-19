using HamstarHelpers.Utilities.Config;
using System.Linq;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void SetItemsBlacklistPattern( string pattern ) {
			this.ItemsBlacklistPattern = pattern;
			this._ItemsBlacklistPattern = null;
		}

		public void SetItemWhitelistEntry( string item_name ) {
			this.ItemWhitelist[item_name] = true;
		}


		public void SetRecipesBlacklistPattern( string pattern ) {
			this.RecipesBlacklistPattern = pattern;
			this._ItemsBlacklistPattern = null;
		}

		public void SetRecipeWhitelistEntry( string item_name ) {
			this.RecipeWhitelist[item_name] = true;
		}


		public void SetNpcLootBlacklistPattern( string pattern ) {
			this.NpcLootBlacklistPattern = pattern;
			this._NpcLootBlacklistPattern = null;
		}

		public void SetNpcLootWhitelistEntry( string npc_name ) {
			this.NpcLootWhitelist[npc_name] = true;
		}


		public void SetNpcBlacklistPattern( string pattern ) {
			this.NpcBlacklistPattern = pattern;
			this._NpcsBlacklistPattern = null;
		}

		public void SetNpcWhitelistEntry( string npc_name ) {
			this.NpcWhitelist[npc_name] = true;
		}


		////////////////

		public void SetCurrentFiltersAsDefaults( NihilismMod mymod ) {
			mymod.Config.DefaultItemsBlacklistPattern = this.ItemsBlacklistPattern;
			mymod.Config.DefaultRecipesBlacklistPattern = this.RecipesBlacklistPattern;
			mymod.Config.DefaultNpcLootBlacklistPattern = this.NpcLootBlacklistPattern;
			mymod.Config.DefaultNpcBlacklistPattern = this.NpcBlacklistPattern;

			mymod.Config.DefaultRecipeWhitelist = this.RecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultItemWhitelist = this.ItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultNpcWhitelist = this.NpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultNpcLootWhitelist = this.NpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );

			if( !mymod.SuppressAutoSaving ) {
				mymod.JsonConfig.SaveFile();
			}
		}

		public void ResetFiltersFromDefaults( NihilismMod mymod ) {
			this.ItemsBlacklistPattern = mymod.Config.DefaultItemsBlacklistPattern;
			this.RecipesBlacklistPattern = mymod.Config.DefaultRecipesBlacklistPattern;
			this.NpcLootBlacklistPattern = mymod.Config.DefaultNpcLootBlacklistPattern;
			this.NpcBlacklistPattern = mymod.Config.DefaultNpcBlacklistPattern;

			this.RecipeWhitelist = mymod.Config.DefaultRecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.ItemWhitelist = mymod.Config.DefaultItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.NpcWhitelist = mymod.Config.DefaultNpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.NpcLootWhitelist = mymod.Config.DefaultNpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
		}
	}
}
