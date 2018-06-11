using HamstarHelpers.Utilities.Config;
using System;
using System.Collections.Generic;


namespace Nihilism.Data {
	class NihilismFilterData : ConfigurationDataBase {
		public bool IsActive = false;
		
		public bool IsRecipeFilterOn;
		public bool IsItemFilterOn;
		public bool IsNpcFilterOn;
		public bool IsNpcLootFilterOn;

		public ISet<string> RecipeWhitelist = new HashSet<string> { };
		public ISet<string> ItemWhitelist = new HashSet<string> { };
		public ISet<string> NpcWhitelist = new HashSet<string> { };
		public ISet<string> NpcLootWhitelist = new HashSet<string> { };

		[Obsolete( "Not a useable setting", true )]
		public string _OLD_SETTINGS_BELOW_ = "";

		[Obsolete( "Use NihilismFilterData.RecipesBlacklisted", true )]
		public string RecipesBlacklistPattern;
		[Obsolete( "Use NihilismFilterData.ItemsBlacklisted", true )]
		public string ItemsBlacklistPattern;
		[Obsolete( "Use NihilismFilterData.NpcBlacklisted", true )]
		public string NpcBlacklistPattern;
		[Obsolete( "Use NihilismFilterData.NpcLootBlacklisted", true )]
		public string NpcLootBlacklistPattern;



		////////////////

		public NihilismFilterData() {
			this.ResetFiltersFromDefaults( NihilismMod.Instance );
		}


		////////////////
		
		public void SetCurrentFiltersAsDefaults( NihilismMod mymod ) {
			mymod.Config.DefaultItemsBlacklisted = this.IsItemFilterOn;
			mymod.Config.DefaultRecipesBlacklisted = this.IsRecipeFilterOn;
			mymod.Config.DefaultNpcLootBlacklisted = this.IsNpcLootFilterOn;
			mymod.Config.DefaultNpcBlacklisted = this.IsNpcFilterOn;
			
			mymod.Config.DefaultRecipeWhitelist = new HashSet<string>( this.RecipeWhitelist );
			mymod.Config.DefaultItemWhitelist = new HashSet<string>( this.ItemWhitelist );
			mymod.Config.DefaultNpcWhitelist = new HashSet<string>( this.NpcWhitelist );
			mymod.Config.DefaultNpcLootWhitelist = new HashSet<string>( this.NpcLootWhitelist );

			if( !mymod.SuppressAutoSaving ) {
				mymod.ConfigJson.SaveFile();
			}
		}

		public void ResetFiltersFromDefaults( NihilismMod mymod ) {
			this.IsItemFilterOn = mymod.Config.DefaultItemsBlacklisted;
			this.IsRecipeFilterOn = mymod.Config.DefaultRecipesBlacklisted;
			this.IsNpcLootFilterOn = mymod.Config.DefaultNpcLootBlacklisted;
			this.IsNpcFilterOn = mymod.Config.DefaultNpcBlacklisted;
			
			this.RecipeWhitelist = new HashSet<string>( mymod.Config.DefaultRecipeWhitelist );
			this.ItemWhitelist = new HashSet<string>( mymod.Config.DefaultItemWhitelist );
			this.NpcWhitelist = new HashSet<string>( mymod.Config.DefaultNpcWhitelist );
			this.NpcLootWhitelist = new HashSet<string>( mymod.Config.DefaultNpcLootWhitelist );
		}
	}
}
