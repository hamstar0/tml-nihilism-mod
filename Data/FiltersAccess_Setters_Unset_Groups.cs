using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		public void UnsetItemBlacklistGroupEntry( string groupName ) {
			this.Filters.ItemGroupBlacklist.Remove( groupName );
		}

		public void UnsetRecipeBlacklistGroupEntry( string groupName ) {
			this.Filters.RecipeGroupBlacklist.Remove( groupName );
		}

		public void UnsetNpcBlacklistGroupEntry( string groupName ) {
			this.Filters.NpcGroupBlacklist.Remove( groupName );
		}

		public void UnsetNpcLootBlacklistGroupEntry( string groupName ) {
			this.Filters.NpcLootGroupBlacklist.Remove( groupName );
		}

		////

		public void UnsetItemWhitelistGroupEntry( string groupName ) {
			this.Filters.ItemGroupWhitelist.Remove( groupName );
		}

		public void UnsetRecipeWhitelistGroupEntry( string groupName ) {
			this.Filters.RecipeGroupWhitelist.Remove( groupName );
		}

		public void UnsetNpcWhitelistGroupEntry( string groupName ) {
			this.Filters.NpcGroupWhitelist.Remove( groupName );
		}

		public void UnsetNpcLootWhitelistGroupEntry( string groupName ) {
			this.Filters.NpcLootGroupWhitelist.Remove( groupName );
		}

		////

		public void UnsetItemGroupBlacklist2Entry( string groupName ) {
			this.Filters.ItemGroupBlacklist2.Remove( groupName );
		}

		public void UnsetRecipeGroupBlacklist2Entry( string groupName ) {
			this.Filters.RecipeGroupBlacklist2.Remove( groupName );
		}

		public void UnsetNpcGroupBlacklist2Entry( string groupName ) {
			this.Filters.NpcGroupBlacklist2.Remove( groupName );
		}

		public void UnsetNpcLootGroupBlacklist2Entry( string groupName ) {
			this.Filters.NpcLootGroupBlacklist2.Remove( groupName );
		}
	}
}
