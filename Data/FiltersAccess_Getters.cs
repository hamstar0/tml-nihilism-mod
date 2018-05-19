using HamstarHelpers.Utilities.Config;
using System.Text.RegularExpressions;
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

		private bool IsItemWhitelisted( Item item ) {
			string name = NihilismFilterAccess.GetItemName( item );

			if( !this.Data.ItemWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.ItemWhitelist[name];
		}

		private bool IsItemBlacklisted( Item item ) {
			string name = NihilismFilterAccess.GetItemName( item );
			Regex regex = this.GetRegex( this.Data.ItemsBlacklistPattern );

			return regex.IsMatch( name );
		}

		////

		private bool IsRecipeWhitelisted( Item item ) {
			string name = NihilismFilterAccess.GetItemName( item );

			if( !this.Data.RecipeWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.RecipeWhitelist[name];
		}

		private bool IsRecipeBlacklisted( Item item ) {
			string name = NihilismFilterAccess.GetItemName( item );
			Regex regex = this.GetRegex( this.Data.RecipesBlacklistPattern );

			return regex.IsMatch( name );
		}

		////

		private bool IsNpcWhitelisted( NPC npc ) {
			string name = NihilismFilterAccess.GetNpcName( npc );

			if( !this.Data.NpcWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.NpcWhitelist[name];
		}

		private bool IsNpcBlacklisted( NPC npc ) {
			string name = NihilismFilterAccess.GetNpcName( npc );
			Regex regex = this.GetRegex( this.Data.NpcBlacklistPattern );

			return regex.IsMatch( name );
		}

		////

		private bool IsNpcLootWhitelisted( NPC npc ) {
			string name = NihilismFilterAccess.GetNpcName( npc );

			if( !this.Data.NpcLootWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.NpcLootWhitelist[name];
		}

		private bool IsNpcLootBlacklisted( NPC npc ) {
			string name = NihilismFilterAccess.GetNpcName( npc );
			Regex regex = this.GetRegex( this.Data.NpcLootBlacklistPattern );

			return regex.IsMatch( name );
		}



		////////////////

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


		public bool IsNpcLootEnabled( NPC npc ) {
			if( this.Data.NpcLootBlacklistChecksFirst ) {
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
