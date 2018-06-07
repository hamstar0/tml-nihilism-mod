namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void SetItemFilter( bool on ) {
			this.Data.IsItemFilterOn = on;
		}

		public void SetItemWhitelistEntry( string item_name ) {
			this.Data.ItemWhitelist[item_name] = true;
		}


		public void SetRecipeFilter( bool on ) {
			this.Data.IsRecipeFilterOn = on;
		}

		public void SetRecipeWhitelistEntry( string item_name ) {
			this.Data.RecipeWhitelist[item_name] = true;
		}


		public void SetNpcLootFilter( bool on ) {
			this.Data.IsNpcLootFilterOn = on;
		}

		public void SetNpcLootWhitelistEntry( string npc_name ) {
			this.Data.NpcLootWhitelist[npc_name] = true;
		}


		public void SetNpcFilter( bool on ) {
			this.Data.IsNpcFilterOn = on;
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
