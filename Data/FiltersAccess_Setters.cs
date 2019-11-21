using System;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		public void SetItemBlacklistEntry( ItemDefinition itemDef ) {
			this.FilterConfig.ItemBlacklist.Add( itemDef );
		}

		public void SetRecipeBlacklistEntry( ItemDefinition itemDef ) {
			this.FilterConfig.RecipeBlacklist.Add( itemDef );
		}

		public void SetNpcBlacklistEntry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcBlacklist.Add( npcDef );
		}

		public void SetNpcLootBlacklistEntry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcLootBlacklist.Add( npcDef );
		}

		////

		public void SetItemWhitelistEntry( ItemDefinition itemDef ) {
			this.FilterConfig.ItemWhitelist.Add( itemDef );
		}
		
		public void SetRecipeWhitelistEntry( ItemDefinition itemDef ) {
			this.FilterConfig.RecipeWhitelist.Add( itemDef );
		}

		public void SetNpcWhitelistEntry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcWhitelist.Add( npcDef );
		}

		public void SetNpcLootWhitelistEntry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcLootWhitelist.Add( npcDef );
		}

		////

		public void SetItemBlacklist2Entry( ItemDefinition itemDef ) {
			this.FilterConfig.ItemBlacklist2.Add( itemDef );
		}

		public void SetRecipeBlacklist2Entry( ItemDefinition itemDef ) {
			this.FilterConfig.RecipeBlacklist2.Add( itemDef );
		}

		public void SetNpcBlacklist2Entry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcBlacklist2.Add( npcDef );
		}

		public void SetNpcLootBlacklist2Entry( NPCDefinition npcDef ) {
			this.FilterConfig.NpcLootBlacklist2.Add( npcDef );
		}
	}
}
