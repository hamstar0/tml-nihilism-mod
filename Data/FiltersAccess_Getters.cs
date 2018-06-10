using HamstarHelpers.ItemHelpers;
using HamstarHelpers.NPCHelpers;
using HamstarHelpers.Utilities.EntityGroups;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		private bool IsItemWhitelisted( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.ItemWhitelist.ContainsKey( name ) ) {
				return this.Data.ItemWhitelist[ name ];
			}
			
			foreach( string grp_name in EntityGroups.GroupsPerItem[ item.type ] ) {
				if( this.Data.ItemWhitelist.ContainsKey(grp_name) ) {
					return true;
				}
			}

			return false;
		}

		////

		private bool IsRecipeWhitelisted( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( this.Data.RecipeWhitelist.ContainsKey( name ) ) {
				return this.Data.RecipeWhitelist[name];
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[item.type] ) {
				if( this.Data.RecipeWhitelist.ContainsKey( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		////

		private bool IsNpcWhitelisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcWhitelist.ContainsKey( name ) ) {
				return this.Data.NpcWhitelist[name];
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[npc.type] ) {
				if( this.Data.NpcWhitelist.ContainsKey( grp_name ) ) {
					return true;
				}
			}

			return false;
		}

		////

		private bool IsNpcLootWhitelisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( this.Data.NpcLootWhitelist.ContainsKey( name ) ) {
				return this.Data.NpcLootWhitelist[name];
			}

			foreach( string grp_name in EntityGroups.GroupsPerItem[npc.type] ) {
				if( this.Data.NpcLootWhitelist.ContainsKey( grp_name ) ) {
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
