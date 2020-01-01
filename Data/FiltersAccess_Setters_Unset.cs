using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		public void UnsetItemBlacklistEntry( ItemDefinition itemDef ) {
			this.Filters.ItemBlacklist.Remove( itemDef );
		}

		public void UnsetRecipeBlacklistEntry( ItemDefinition itemDef ) {
			this.Filters.RecipeBlacklist.Remove( itemDef );
		}

		public void UnsetNpcBlacklistEntry( NPCDefinition npcDef ) {
			this.Filters.NpcBlacklist.Remove( npcDef );
		}

		public void UnsetNpcLootBlacklistEntry( NPCDefinition npcDef ) {
			this.Filters.NpcLootBlacklist.Remove( npcDef );
		}

		////

		public void UnsetItemWhitelistEntry( ItemDefinition itemDef ) {
			this.Filters.ItemWhitelist.Remove( itemDef );
		}

		public void UnsetRecipeWhitelistEntry( ItemDefinition itemDef ) {
			this.Filters.RecipeWhitelist.Remove( itemDef );
		}

		public void UnsetNpcWhitelistEntry( NPCDefinition npcDef ) {
			this.Filters.NpcWhitelist.Remove( npcDef );
		}

		public void UnsetNpcLootWhitelistEntry( NPCDefinition npcDef ) {
			this.Filters.NpcLootWhitelist.Remove( npcDef );
		}

		////

		public void UnsetItemBlacklist2Entry( ItemDefinition itemDef ) {
			this.Filters.ItemBlacklist2.Remove( itemDef );
		}

		public void UnsetRecipeBlacklist2Entry( ItemDefinition itemDef ) {
			this.Filters.RecipeBlacklist2.Remove( itemDef );
		}

		public void UnsetNpcBlacklist2Entry( NPCDefinition npcDef ) {
			this.Filters.NpcBlacklist2.Remove( npcDef );
		}

		public void UnsetNpcLootBlacklist2Entry( NPCDefinition npcDef ) {
			this.Filters.NpcLootBlacklist2.Remove( npcDef );
		}
	}
}
