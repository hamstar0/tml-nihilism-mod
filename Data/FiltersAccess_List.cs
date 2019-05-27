using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.ItemHelpers;
using HamstarHelpers.Helpers.NPCHelpers;
using HamstarHelpers.Services.EntityGroups;
using System.Collections.Generic;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public IList<string> GetItemBlacklistGroupEntriesForItem( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.ItemBlacklist.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeBlacklistGroupEntriesForItemRecipe( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.RecipeBlacklist.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcBlacklistGroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerNPC[npc.type] ) {
					if( this.Data.NpcBlacklist.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootBlacklistGroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );
			IList<string> groups = new List<string>();
			
			if( EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerNPC[npc.type] ) {
					if( this.Data.NpcLootBlacklist.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}


		////////////////

		public IList<string> GetItemWhitelistGroupEntriesForItem( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.ItemWhitelist.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeWhitelistGroupEntriesForItemRecipe( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.RecipeWhitelist.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcWhitelistGroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerNPC[npc.type] ) {
					if( this.Data.NpcWhitelist.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootWhitelistGroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerNPC[npc.type] ) {
					if( this.Data.NpcLootWhitelist.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}


		////////////////

		public IList<string> GetItemBlacklist2GroupEntriesForItem( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.ItemBlacklist2.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeBlacklist2GroupEntriesForItemRecipe( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerItem.ContainsKey( item.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerItem[item.type] ) {
					if( this.Data.RecipeBlacklist2.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcBlacklist2GroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerNPC[npc.type] ) {
					if( this.Data.NpcBlacklist2.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootBlacklist2GroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );
			IList<string> groups = new List<string>();

			if( EntityGroups.GroupsPerNPC.ContainsKey( npc.type ) ) {
				foreach( string grpName in EntityGroups.GroupsPerNPC[npc.type] ) {
					if( this.Data.NpcLootBlacklist2.Contains( grpName ) ) {
						groups.Add( grpName );
					}
				}
			}

			return groups;
		}
	}
}
