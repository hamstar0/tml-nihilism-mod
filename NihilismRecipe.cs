using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismRecipe : GlobalRecipe {
		public override bool RecipeAvailable( Recipe recipe ) {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.EnableRecipeFilters ) { return base.RecipeAvailable( recipe ); }

			var myworld = mymod.GetModWorld<NihilismWorld>();
			Item item = recipe.createItem;

			if( item == null || item.IsAir ) { return base.RecipeAvailable( recipe ); }

			return myworld.Logic.Data.IsRecipeOfItemEnabled( item );
		}
	}
}
