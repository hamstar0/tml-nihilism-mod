namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void UnsetItemBlacklistEntry( string itemName ) {
			this.FilterConfig.ItemBlacklist.Remove( itemName );
		}

		public void UnsetRecipeBlacklistEntry( string itemName ) {
			this.FilterConfig.RecipeBlacklist.Remove( itemName );
		}

		public void UnsetNpcLootBlacklistEntry( string npcName ) {
			this.FilterConfig.NpcLootBlacklist.Remove( npcName );
		}

		public void UnsetNpcBlacklistEntry( string npcName ) {
			this.FilterConfig.NpcBlacklist.Remove( npcName );
		}

		////

		public void UnsetItemWhitelistEntry( string itemName ) {
			this.FilterConfig.ItemWhitelist.Remove( itemName );
		}

		public void UnsetRecipeWhitelistEntry( string itemName ) {
			this.FilterConfig.RecipeWhitelist.Remove( itemName );
		}

		public void UnsetNpcLootWhitelistEntry( string npcName ) {
			this.FilterConfig.NpcLootWhitelist.Remove( npcName );
		}

		public void UnsetNpcWhitelistEntry( string npcName ) {
			this.FilterConfig.NpcWhitelist.Remove( npcName );
		}

		////

		public void UnsetItemBlacklist2Entry( string itemName ) {
			this.FilterConfig.ItemBlacklist2.Remove( itemName );
		}

		public void UnsetRecipeBlacklist2Entry( string itemName ) {
			this.FilterConfig.RecipeBlacklist2.Remove( itemName );
		}

		public void UnsetNpcLootBlacklist2Entry( string npcName ) {
			this.FilterConfig.NpcLootBlacklist2.Remove( npcName );
		}

		public void UnsetNpcBlacklist2Entry( string npcName ) {
			this.FilterConfig.NpcBlacklist2.Remove( npcName );
		}
	}
}
