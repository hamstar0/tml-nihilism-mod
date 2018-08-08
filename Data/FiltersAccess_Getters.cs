using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.ItemHelpers;
using HamstarHelpers.Helpers.NPCHelpers;
using HamstarHelpers.Services.EntityGroups;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		internal bool IsItemBlacklisted( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.ItemBlacklist.Contains( name ) ) {
				return true;
			}
			
			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grp_name in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.ItemBlacklist.Contains( grp_name ) ) {
						return true;
					}
				}
			}

			return false;
		}

		private bool IsRecipeBlacklisted( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.RecipeBlacklist.Contains( name ) ) {
				return true;
			}

			if( !EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				return false;
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[item.type] ) {
				if( this.Data.RecipeBlacklist.Contains( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		private bool IsNpcBlacklisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcBlacklist.Contains( name ) ) {
				return true;
			}

			if( !EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				return false;
			}

			foreach( string grp_name in EntityGroups.GroupsPerNPC[npc.type] ) {
				if( this.Data.NpcBlacklist.Contains( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		private bool IsNpcLootBlacklisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcLootBlacklist.Contains( name ) ) {
				return true;
			}

			if( !EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				return false;
			}

			foreach( string grp_name in EntityGroups.GroupsPerNPC[npc.type] ) {
				if( this.Data.NpcLootBlacklist.Contains( grp_name ) ) {
					return true;
				}
			}

			return false;
		}



		////////////////

		internal bool IsItemWhitelisted( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.ItemWhitelist.Contains( name ) ) {
				return true;
			}

			if( !EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				return false;
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[item.type] ) {
				if( this.Data.ItemWhitelist.Contains( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		private bool IsRecipeWhitelisted( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.RecipeWhitelist.Contains( name ) ) {
				return true;
			}

			if( !EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				return false;
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[ item.type ] ) {
				if( this.Data.RecipeWhitelist.Contains( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		private bool IsNpcWhitelisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcWhitelist.Contains( name ) ) {
				return true;
			}

			if( !EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				return false;
			}

			foreach( string grp_name in EntityGroups.GroupsPerNPC[ npc.type ] ) {
				if( this.Data.NpcWhitelist.Contains( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		private bool IsNpcLootWhitelisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcLootWhitelist.Contains( name ) ) {
				return true;
			}

			if( !EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				return false;
			}

			foreach( string grp_name in EntityGroups.GroupsPerNPC[ npc.type ] ) {
				if( this.Data.NpcLootWhitelist.Contains( grp_name ) ) {
					return true;
				}
			}

			return false;
		}



		////////////////

		public bool IsItemEnabled( Item item ) {
			if( !this.IsItemBlacklisted( item ) ) {
				return true;
			}
			return this.IsItemWhitelisted( item );
		}


		public bool IsRecipeOfItemEnabled( Item item ) {
			if( !this.IsRecipeBlacklisted( item ) ) {
				return true;
			}
			return this.IsRecipeWhitelisted( item );
		}


		public bool IsNpcEnabled( NPC npc ) {
			if( !this.IsNpcBlacklisted( npc ) ) {
				return true;
			}
			return this.IsNpcWhitelisted( npc );
		}


		public bool IsNpcLootEnabled( NPC npc ) {
			if( !this.IsNpcLootBlacklisted( npc ) ) {
				return true;
			}
			return this.IsNpcLootWhitelisted( npc );
		}
	}
}
