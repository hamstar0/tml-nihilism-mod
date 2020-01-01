using System;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		public void SetItemBlacklistEntry( ItemDefinition itemDef ) {
			this.Filters.ItemBlacklist.Add( itemDef );
		}

		public void SetRecipeBlacklistEntry( ItemDefinition itemDef ) {
			this.Filters.RecipeBlacklist.Add( itemDef );
		}

		public void SetNpcBlacklistEntry( NPCDefinition npcDef ) {
			this.Filters.NpcBlacklist.Add( npcDef );
		}

		public void SetNpcLootBlacklistEntry( NPCDefinition npcDef ) {
			this.Filters.NpcLootBlacklist.Add( npcDef );
		}

		////

		public void SetItemWhitelistEntry( ItemDefinition itemDef ) {
			this.Filters.ItemWhitelist.Add( itemDef );
		}
		
		public void SetRecipeWhitelistEntry( ItemDefinition itemDef ) {
			this.Filters.RecipeWhitelist.Add( itemDef );
		}

		public void SetNpcWhitelistEntry( NPCDefinition npcDef ) {
			this.Filters.NpcWhitelist.Add( npcDef );
		}

		public void SetNpcLootWhitelistEntry( NPCDefinition npcDef ) {
			this.Filters.NpcLootWhitelist.Add( npcDef );
		}

		////

		public void SetItemBlacklist2Entry( ItemDefinition itemDef ) {
			this.Filters.ItemBlacklist2.Add( itemDef );
		}

		public void SetRecipeBlacklist2Entry( ItemDefinition itemDef ) {
			this.Filters.RecipeBlacklist2.Add( itemDef );
		}

		public void SetNpcBlacklist2Entry( NPCDefinition npcDef ) {
			this.Filters.NpcBlacklist2.Add( npcDef );
		}

		public void SetNpcLootBlacklist2Entry( NPCDefinition npcDef ) {
			this.Filters.NpcLootBlacklist2.Add( npcDef );
		}
	}
}
