using HamstarHelpers.ItemHelpers;
using HamstarHelpers.NPCHelpers;
using HamstarHelpers.Utilities.EntityGroups;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		private bool IsItemWhitelisted( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.ItemWhitelist.Contains( name ) ) {
				return this.Data.ItemWhitelist.Add( name );
			}
			
			foreach( string grp_name in EntityGroups.GroupsPerItem[ item.type ] ) {
				if( this.Data.ItemWhitelist.Contains( grp_name) ) {
					return true;
				}
			}

			return false;
		}

		////

		private bool IsRecipeWhitelisted( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.RecipeWhitelist.Contains( name ) ) {
				return this.Data.RecipeWhitelist.Add( name );
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[item.type] ) {
				if( this.Data.RecipeWhitelist.Contains( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		////

		private bool IsNpcWhitelisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcWhitelist.Contains( name ) ) {
				return this.Data.NpcWhitelist.Add( name );
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[npc.type] ) {
				if( this.Data.NpcWhitelist.Contains( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		////

		private bool IsNpcLootWhitelisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcLootWhitelist.Contains( name ) ) {
				return this.Data.NpcLootWhitelist.Add( name );
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[npc.type] ) {
				if( this.Data.NpcLootWhitelist.Contains( grp_name ) ) {
					return true;
				}
			}

			return false;
		}



		////////////////

		public bool IsItemEnabled( Item item ) {
			if( !this.Data.IsItemFilterOn ) {
				return true;
			}
			return this.IsItemWhitelisted( item );
		}


		public bool IsRecipeOfItemEnabled( Item item ) {
			if( !this.Data.IsRecipeFilterOn ) {
				return true;
			}
			return this.IsRecipeWhitelisted( item );
		}


		public bool IsNpcEnabled( NPC npc ) {
			if( !this.Data.IsNpcFilterOn ) {
				return true;
			}
			return this.IsNpcWhitelisted( npc );
		}


		public bool IsNpcLootEnabled( NPC npc ) {
			if( !this.Data.IsNpcLootFilterOn ) {
				return true;
			}
			return this.IsNpcLootWhitelisted( npc );
		}
	}
}
