using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void UnsetItemBlacklistEntry( string itemKey ) {
			this.FilterConfig.UnsetItemBlacklistEntry( itemKey );
		}

		public void UnsetRecipeBlacklistEntry( string itemKey ) {
			this.FilterConfig.UnsetRecipeBlacklistEntry( itemKey );
		}

		public void UnsetNpcLootBlacklistEntry( string npcKey ) {
			this.FilterConfig.UnsetNpcLootBlacklistEntry( npcKey );
		}

		public void UnsetNpcBlacklistEntry( string npcKey ) {
			this.FilterConfig.UnsetNpcBlacklistEntry( npcKey );
		}

		////

		public void UnsetItemWhitelistEntry( string itemKey ) {
			this.FilterConfig.UnsetItemWhitelistEntry( itemKey );
		}

		public void UnsetRecipeWhitelistEntry( string itemKey ) {
			this.FilterConfig.UnsetRecipeWhitelistEntry( itemKey );
		}

		public void UnsetNpcLootWhitelistEntry( string npcKey ) {
			this.FilterConfig.UnsetNpcLootWhitelistEntry( npcKey );
		}

		public void UnsetNpcWhitelistEntry( string npcKey ) {
			this.FilterConfig.UnsetNpcWhitelistEntry( npcKey );
		}

		////

		public void UnsetItemBlacklist2Entry( string itemKey ) {
			this.FilterConfig.UnsetItemBlacklist2Entry( itemKey );
		}

		public void UnsetRecipeBlacklist2Entry( string itemKey ) {
			this.FilterConfig.UnsetRecipeBlacklist2Entry( itemKey );
		}

		public void UnsetNpcLootBlacklist2Entry( string npcKey ) {
			this.FilterConfig.UnsetNpcLootBlacklist2Entry( npcKey );
		}

		public void UnsetNpcBlacklist2Entry( string npcKey ) {
			this.FilterConfig.UnsetNpcBlacklist2Entry( npcKey );
		}
	}
}
