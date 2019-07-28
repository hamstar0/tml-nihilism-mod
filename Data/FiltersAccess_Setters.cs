using HamstarHelpers.Helpers.Items;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void SetItemBlacklistEntry( int itemType ) {
			string key = ItemIdentityHelpers.GetUniqueKey( itemType );
			string[] parts = key.Split( new char[] { ' ' }, 2 );
			if( parts.Length != 2 ) {
				return;
			}

			this.FilterConfig.ItemBlacklist.Add( new ItemDefinition(parts[0], parts[1]) );
		}

		public void SetRecipeBlacklistEntry( int itemType ) {
			this.FilterConfig.RecipeBlacklist.Add( itemType );
		}

		public void SetNpcBlacklistEntry( int npcType ) {
			this.FilterConfig.NpcBlacklist.Add( npcType );
		}

		public void SetNpcLootBlacklistEntry( int npcType ) {
			this.FilterConfig.NpcLootBlacklist.Add( npcType );
		}

		////

		public void SetItemWhitelistEntry( int itemType ) {
			this.FilterConfig.ItemWhitelist.Add( itemType );
		}
		
		public void SetRecipeWhitelistEntry( int itemType ) {
			this.FilterConfig.RecipeWhitelist.Add( itemType );
		}

		public void SetNpcWhitelistEntry( int npcType ) {
			this.FilterConfig.NpcWhitelist.Add( npcType );
		}

		public void SetNpcLootWhitelistEntry( int npcType ) {
			this.FilterConfig.NpcLootWhitelist.Add( npcType );
		}

		////

		public void SetItemBlacklist2Entry( int itemType ) {
			string key = ItemIdentityHelpers.GetUniqueKey( itemType );
			string[] parts = key.Split( new char[] { ' ' }, 2 );
			if( parts.Length != 2 ) {
				return;
			}

			this.FilterConfig.ItemBlacklist2.Add( new ItemDefinition( parts[0], parts[1] ) );
		}

		public void SetRecipeBlacklist2Entry( int npcType ) {
			this.FilterConfig.NpcBlacklist2.Add( npcType );
		}

		public void SetNpcBlacklist2Entry( int npcType ) {
			this.FilterConfig.NpcLootBlacklist2.Add( npcType );
		}

		public void SetNpcLootBlacklist2Entry( int itemType ) {
			string key = ItemIdentityHelpers.GetUniqueKey( itemType );
			string[] parts = key.Split( new char[] { ' ' }, 2 );
			if( parts.Length != 2 ) {
				return;
			}

			this.FilterConfig.RecipeBlacklist2.Add( new ItemDefinition( parts[0], parts[1] ) );
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
