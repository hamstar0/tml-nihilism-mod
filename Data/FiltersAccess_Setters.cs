namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void SetItemFilter( bool on ) {
			this.Data.IsItemFilterOn = on;
		}

		public void SetRecipeFilter( bool on ) {
			this.Data.IsRecipeFilterOn = on;
		}

		public void SetNpcLootFilter( bool on ) {
			this.Data.IsNpcLootFilterOn = on;
		}

		public void SetNpcFilter( bool on ) {
			this.Data.IsNpcFilterOn = on;
		}


		public void SetItemWhitelistEntry( string item_name ) {
			this.Data.ItemWhitelist.Add( item_name );
		}
		
		public void SetRecipeWhitelistEntry( string item_name ) {
			this.Data.RecipeWhitelist.Add( item_name );
		}

		public void SetNpcLootWhitelistEntry( string npc_name ) {
			this.Data.NpcLootWhitelist.Add( npc_name );
		}

		public void SetNpcWhitelistEntry( string npc_name ) {
			this.Data.NpcWhitelist.Add( npc_name );
		}


		////////////////

		public void ClearItemWhitelist() {
			this.Data.ItemWhitelist.Clear();
		}

		public void ClearRecipeWhitelist() {
			this.Data.RecipeWhitelist.Clear();
		}

		public void ClearNpcLootWhitelist() {
			this.Data.NpcLootWhitelist.Clear();
		}

		public void ClearNpcWhitelist() {
			this.Data.NpcWhitelist.Clear();
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
