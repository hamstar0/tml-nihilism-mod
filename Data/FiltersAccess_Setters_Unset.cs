namespace Nihilism.Data {
	partial class NihilismFilterAccess {
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

		////

		public void UnsetItemBlacklist2Entry( string itemName ) {
			this.Data.ItemBlacklist2.Remove( itemName );
		}

		public void UnsetRecipeBlacklist2Entry( string itemName ) {
			this.Data.RecipeBlacklist2.Remove( itemName );
		}

		public void UnsetNpcLootBlacklist2Entry( string npcName ) {
			this.Data.NpcLootBlacklist2.Remove( npcName );
		}

		public void UnsetNpcBlacklist2Entry( string npcName ) {
			this.Data.NpcBlacklist2.Remove( npcName );
		}
	}
}
