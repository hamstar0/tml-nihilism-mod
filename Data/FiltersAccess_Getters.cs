using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.ItemHelpers;
using HamstarHelpers.Helpers.NPCHelpers;
using HamstarHelpers.Services.EntityGroups;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		internal bool IsItemBlacklisted( Item item, out bool isGroup ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.ItemBlacklist.Contains( name ) ) {
				isGroup = false;
				return true;
			}
			
			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.ItemBlacklist.Contains( grpName ) ) {
						isGroup = true;
						return true;
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsRecipeBlacklisted( Item item, out bool isGroup ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.RecipeBlacklist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.RecipeBlacklist.Contains( grpName ) ) {
						isGroup = true;
						return true;
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsNpcBlacklisted( NPC npc, out bool isGroup ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcBlacklist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			if( EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerNPC[npc.type] ) {
					if( this.Data.NpcBlacklist.Contains( grpName ) ) {
						isGroup = true;
						return true;
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsNpcLootBlacklisted( NPC npc, out bool isGroup ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcLootBlacklist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			if( EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerNPC[npc.type] ) {
					if( this.Data.NpcLootBlacklist.Contains( grpName ) ) {
						isGroup = true;
						return true;
					}
				}
			}
			
			isGroup = false;
			return false;
		}
		

		////////////////

		internal bool IsItemWhitelisted( Item item, out bool isGroup ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.ItemWhitelist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grp_name in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.ItemWhitelist.Contains( grp_name ) ) {
						isGroup = true;
						return true;
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsRecipeWhitelisted( Item item, out bool isGroup ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.RecipeWhitelist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.RecipeWhitelist.Contains( grpName ) ) {
						isGroup = true;
						return true;
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsNpcWhitelisted( NPC npc, out bool isGroup ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcWhitelist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			if( EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerNPC[npc.type] ) {
					if( this.Data.NpcWhitelist.Contains( grpName ) ) {
						isGroup = true;
						return true;
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsNpcLootWhitelisted( NPC npc, out bool isGroup ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcLootWhitelist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			if( EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerNPC[npc.type] ) {
					if( this.Data.NpcLootWhitelist.Contains( grpName ) ) {
						isGroup = true;
						return true;
					}
				}
			}

			isGroup = false;
			return false;
		}

		
		////////////////

		public bool IsItemEnabled( Item item, out bool isBlackList, out bool isGroup ) {
			if( !this.IsItemBlacklisted( item, out isGroup ) ) {
				isBlackList = false;
				return true;
			}
			isBlackList = true;
			return this.IsItemWhitelisted( item, out isGroup );
		}


		public bool IsRecipeOfItemEnabled( Item item, out bool isBlackList, out bool isGroup ) {
			if( !this.IsRecipeBlacklisted( item, out isGroup ) ) {
				isBlackList = false;
				return true;
			}
			isBlackList = true;
			return this.IsRecipeWhitelisted( item, out isGroup );
		}


		public bool IsNpcEnabled( NPC npc, out bool isBlackList, out bool isGroup ) {
			if( !this.IsNpcBlacklisted( npc, out isGroup ) ) {
				isBlackList = false;
				return true;
			}
			isBlackList = true;
			return this.IsNpcWhitelisted( npc, out isGroup );
		}


		public bool IsNpcLootEnabled( NPC npc, out bool isBlackList, out bool isGroup ) {
			if( !this.IsNpcLootBlacklisted( npc, out isGroup ) ) {
				isBlackList = false;
				return true;
			}
			isBlackList = true;
			return this.IsNpcLootWhitelisted( npc, out isGroup );
		}
	}
}
