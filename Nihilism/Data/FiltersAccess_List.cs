using System.Collections.Generic;
using Terraria;
using ModLibsCore.Classes.DataStructures;
using ModLibsCore.Libraries.Debug;
using ModLibsEntityGroups.Services.EntityGroups;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		public IList<string> GetItemBlacklistGroupEntriesForItem( Item item ) {
			IList<string> groups = new List<string>();

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.ItemGroupBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeBlacklistGroupEntriesForItemRecipe( Item item ) {
			IList<string> groups = new List<string>();

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.RecipeGroupBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcBlacklistGroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcGroupBlacklist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootBlacklistGroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcLootGroupBlacklist.Contains( grpName ) ) {
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

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.ItemGroupWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeWhitelistGroupEntriesForItemRecipe( Item item ) {
			IList<string> groups = new List<string>();

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.RecipeGroupWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcWhitelistGroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcGroupWhitelist.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootWhitelistGroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcLootGroupWhitelist.Contains( grpName ) ) {
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

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.ItemGroupBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetRecipeBlacklist2GroupEntriesForItemRecipe( Item item ) {
			IList<string> groups = new List<string>();

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.RecipeGroupBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcBlacklist2GroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcGroupBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}

		public IList<string> GetNpcLootBlacklist2GroupEntriesForNpc( NPC npc ) {
			IList<string> groups = new List<string>();

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcLootGroupBlacklist2.Contains( grpName ) ) {
							groups.Add( grpName );
						}
					}
				}
			}

			return groups;
		}
	}
}
