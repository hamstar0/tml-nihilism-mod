using HamstarHelpers.Classes.DataStructures;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Services.EntityGroups;
using Terraria;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		internal bool IsItemBlacklisted( Item item, out bool isGroup ) {
			if( this.FilterConfig.ItemBlacklist.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemGroupBlacklist.Contains( grpName ) ) {
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
			if( this.FilterConfig.RecipeBlacklist.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeGroupBlacklist.Contains( grpName ) ) {
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
			if( this.FilterConfig.NpcBlacklist.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcGroupBlacklist.Contains( grpName ) ) {
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
			if( this.FilterConfig.NpcLootBlacklist.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootGroupBlacklist.Contains( grpName ) ) {
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
			if( this.FilterConfig.ItemWhitelist.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemGroupWhitelist.Contains( grpName ) ) {
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
			if( this.FilterConfig.RecipeWhitelist.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeGroupWhitelist.Contains( grpName ) ) {
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
			if( this.FilterConfig.NpcWhitelist.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcGroupWhitelist.Contains( grpName ) ) {
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
			if( this.FilterConfig.NpcLootWhitelist.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootGroupWhitelist.Contains( grpName ) ) {
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
			if( this.FilterConfig.ItemBlacklist2.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemGroupBlacklist2.Contains( grpName ) ) {
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
			if( this.FilterConfig.RecipeBlacklist2.Contains( new ItemDefinition(item.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeGroupBlacklist2.Contains( grpName ) ) {
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
			if( this.FilterConfig.NpcBlacklist2.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcGroupBlacklist2.Contains( grpName ) ) {
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
			if( this.FilterConfig.NpcLootBlacklist.Contains( new NPCDefinition(npc.type) ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootGroupBlacklist2.Contains( grpName ) ) {
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
