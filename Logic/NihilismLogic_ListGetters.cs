using HamstarHelpers.DebugHelpers;
using System.Text.RegularExpressions;
using Terraria;


namespace Nihilism.Logic {
	partial class NihilismLogic {
		public static string GetItemName( Item item ) {
			return Lang.GetItemNameValue( item.type );  //item.Name;
		}

		public static string GetNpcName( NPC npc ) {
			return npc.TypeName;
		}



		////////////////

		private static Regex _ItemsBlacklistPattern = null;
		private static Regex _RecipesBlacklistPattern = null;
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
			string name = NihilismLogic.GetItemName( item );

			if( !this.Data.ItemWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.ItemWhitelist[name];
		}

		public bool IsItemBlacklisted( Item item ) {
			string name = NihilismLogic.GetItemName( item );

			return NihilismLogic.GetItemsBlacklistPattern( this ).IsMatch( name );
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
			string name = NihilismLogic.GetItemName( item );

			if( !this.Data.RecipeWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.RecipeWhitelist[name];
		}

		public bool IsRecipeBlacklisted( Item item ) {
			string name = NihilismLogic.GetItemName( item );

			return NihilismLogic.GetRecipesBlacklistPattern( this ).IsMatch( name );
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
			string name = NihilismLogic.GetNpcName( npc );

			if( !this.Data.NpcWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.NpcWhitelist[name];
		}

		public bool IsNpcBlacklisted( NPC npc ) {
			string name = NihilismLogic.GetNpcName( npc );

			return NihilismLogic.GetNpcsBlacklistPattern( this ).IsMatch( name );
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
			string name = NihilismLogic.GetNpcName( npc );

			if( !this.Data.NpcLootWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.NpcLootWhitelist[ name ];
		}

		public bool IsNpcLootBlacklisted( NPC npc ) {
			string name = NihilismLogic.GetNpcName( npc );

			return NihilismLogic.GetNpcLootBlacklistPattern( this ).IsMatch( name );
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
