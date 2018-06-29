using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismRecipe : GlobalRecipe {
		public override bool RecipeAvailable( Recipe recipe ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return base.RecipeAvailable( recipe ); }

			if( !myworld.Logic.AreRecipesFiltersEnabled( mymod ) ) {
				return base.RecipeAvailable( recipe );
			}

			Item item = recipe.createItem;

			if( item == null || item.IsAir ) {
				return base.RecipeAvailable( recipe );
			}

			return myworld.Logic.DataAccess.IsRecipeOfItemEnabled( item );
		}
	}
}
