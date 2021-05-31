using Terraria;
using ModLibsCore.Libraries.Debug;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		public bool IsItemEnabled( Item item, out bool isBlackList, out bool isGroup ) {
			isBlackList = this.IsItemBlacklisted( item, out isGroup );

			if( isBlackList ) {
				if( this.IsItemWhitelisted( item, out isGroup ) ) {
					return !this.IsItemBlacklisted2( item, out isGroup );
				} else {
					return false;
				}
			} else {
				return true;
			}
		}


		public bool IsRecipeOfItemEnabled( Item item, out bool isBlackList, out bool isGroup ) {
			isBlackList = this.IsRecipeBlacklisted( item, out isGroup );

			if( isBlackList ) {
				if( this.IsRecipeWhitelisted( item, out isGroup ) ) {
					return !this.IsRecipeBlacklisted2( item, out isGroup );
				} else {
					return false;
				}
			} else {
				return true;
			}
		}


		public bool IsNpcEnabled( NPC npc, out bool isBlackList, out bool isGroup ) {
			isBlackList = this.IsNpcBlacklisted( npc, out isGroup );

			if( isBlackList ) {
				if( this.IsNpcWhitelisted( npc, out isGroup ) ) {
					return !this.IsNpcBlacklisted2( npc, out isGroup );
				} else {
					return false;
				}
			} else {
				return true;
			}
		}


		public bool IsNpcLootEnabled( NPC npc, out bool isBlackList, out bool isGroup ) {
			isBlackList = this.IsNpcLootBlacklisted( npc, out isGroup );

			if( isBlackList ) {
				if( this.IsNpcLootWhitelisted( npc, out isGroup ) ) {
					return !this.IsNpcLootBlacklisted2( npc, out isGroup );
				} else {
					return false;
				}
			} else {
				return true;
			}
		}
	}
}
