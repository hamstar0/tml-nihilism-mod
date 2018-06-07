using HamstarHelpers.Utilities.Config;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Nihilism.Data {
	class NihilismFilterData : ConfigurationDataBase {
		public bool IsActive = false;
		
		public bool IsRecipeFilterOn;
		public bool IsItemFilterOn;
		public bool IsNpcFilterOn;
		public bool IsNpcLootFilterOn;

		public IDictionary<string, bool> RecipeWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> ItemWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> NpcWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> NpcLootWhitelist = new Dictionary<string, bool> { };

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
			var mymod = NihilismMod.Instance;

			this.IsRecipeFilterOn = mymod.Config.DefaultRecipesBlacklisted;
			this.IsItemFilterOn = mymod.Config.DefaultItemsBlacklisted;
			this.IsNpcFilterOn = mymod.Config.DefaultNpcBlacklisted;
			this.IsNpcLootFilterOn = mymod.Config.DefaultNpcLootBlacklisted;
			
			this.RecipeWhitelist = mymod.Config.DefaultRecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.ItemWhitelist = mymod.Config.DefaultItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.NpcWhitelist = mymod.Config.DefaultNpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.NpcLootWhitelist = mymod.Config.DefaultNpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
		}


		////////////////
		
		public void SetCurrentFiltersAsDefaults( NihilismMod mymod ) {
			mymod.Config.DefaultItemsBlacklisted = this.IsItemFilterOn;
			mymod.Config.DefaultRecipesBlacklisted = this.IsRecipeFilterOn;
			mymod.Config.DefaultNpcLootBlacklisted = this.IsNpcLootFilterOn;
			mymod.Config.DefaultNpcBlacklisted = this.IsNpcFilterOn;
			
			mymod.Config.DefaultRecipeWhitelist = this.RecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultItemWhitelist = this.ItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultNpcWhitelist = this.NpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultNpcLootWhitelist = this.NpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );

			if( !mymod.SuppressAutoSaving ) {
				mymod.ConfigJson.SaveFile();
			}
		}

		public void ResetFiltersFromDefaults( NihilismMod mymod ) {
			this.IsItemFilterOn = mymod.Config.DefaultItemsBlacklisted;
			this.IsRecipeFilterOn = mymod.Config.DefaultRecipesBlacklisted;
			this.IsNpcLootFilterOn = mymod.Config.DefaultNpcLootBlacklisted;
			this.IsNpcFilterOn = mymod.Config.DefaultNpcBlacklisted;
			
			this.RecipeWhitelist = mymod.Config.DefaultRecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.ItemWhitelist = mymod.Config.DefaultItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.NpcWhitelist = mymod.Config.DefaultNpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.NpcLootWhitelist = mymod.Config.DefaultNpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
		}
	}
}
