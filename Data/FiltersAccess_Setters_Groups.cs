using System;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void SetItemGroupBlacklistEntry( string groupName ) {
			this.FilterConfig.ItemGroupBlacklist.Add( groupName );
		}

		public void SetRecipeGroupBlacklistEntry( string groupName ) {
			this.FilterConfig.RecipeGroupBlacklist.Add( groupName );
		}

		public void SetNpcGroupBlacklistEntry( string groupName ) {
			this.FilterConfig.NpcGroupBlacklist.Add( groupName );
		}

		public void SetNpcLootGroupBlacklistEntry( string groupName ) {
			this.FilterConfig.NpcLootGroupBlacklist.Add( groupName );
		}

		////

		public void SetItemGroupWhitelistEntry( string groupName ) {
			this.FilterConfig.ItemGroupWhitelist.Add( groupName );
		}
		
		public void SetRecipeGroupWhitelistEntry( string groupName ) {
			this.FilterConfig.RecipeGroupWhitelist.Add( groupName );
		}

		public void SetNpcGroupWhitelistEntry( string groupName ) {
			this.FilterConfig.NpcGroupWhitelist.Add( groupName );
		}

		public void SetNpcLootGroupWhitelistEntry( string groupName ) {
			this.FilterConfig.NpcLootGroupWhitelist.Add( groupName );
		}

		////

		public void SetItemGroupBlacklist2Entry( string groupName ) {
			this.FilterConfig.ItemGroupBlacklist2.Add( groupName );
		}

		public void SetRecipeGroupBlacklist2Entry( string groupName ) {
			this.FilterConfig.RecipeGroupBlacklist2.Add( groupName );
		}

		public void SetNpcGroupBlacklist2Entry( string groupName ) {
			this.FilterConfig.NpcGroupBlacklist2.Add( groupName );
		}

		public void SetNpcLootGroupBlacklist2Entry( string groupName ) {
			this.FilterConfig.NpcLootGroupBlacklist2.Add( groupName );
		}
	}
}
