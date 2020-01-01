using HamstarHelpers.Classes.DataStructures;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Services.EntityGroups;
using Terraria;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		internal bool IsItemBlacklisted( Item item, out bool isGroup ) {
			if( this.Filters.ItemBlacklist.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.ItemGroupBlacklist.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsRecipeBlacklisted( Item item, out bool isGroup ) {
			if( this.Filters.RecipeBlacklist.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.RecipeGroupBlacklist.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsNpcBlacklisted( NPC npc, out bool isGroup ) {
			if( this.Filters.NpcBlacklist.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcGroupBlacklist.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsNpcLootBlacklisted( NPC npc, out bool isGroup ) {
			if( this.Filters.NpcLootBlacklist.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcLootGroupBlacklist.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}
			
			isGroup = false;
			return false;
		}
		

		////////////////

		internal bool IsItemWhitelisted( Item item, out bool isGroup ) {
			if( this.Filters.ItemWhitelist.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.ItemGroupWhitelist.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsRecipeWhitelisted( Item item, out bool isGroup ) {
			if( this.Filters.RecipeWhitelist.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.RecipeGroupWhitelist.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsNpcWhitelisted( NPC npc, out bool isGroup ) {
			if( this.Filters.NpcWhitelist.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcGroupWhitelist.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsNpcLootWhitelisted( NPC npc, out bool isGroup ) {
			if( this.Filters.NpcLootWhitelist.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcLootGroupWhitelist.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}


		////////////////

		internal bool IsItemBlacklisted2( Item item, out bool isGroup ) {
			if( this.Filters.ItemBlacklist2.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.ItemGroupBlacklist2.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsRecipeBlacklisted2( Item item, out bool isGroup ) {
			if( this.Filters.RecipeBlacklist2.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.Filters.RecipeGroupBlacklist2.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsNpcBlacklisted2( NPC npc, out bool isGroup ) {
			if( this.Filters.NpcBlacklist2.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcGroupBlacklist2.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}

		private bool IsNpcLootBlacklisted2( NPC npc, out bool isGroup ) {
			if( this.Filters.NpcLootBlacklist.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( this.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.Filters.NpcLootGroupBlacklist2.Contains( grpName ) ) {
							isGroup = true;
							return true;
						}
					}
				}
			}

			isGroup = false;
			return false;
		}
	}
}
