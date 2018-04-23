using HamstarHelpers.DebugHelpers;
using System.Text.RegularExpressions;
using Terraria;


namespace Nihilism.Logic {
	partial class NihilismLogic {
		private static Regex _RecipesBlacklistPattern = null;
		private static Regex _ItemsBlacklistPattern = null;
		private static Regex _NpcsBlacklistPattern = null;
		private static Regex _NpcItemDropsBlacklistPattern = null;

		public static Regex GetRecipesBlacklistPattern( NihilismLogic logic ) {
			if( NihilismLogic._RecipesBlacklistPattern == null ) {
				NihilismLogic._RecipesBlacklistPattern = new Regex( logic.Filters.RecipesBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._RecipesBlacklistPattern;
		}
		public static Regex GetItemsBlacklistPattern( NihilismLogic logic ) {
			if( NihilismLogic._ItemsBlacklistPattern == null ) {
				NihilismLogic._ItemsBlacklistPattern = new Regex( logic.Filters.ItemsBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._ItemsBlacklistPattern;
		}
		public static Regex GetNpcsBlacklistPattern( NihilismLogic logic ) {
			if( NihilismLogic._NpcsBlacklistPattern == null ) {
				NihilismLogic._NpcsBlacklistPattern = new Regex( logic.Filters.NpcsBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._NpcsBlacklistPattern;
		}
		public static Regex GetNpcItemDropsBlacklistPattern( NihilismLogic logic ) {
			if( NihilismLogic._NpcItemDropsBlacklistPattern == null ) {
				NihilismLogic._NpcItemDropsBlacklistPattern = new Regex( logic.Filters.NpcItemDropsBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._NpcItemDropsBlacklistPattern;
		}

		public static void ResetCachedPatterns() {
			NihilismLogic._RecipesBlacklistPattern = null;
			NihilismLogic._ItemsBlacklistPattern = null;
			NihilismLogic._NpcsBlacklistPattern = null;
			NihilismLogic._NpcItemDropsBlacklistPattern = null;
		}


		////////////////
		
		public bool IsItemWhitelisted( Item item ) {
			if( !this.Filters.ItemWhitelist.ContainsKey( item.Name ) ) {
				return false;
			}
			return this.Filters.ItemWhitelist[item.Name];
		}

		public bool IsItemBlacklisted( Item item ) {
			return NihilismLogic.GetItemsBlacklistPattern( this ).IsMatch( item.Name );
		}

		public bool IsItemEnabled( Item item ) {
			if( this.Filters.ItemsBlacklistChecksFirst ) {
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
			if( !this.Filters.RecipeWhitelist.ContainsKey( item.Name ) ) {
				return false;
			}
			return this.Filters.RecipeWhitelist[ item.Name ];
		}

		public bool IsRecipeBlacklisted( Item item ) {
			return NihilismLogic.GetRecipesBlacklistPattern( this ).IsMatch( item.Name );
		}

		public bool IsRecipeOfItemEnabled( Item item ) {
			if( this.Filters.RecipesBlacklistChecksFirst ) {
				if( this.IsRecipeBlacklisted( this, item ) ) {
					return false;
				}
				return this.IsRecipeWhitelisted( this, item );
			} else {
				if( this.IsRecipeWhitelisted( this, item ) ) {
					return true;
				}
				return !this.IsRecipeBlacklisted( this, item );
			}
		}

		////

		public bool IsNpcWhitelisted( NPC npc ) {
			if( !this.Filters.NpcWhitelist.ContainsKey( npc.TypeName ) ) {
				return false;
			}
			return this.Filters.NpcWhitelist[npc.TypeName];
		}

		public bool IsNpcBlacklisted( NPC npc ) {
			return NihilismLogic.GetNpcsBlacklistPattern( this ).IsMatch( npc.TypeName );
		}

		public bool IsNpcEnabled( NPC npc ) {
			if( this.Filters.NpcsBlacklistChecksFirst ) {
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

		public bool IsNpcItemDropWhitelisted( NPC npc ) {
			if( !this.Filters.NpcItemDropWhitelist.ContainsKey( npc.TypeName ) ) {
				return false;
			}
			return this.Filters.NpcItemDropWhitelist[ npc.TypeName ];
		}

		public bool IsNpcItemDropBlacklisted( NPC npc ) {
			return NihilismLogic.GetNpcItemDropsBlacklistPattern( this ).IsMatch( npc.TypeName );
		}

		public bool IsNpcItemDropEnabled( NPC npc ) {
			if( this.Filters.NpcItemDropsBlacklistChecksFirst ) {
				if( this.IsNpcItemDropBlacklisted( npc) ) {
					return false;
				}
				return this.IsNpcItemDropWhitelisted( npc );
			} else {
				if( this.IsNpcItemDropWhitelisted( npc ) ) {
					return true;
				}
				return !this.IsNpcItemDropBlacklisted( npc );
			}
		}
	}
}
