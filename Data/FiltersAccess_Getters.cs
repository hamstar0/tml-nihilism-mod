using HamstarHelpers.Utilities.Config;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		public static string GetItemName( Item item ) {
			return Lang.GetItemNameValue( item.type );  //item.Name;
		}

		public static string GetNpcName( NPC npc ) {
			return npc.TypeName;
		}



		////////////////
		
		public bool IsItemWhitelisted( Item item ) {
			string name = NihilismFilterData.GetItemName( item );

			if( !this.ItemWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.ItemWhitelist[name];
		}

		public bool IsItemBlacklisted( Item item ) {
			string name = NihilismFilterData.GetItemName( item );

			return this.GetItemsBlacklistPattern().IsMatch( name );
		}

		public bool IsItemEnabled( Item item ) {
			if( this.ItemsBlacklistChecksFirst ) {
				if( this.IsItemBlacklisted( item ) ) {
					return false;
				}
				return this.IsItemWhitelisted( item );
			} else {
				if( this.IsItemWhitelisted( item ) ) {
					return true;
				}
				return !this.IsItemBlacklisted( item );
			}
		}

		////

		public bool IsRecipeWhitelisted( Item item ) {
			string name = NihilismFilterData.GetItemName( item );

			if( !this.RecipeWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.RecipeWhitelist[name];
		}

		public bool IsRecipeBlacklisted( Item item ) {
			string name = NihilismFilterData.GetItemName( item );

			return this.GetRecipesBlacklistPattern().IsMatch( name );
		}

		public bool IsRecipeOfItemEnabled( Item item ) {
			if( this.RecipesBlacklistChecksFirst ) {
				if( this.IsRecipeBlacklisted( item ) ) {
					return false;
				}
				return this.IsRecipeWhitelisted( item );
			} else {
				if( this.IsRecipeWhitelisted( item ) ) {
					return true;
				}
				return !this.IsRecipeBlacklisted( item );
			}
		}

		////

		public bool IsNpcWhitelisted( NPC npc ) {
			string name = NihilismFilterData.GetNpcName( npc );

			if( !this.NpcWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.NpcWhitelist[name];
		}

		public bool IsNpcBlacklisted( NPC npc ) {
			string name = NihilismFilterData.GetNpcName( npc );

			return this.GetNpcsBlacklistPattern().IsMatch( name );
		}

		public bool IsNpcEnabled( NPC npc ) {
			if( this.NpcsBlacklistChecksFirst ) {
				if( this.IsNpcBlacklisted( npc ) ) {
					return false;
				}
				return this.IsNpcWhitelisted( npc );
			} else {
				if( this.IsNpcWhitelisted( npc ) ) {
					return true;
				}
				return !this.IsNpcBlacklisted( npc );
			}
		}

		////

		public bool IsNpcLootWhitelisted( NPC npc ) {
			string name = NihilismFilterData.GetNpcName( npc );

			if( !this.NpcLootWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.NpcLootWhitelist[name];
		}

		public bool IsNpcLootBlacklisted( NPC npc ) {
			string name = NihilismFilterData.GetNpcName( npc );

			return this.GetNpcLootBlacklistPattern().IsMatch( name );
		}

		public bool IsNpcLootEnabled( NPC npc ) {
			if( this.NpcLootBlacklistChecksFirst ) {
				if( this.IsNpcLootBlacklisted( npc ) ) {
					return false;
				}
				return this.IsNpcLootWhitelisted( npc );
			} else {
				if( this.IsNpcLootWhitelisted( npc ) ) {
					return true;
				}
				return !this.IsNpcLootBlacklisted( npc );
			}
		}
	}
}
