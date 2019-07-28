using HamstarHelpers.Components.DataStructures;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.Items;
using HamstarHelpers.Helpers.NPCs;
using HamstarHelpers.Services.EntityGroups;
using System.Collections.Generic;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public IList<string> GetItemBlacklistGroupEntriesForItem( Item item ) {
			string name = ItemIdentityHelpers.GetUniqueKey( item );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeBlacklistGroupEntriesForItemRecipe( Item item ) {
			string name = ItemIdentityHelpers.GetUniqueKey( item );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcBlacklistGroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetUniqueKey( npc );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootBlacklistGroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetUniqueKey( npc );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}


		////////////////

		public IList<string> GetItemWhitelistGroupEntriesForItem( Item item ) {
			string name = ItemIdentityHelpers.GetUniqueKey( item );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeWhitelistGroupEntriesForItemRecipe( Item item ) {
			string name = ItemIdentityHelpers.GetUniqueKey( item );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcWhitelistGroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetUniqueKey( npc );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootWhitelistGroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetUniqueKey( npc );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}


		////////////////

		public IList<string> GetItemBlacklist2GroupEntriesForItem( Item item ) {
			string name = ItemIdentityHelpers.GetUniqueKey( item );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeBlacklist2GroupEntriesForItemRecipe( Item item ) {
			string name = ItemIdentityHelpers.GetUniqueKey( item );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcBlacklist2GroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetUniqueKey( npc );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootBlacklist2GroupEntriesForNpc( NPC npc ) {
			string name = NPCIdentityHelpers.GetUniqueKey( npc );
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}
	}
}
