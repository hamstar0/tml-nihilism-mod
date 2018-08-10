namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void SetItemBlacklistEntry( string item_name ) {
			this.Data.ItemBlacklist.Add( item_name );
		}

		public void SetRecipeBlacklistEntry( string item_name ) {
			this.Data.RecipeBlacklist.Add( item_name );
		}

		public void SetNpcLootBlacklistEntry( string npc_name ) {
			this.Data.NpcLootBlacklist.Add( npc_name );
		}

		public void SetNpcBlacklistEntry( string npc_name ) {
			this.Data.NpcBlacklist.Add( npc_name );
		}

		////

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

		public void UnsetItemBlacklistEntry( string item_name ) {
			this.Data.ItemBlacklist.Remove( item_name );
		}

		public void UnsetRecipeBlacklistEntry( string item_name ) {
			this.Data.RecipeBlacklist.Remove( item_name );
		}

		public void UnsetNpcLootBlacklistEntry( string npc_name ) {
			this.Data.NpcLootBlacklist.Remove( npc_name );
		}

		public void UnsetNpcBlacklistEntry( string npc_name ) {
			this.Data.NpcBlacklist.Remove( npc_name );
		}

		////

		public void UnsetItemWhitelistEntry( string item_name ) {
			this.Data.ItemWhitelist.Remove( item_name );
		}

		public void UnsetRecipeWhitelistEntry( string item_name ) {
			this.Data.RecipeWhitelist.Remove( item_name );
		}

		public void UnsetNpcLootWhitelistEntry( string npc_name ) {
			this.Data.NpcLootWhitelist.Remove( npc_name );
		}

		public void UnsetNpcWhitelistEntry( string npc_name ) {
			this.Data.NpcWhitelist.Remove( npc_name );
		}


		////////////////

		public void ClearItemBlacklist() {
			this.Data.ItemBlacklist.Clear();
		}

		public void ClearRecipeBlacklist() {
			this.Data.RecipeBlacklist.Clear();
		}

		public void ClearNpcLootBlacklist() {
			this.Data.NpcLootBlacklist.Clear();
		}

		public void ClearNpcBlacklist() {
			this.Data.NpcBlacklist.Clear();
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
