using HamstarHelpers.Utilities.Config;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void SetItemsBlacklistPattern( string pattern ) {
			this.Data.ItemsBlacklistPattern = pattern;
		}

		public void SetItemWhitelistEntry( string item_name ) {
			this.Data.ItemWhitelist[item_name] = true;
		}


		public void SetRecipesBlacklistPattern( string pattern ) {
			this.Data.RecipesBlacklistPattern = pattern;
		}

		public void SetRecipeWhitelistEntry( string item_name ) {
			this.Data.RecipeWhitelist[item_name] = true;
		}


		public void SetNpcLootBlacklistPattern( string pattern ) {
			this.Data.NpcLootBlacklistPattern = pattern;
		}

		public void SetNpcLootWhitelistEntry( string npc_name ) {
			this.Data.NpcLootWhitelist[npc_name] = true;
		}


		public void SetNpcBlacklistPattern( string pattern ) {
			this.Data.NpcBlacklistPattern = pattern;
		}

		public void SetNpcWhitelistEntry( string npc_name ) {
			this.Data.NpcWhitelist[npc_name] = true;
		}


		////////////////

		public void SetCurrentFiltersAsDefaults( NihilismMod mymod ) {
			this.Data.SetCurrentFiltersAsDefaults( mymod );
		}

		public void ResetFiltersFromDefaults( NihilismMod mymod ) {
			this.Data.ResetFiltersFromDefaults( mymod );
		}


		////////////////

		public bool IsActive() {
			return this.Data.IsActive;
		}

		public void Activate() {
			this.Data.IsActive = true;
		}

		public void Deactivate() {
			this.Data.IsActive = false;
		}
	}
}
