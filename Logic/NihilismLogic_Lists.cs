using HamstarHelpers.DebugHelpers;
using System.Text.RegularExpressions;
using Terraria;


namespace Nihilism.Logic {
	partial class NihilismLogic {
		private static Regex _RecipesBlacklistPattern = null;
		private static Regex _ItemsBlacklistPattern = null;
		private static Regex _NpcsBlacklistPattern = null;
		private static Regex _NpcLootBlacklistPattern = null;

		public static Regex GetRecipesBlacklistPattern( NihilismLogic logic ) {
			if( NihilismLogic._RecipesBlacklistPattern == null ) {
				NihilismLogic._RecipesBlacklistPattern = new Regex( logic.Data.RecipesBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._RecipesBlacklistPattern;
		}
		public static Regex GetItemsBlacklistPattern( NihilismLogic logic ) {
			if( NihilismLogic._ItemsBlacklistPattern == null ) {
				NihilismLogic._ItemsBlacklistPattern = new Regex( logic.Data.ItemsBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._ItemsBlacklistPattern;
		}
		public static Regex GetNpcsBlacklistPattern( NihilismLogic logic ) {
			if( NihilismLogic._NpcsBlacklistPattern == null ) {
				NihilismLogic._NpcsBlacklistPattern = new Regex( logic.Data.NpcBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._NpcsBlacklistPattern;
		}
		public static Regex GetNpcLootBlacklistPattern( NihilismLogic logic ) {
			if( NihilismLogic._NpcLootBlacklistPattern == null ) {
				NihilismLogic._NpcLootBlacklistPattern = new Regex( logic.Data.NpcLootBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._NpcLootBlacklistPattern;
		}

		public static void ResetCachedPatterns() {
			NihilismLogic._RecipesBlacklistPattern = null;
			NihilismLogic._ItemsBlacklistPattern = null;
			NihilismLogic._NpcsBlacklistPattern = null;
			NihilismLogic._NpcLootBlacklistPattern = null;
		}


		////////////////
		
		public bool IsItemWhitelisted( Item item ) {
			if( !this.Data.ItemWhitelist.ContainsKey( item.Name ) ) {
				return false;
			}
			return this.Data.ItemWhitelist[item.Name];
		}

		public bool IsItemBlacklisted( Item item ) {
			return NihilismLogic.GetItemsBlacklistPattern( this ).IsMatch( item.Name );
		}

		public bool IsItemEnabled( Item item ) {
			if( this.Data.ItemsBlacklistChecksFirst ) {
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
			if( !this.Data.RecipeWhitelist.ContainsKey( item.Name ) ) {
				return false;
			}
			return this.Data.RecipeWhitelist[ item.Name ];
		}

		public bool IsRecipeBlacklisted( Item item ) {
			return NihilismLogic.GetRecipesBlacklistPattern( this ).IsMatch( item.Name );
		}

		public bool IsRecipeOfItemEnabled( Item item ) {
			if( this.Data.RecipesBlacklistChecksFirst ) {
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
			if( !this.Data.NpcWhitelist.ContainsKey( npc.TypeName ) ) {
				return false;
			}
			return this.Data.NpcWhitelist[npc.TypeName];
		}

		public bool IsNpcBlacklisted( NPC npc ) {
			return NihilismLogic.GetNpcsBlacklistPattern( this ).IsMatch( npc.TypeName );
		}

		public bool IsNpcEnabled( NPC npc ) {
			if( this.Data.NpcsBlacklistChecksFirst ) {
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
			if( !this.Data.NpcLootWhitelist.ContainsKey( npc.TypeName ) ) {
				return false;
			}
			return this.Data.NpcLootWhitelist[ npc.TypeName ];
		}

		public bool IsNpcLootBlacklisted( NPC npc ) {
			return NihilismLogic.GetNpcLootBlacklistPattern( this ).IsMatch( npc.TypeName );
		}

		public bool IsNpcLootEnabled( NPC npc ) {
			if( this.Data.NpcLootBlacklistChecksFirst ) {
				if( this.IsNpcLootBlacklisted( npc) ) {
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
