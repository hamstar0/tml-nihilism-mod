namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void SetItemBlacklistEntry( string itemName ) {
			this.FilterConfig.ItemBlacklist.Add( itemName );
		}

		public void SetRecipeBlacklistEntry( string itemName ) {
			this.FilterConfig.RecipeBlacklist.Add( itemName );
		}

		public void SetNpcLootBlacklistEntry( string npcName ) {
			this.FilterConfig.NpcLootBlacklist.Add( npcName );
		}

		public void SetNpcBlacklistEntry( string npcName ) {
			this.FilterConfig.NpcBlacklist.Add( npcName );
		}

		////

		public void SetItemWhitelistEntry( string itemName ) {
			this.FilterConfig.ItemWhitelist.Add( itemName );
		}
		
		public void SetRecipeWhitelistEntry( string itemName ) {
			this.FilterConfig.RecipeWhitelist.Add( itemName );
		}

		public void SetNpcLootWhitelistEntry( string npcName ) {
			this.FilterConfig.NpcLootWhitelist.Add( npcName );
		}

		public void SetNpcWhitelistEntry( string npcName ) {
			this.FilterConfig.NpcWhitelist.Add( npcName );
		}

		////

		public void SetItemBlacklist2Entry( string itemName ) {
			this.FilterConfig.ItemBlacklist2.Add( itemName );
		}

		public void SetNpcLootBlacklist2Entry( string itemName ) {
			this.FilterConfig.RecipeBlacklist2.Add( itemName );
		}

		public void SetNpcBlacklist2Entry( string npcName ) {
			this.FilterConfig.NpcLootBlacklist2.Add( npcName );
		}

		public void SetRecipeBlacklist2Entry( string npcName ) {
			this.FilterConfig.NpcBlacklist2.Add( npcName );
		}


		////////////////

		public void SetCurrentFiltersAsDefaults() {
			this.FilterConfig.SetCurrentFiltersAsDefaults();
		}

		public void ResetFiltersFromDefaults() {
			this.FilterConfig.ResetFiltersFromDefaults();
		}


		////////////////

		public bool IsActive() {
			return this.FilterConfig.IsActive;
		}

		public void Activate() {
			this.FilterConfig.IsActive = true;
		}

		public void Deactivate() {
			this.FilterConfig.IsActive = false;
		}
	}
}
