using HamstarHelpers.Classes.DataStructures;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Services.EntityGroups;
using System.Collections.Generic;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public IList<string> GetItemBlacklistGroupEntriesForItem( Item item ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemGroupBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeBlacklistGroupEntriesForItemRecipe( Item item ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeGroupBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcBlacklistGroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcGroupBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootBlacklistGroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootGroupBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}


		////////////////

		public IList<string> GetItemWhitelistGroupEntriesForItem( Item item ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemGroupWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeWhitelistGroupEntriesForItemRecipe( Item item ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeGroupWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcWhitelistGroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcGroupWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootWhitelistGroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootGroupWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}


		////////////////

		public IList<string> GetItemBlacklist2GroupEntriesForItem( Item item ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemGroupBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeBlacklist2GroupEntriesForItemRecipe( Item item ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeGroupBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcBlacklist2GroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcGroupBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootBlacklist2GroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootGroupBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}
	}
}
