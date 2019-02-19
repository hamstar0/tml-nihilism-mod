namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void SetItemBlacklistEntry( string itemName ) {
			this.Data.ItemBlacklist.Add( itemName );
		}

		public void SetRecipeBlacklistEntry( string itemName ) {
			this.Data.RecipeBlacklist.Add( itemName );
		}

		public void SetNpcLootBlacklistEntry( string npcName ) {
			this.Data.NpcLootBlacklist.Add( npcName );
		}

		public void SetNpcBlacklistEntry( string npcName ) {
			this.Data.NpcBlacklist.Add( npcName );
		}

		////

		public void SetItemWhitelistEntry( string itemName ) {
			this.Data.ItemWhitelist.Add( itemName );
		}
		
		public void SetRecipeWhitelistEntry( string itemName ) {
			this.Data.RecipeWhitelist.Add( itemName );
		}

		public void SetNpcLootWhitelistEntry( string npcName ) {
			this.Data.NpcLootWhitelist.Add( npcName );
		}

		public void SetNpcWhitelistEntry( string npcName ) {
			this.Data.NpcWhitelist.Add( npcName );
		}


		////////////////

		public void UnsetItemBlacklistEntry( string itemName ) {
			this.Data.ItemBlacklist.Remove( itemName );
		}

		public void UnsetRecipeBlacklistEntry( string itemName ) {
			this.Data.RecipeBlacklist.Remove( itemName );
		}

		public void UnsetNpcLootBlacklistEntry( string npcName ) {
			this.Data.NpcLootBlacklist.Remove( npcName );
		}

		public void UnsetNpcBlacklistEntry( string npcName ) {
			this.Data.NpcBlacklist.Remove( npcName );
		}

		////

		public void UnsetItemWhitelistEntry( string itemName ) {
			this.Data.ItemWhitelist.Remove( itemName );
		}

		public void UnsetRecipeWhitelistEntry( string itemName ) {
			this.Data.RecipeWhitelist.Remove( itemName );
		}

		public void UnsetNpcLootWhitelistEntry( string npcName ) {
			this.Data.NpcLootWhitelist.Remove( npcName );
		}

		public void UnsetNpcWhitelistEntry( string npcName ) {
			this.Data.NpcWhitelist.Remove( npcName );
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

		public void SetCurrentFiltersAsDefaults() {
			this.Data.SetCurrentFiltersAsDefaults();
		}

		public void ResetFiltersFromDefaults() {
			this.Data.ResetFiltersFromDefaults();
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
