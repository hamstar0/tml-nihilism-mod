using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void UnsetItemBlacklistGroupEntry( string groupName ) {
			this.FilterConfig.ItemGroupBlacklist.Remove( groupName );
		}

		public void UnsetRecipeBlacklistGroupEntry( string groupName ) {
			this.FilterConfig.RecipeGroupBlacklist.Remove( groupName );
		}

		public void UnsetNpcBlacklistGroupEntry( string groupName ) {
			this.FilterConfig.NpcGroupBlacklist.Remove( groupName );
		}

		public void UnsetNpcLootBlacklistGroupEntry( string groupName ) {
			this.FilterConfig.NpcLootGroupBlacklist.Remove( groupName );
		}

		////

		public void UnsetItemWhitelistGroupEntry( string groupName ) {
			this.FilterConfig.ItemGroupWhitelist.Remove( groupName );
		}

		public void UnsetRecipeWhitelistGroupEntry( string groupName ) {
			this.FilterConfig.RecipeGroupWhitelist.Remove( groupName );
		}

		public void UnsetNpcWhitelistGroupEntry( string groupName ) {
			this.FilterConfig.NpcGroupWhitelist.Remove( groupName );
		}

		public void UnsetNpcLootWhitelistGroupEntry( string groupName ) {
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
