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

		////

		public void SetItemBlacklist2Entry( string itemName ) {
			this.Data.ItemBlacklist2.Add( itemName );
		}

		public void SetNpcLootBlacklist2Entry( string itemName ) {
			this.Data.RecipeBlacklist2.Add( itemName );
		}

		public void SetNpcBlacklist2Entry( string npcName ) {
			this.Data.NpcLootBlacklist2.Add( npcName );
		}

		public void SetRecipeBlacklist2Entry( string npcName ) {
			this.Data.NpcBlacklist2.Add( npcName );
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
