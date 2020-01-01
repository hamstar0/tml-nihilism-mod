using System;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		public void SetItemBlacklistGroupEntry( string groupName ) {
			this.Filters.ItemGroupBlacklist.Add( groupName );
		}

		public void SetRecipeBlacklistGroupEntry( string groupName ) {
			this.Filters.RecipeGroupBlacklist.Add( groupName );
		}

		public void SetNpcBlacklistGroupEntry( string groupName ) {
			this.Filters.NpcGroupBlacklist.Add( groupName );
		}

		public void SetNpcLootBlacklistGroupEntry( string groupName ) {
			this.Filters.NpcLootGroupBlacklist.Add( groupName );
		}

		////

		public void SetItemWhitelistGroupEntry( string groupName ) {
			this.Filters.ItemGroupWhitelist.Add( groupName );
		}
		
		public void SetRecipeWhitelistGroupEntry( string groupName ) {
			this.Filters.RecipeGroupWhitelist.Add( groupName );
		}

		public void SetNpcWhitelistGroupEntry( string groupName ) {
			this.Filters.NpcGroupWhitelist.Add( groupName );
		}

		public void SetNpcLootWhitelistGroupEntry( string groupName ) {
			this.Filters.NpcLootGroupWhitelist.Add( groupName );
		}

		////

		public void SetItemBlacklist2GroupEntry( string groupName ) {
			this.Filters.ItemGroupBlacklist2.Add( groupName );
		}

		public void SetRecipeBlacklist2GroupEntry( string groupName ) {
			this.Filters.RecipeGroupBlacklist2.Add( groupName );
		}

		public void SetNpcBlacklist2GroupEntry( string groupName ) {
			this.Filters.NpcGroupBlacklist2.Add( groupName );
		}

		public void SetNpcLootBlacklist2GroupEntry( string groupName ) {
			this.Filters.NpcLootGroupBlacklist2.Add( groupName );
		}
	}
}
