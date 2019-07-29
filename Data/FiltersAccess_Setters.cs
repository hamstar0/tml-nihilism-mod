using HamstarHelpers.Helpers.Items;
using HamstarHelpers.Helpers.NPCs;
using System;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public void SetItemBlacklistEntry( int itemType ) {
			Tuple<string, string> segs = ItemIdentityHelpers.GetUniqueKeySegs( itemType );
			this.FilterConfig.ItemBlacklist.Add( new ItemDefinition(segs.Item1, segs.Item2) );
		}

		public void SetRecipeBlacklistEntry( int itemType ) {
			Tuple<string, string> segs = ItemIdentityHelpers.GetUniqueKeySegs( itemType );
			this.FilterConfig.RecipeBlacklist.Add( new ItemDefinition( segs.Item1, segs.Item2 ) );
		}

		public void SetNpcBlacklistEntry( int npcType ) {
			Tuple<string, string> segs = NPCIdentityHelpers.GetUniqueKeySegs( npcType );
			this.FilterConfig.NpcBlacklist.Add( new NPCDefinition( segs.Item1, segs.Item2 ) );
		}

		public void SetNpcLootBlacklistEntry( int npcType ) {
			Tuple<string, string> segs = NPCIdentityHelpers.GetUniqueKeySegs( npcType );
			this.FilterConfig.NpcLootBlacklist.Add( new NPCDefinition( segs.Item1, segs.Item2 ) );
		}

		////

		public void SetItemWhitelistEntry( int itemType ) {
			Tuple<string, string> segs = ItemIdentityHelpers.GetUniqueKeySegs( itemType );
			this.FilterConfig.ItemWhitelist.Add( new ItemDefinition( segs.Item1, segs.Item2 ) );
		}
		
		public void SetRecipeWhitelistEntry( int itemType ) {
			Tuple<string, string> segs = ItemIdentityHelpers.GetUniqueKeySegs( itemType );
			this.FilterConfig.RecipeWhitelist.Add( new ItemDefinition( segs.Item1, segs.Item2 ) );
		}

		public void SetNpcWhitelistEntry( int npcType ) {
			Tuple<string, string> segs = NPCIdentityHelpers.GetUniqueKeySegs( npcType );
			this.FilterConfig.NpcWhitelist.Add( new NPCDefinition( segs.Item1, segs.Item2 ) );
		}

		public void SetNpcLootWhitelistEntry( int npcType ) {
			Tuple<string, string> segs = NPCIdentityHelpers.GetUniqueKeySegs( npcType );
			this.FilterConfig.NpcLootWhitelist.Add( new NPCDefinition( segs.Item1, segs.Item2 ) );
		}

		////

		public void SetItemBlacklist2Entry( int itemType ) {
			Tuple<string, string> segs = ItemIdentityHelpers.GetUniqueKeySegs( itemType );
			this.FilterConfig.ItemBlacklist2.Add( new ItemDefinition( segs.Item1, segs.Item2 ) );
		}

		public void SetRecipeBlacklist2Entry( int itemType ) {
			Tuple<string, string> segs = ItemIdentityHelpers.GetUniqueKeySegs( itemType );
			this.FilterConfig.RecipeBlacklist2.Add( new ItemDefinition( segs.Item1, segs.Item2 ) );
		}

		public void SetNpcBlacklist2Entry( int npcType ) {
			Tuple<string, string> segs = NPCIdentityHelpers.GetUniqueKeySegs( npcType );
			this.FilterConfig.NpcLootBlacklist2.Add( new NPCDefinition( segs.Item1, segs.Item2 ) );
		}

		public void SetNpcLootBlacklist2Entry( int npcType ) {
			Tuple<string, string> segs = NPCIdentityHelpers.GetUniqueKeySegs( npcType );
			this.FilterConfig.RecipeBlacklist2.Add( new NPCDefinition( segs.Item1, segs.Item2 ) );
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
