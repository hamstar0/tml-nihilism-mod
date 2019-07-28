﻿using HamstarHelpers.Components.DataStructures;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.Items;
using HamstarHelpers.Helpers.NPCs;
using HamstarHelpers.Services.EntityGroups;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		internal bool IsItemBlacklisted( Item item, out bool isGroup ) {
			string name = ItemIdentityHelpers.GetUniqueKey( item );

			if( this.FilterConfig.ItemBlacklist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemBlacklist.Contains( grpName ) ) {
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
			string name = ItemIdentityHelpers.GetUniqueKey( item );

			if( this.FilterConfig.RecipeBlacklist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeBlacklist.Contains( grpName ) ) {
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
			string name = NPCIdentityHelpers.GetUniqueKey( npc );

			if( this.FilterConfig.NpcBlacklist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcBlacklist.Contains( grpName ) ) {
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
			string name = NPCIdentityHelpers.GetUniqueKey( npc );

			if( this.FilterConfig.NpcLootBlacklist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootBlacklist.Contains( grpName ) ) {
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
			string name = ItemIdentityHelpers.GetUniqueKey( item );

			if( this.FilterConfig.ItemWhitelist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemWhitelist.Contains( grpName ) ) {
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
			string name = ItemIdentityHelpers.GetUniqueKey( item );

			if( this.FilterConfig.RecipeWhitelist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeWhitelist.Contains( grpName ) ) {
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
			string name = NPCIdentityHelpers.GetUniqueKey( npc );

			if( this.FilterConfig.NpcWhitelist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcWhitelist.Contains( grpName ) ) {
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
			string name = NPCIdentityHelpers.GetUniqueKey( npc );

			if( this.FilterConfig.NpcLootWhitelist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootWhitelist.Contains( grpName ) ) {
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
			string name = ItemIdentityHelpers.GetUniqueKey( item );

			if( this.FilterConfig.ItemBlacklist2.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.ItemBlacklist2.Contains( grpName ) ) {
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
			string name = ItemIdentityHelpers.GetUniqueKey( item );

			if( this.FilterConfig.RecipeBlacklist2.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerItem;

				if( EntityGroups.TryGetGroupsPerItem( item.type, out grpsPerItem ) ) {
					foreach( string grpName in grpsPerItem ) {
						if( this.FilterConfig.RecipeBlacklist2.Contains( grpName ) ) {
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
			string name = NPCIdentityHelpers.GetUniqueKey( npc );

			if( this.FilterConfig.NpcBlacklist2.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcBlacklist2.Contains( grpName ) ) {
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
			string name = NPCIdentityHelpers.GetUniqueKey( npc );

			if( this.FilterConfig.NpcLootBlacklist.Contains( name ) ) {
				isGroup = false;
				return true;
			}

			lock( NihilismFilterAccess.MyLock ) {
				IReadOnlySet<string> grpsPerNPC;

				if( EntityGroups.TryGetGroupsPerNPC( npc.type, out grpsPerNPC ) ) {
					foreach( string grpName in grpsPerNPC ) {
						if( this.FilterConfig.NpcLootBlacklist2.Contains( grpName ) ) {
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
