using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void UnsetItemBlacklistEntry( ItemDefinition itemDef ) {
			this.FilterConfig.ItemBlacklist.Remove( itemDef );
		}

		public void UnsetRecipeBlacklistEntry( ItemDefinition itemDef ) {
			this.FilterConfig.RecipeBlacklist.Remove( itemDef );
		}

		public void UnsetNpcBlacklistEntry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcBlacklist.Remove( npcDef );
		}

		public void UnsetNpcLootBlacklistEntry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcLootBlacklist.Remove( npcDef );
		}

		////

		public void UnsetItemWhitelistEntry( ItemDefinition itemDef ) {
			this.FilterConfig.ItemWhitelist.Remove( itemDef );
		}

		public void UnsetRecipeWhitelistEntry( ItemDefinition itemDef ) {
			this.FilterConfig.RecipeWhitelist.Remove( itemDef );
		}

		public void UnsetNpcWhitelistEntry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcWhitelist.Remove( npcDef );
		}

		public void UnsetNpcLootWhitelistEntry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcLootWhitelist.Remove( npcDef );
		}

		////

		public void UnsetItemBlacklist2Entry( ItemDefinition itemDef ) {
			this.FilterConfig.ItemBlacklist2.Remove( itemDef );
		}

		public void UnsetRecipeBlacklist2Entry( ItemDefinition itemDef ) {
			this.FilterConfig.RecipeBlacklist2.Remove( itemDef );
		}

		public void UnsetNpcBlacklist2Entry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcBlacklist2.Remove( npcDef );
		}

		public void UnsetNpcLootBlacklist2Entry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcLootBlacklist2.Remove( npcDef );
		}
	}
}
