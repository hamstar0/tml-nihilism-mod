using HamstarHelpers.ItemHelpers;
using HamstarHelpers.NPCHelpers;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		private bool IsItemWhitelisted( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( !this.Data.ItemWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.ItemWhitelist[name];
		}

		////

		private bool IsRecipeWhitelisted( Item item ) {
			string name = ItemIdentityHelpers.GetQualifiedName( item );

			if( !this.Data.RecipeWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.RecipeWhitelist[name];
		}

		////

		private bool IsNpcWhitelisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( !this.Data.NpcWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.NpcWhitelist[name];
		}

		////

		private bool IsNpcLootWhitelisted( NPC npc ) {
			string name = NPCIdentityHelpers.GetQualifiedName( npc );

			if( !this.Data.NpcLootWhitelist.ContainsKey( name ) ) {
				return false;
			}
			return this.Data.NpcLootWhitelist[name];
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
