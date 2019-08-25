using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void UnsetItemGroupBlacklistEntry( string groupName ) {
			this.FilterConfig.ItemGroupBlacklist.Remove( groupName );
		}

		public void UnsetRecipeGroupBlacklistEntry( string groupName ) {
			this.FilterConfig.RecipeGroupBlacklist.Remove( groupName );
		}

		public void UnsetNpcGroupBlacklistEntry( string groupName ) {
			this.FilterConfig.NpcGroupBlacklist.Remove( groupName );
		}

		public void UnsetNpcLootGroupBlacklistEntry( string groupName ) {
			this.FilterConfig.NpcLootGroupBlacklist.Remove( groupName );
		}

		////

		public void UnsetItemGroupWhitelistEntry( string groupName ) {
			this.FilterConfig.ItemGroupWhitelist.Remove( groupName );
		}

		public void UnsetRecipeGroupWhitelistEntry( string groupName ) {
			this.FilterConfig.RecipeGroupWhitelist.Remove( groupName );
		}

		public void UnsetNpcGroupWhitelistEntry( string groupName ) {
			this.FilterConfig.NpcGroupWhitelist.Remove( groupName );
		}

		public void UnsetNpcLootGroupWhitelistEntry( string groupName ) {
			this.FilterConfig.NpcLootGroupWhitelist.Remove( groupName );
		}

		////

		public void UnsetItemGroupBlacklist2Entry( string groupName ) {
			this.FilterConfig.ItemGroupBlacklist2.Remove( groupName );
		}

		public void UnsetRecipeGroupBlacklist2Entry( string groupName ) {
			this.FilterConfig.RecipeGroupBlacklist2.Remove( groupName );
		}

		public void UnsetNpcGroupBlacklist2Entry( string groupName ) {
			this.FilterConfig.NpcGroupBlacklist2.Remove( groupName );
		}

		public void UnsetNpcLootGroupBlacklist2Entry( string groupName ) {
			this.FilterConfig.NpcLootGroupBlacklist2.Remove( groupName );
		}
	}
}
