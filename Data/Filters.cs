using HamstarHelpers.Utilities.Config;
using System.Collections.Generic;
using System.Linq;


namespace Nihilism.Data {
	class NihilismFilterData : ConfigurationDataBase {
		public bool IsActive = false;

		public bool RecipesBlacklistChecksFirst = false;
		public bool ItemsBlacklistChecksFirst = false;
		public bool NpcsBlacklistChecksFirst = false;
		public bool NpcLootBlacklistChecksFirst = false;

		public string RecipesBlacklistPattern;
		public string ItemsBlacklistPattern;
		public string NpcBlacklistPattern;
		public string NpcLootBlacklistPattern;

		public IDictionary<string, bool> RecipeWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> ItemWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> NpcWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> NpcLootWhitelist = new Dictionary<string, bool> { };



		////////////////

		public NihilismFilterData() {
			var mymod = NihilismMod.Instance;

			this.RecipesBlacklistPattern = mymod.Config.DefaultRecipesBlacklistPattern;
			this.ItemsBlacklistPattern = mymod.Config.DefaultItemsBlacklistPattern;
			this.NpcBlacklistPattern = mymod.Config.DefaultNpcBlacklistPattern;
			this.NpcLootBlacklistPattern = mymod.Config.DefaultNpcLootBlacklistPattern;
			
			this.RecipeWhitelist = mymod.Config.DefaultRecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.ItemWhitelist = mymod.Config.DefaultItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.NpcWhitelist = mymod.Config.DefaultNpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.NpcLootWhitelist = mymod.Config.DefaultNpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
		}


		////////////////
		
		public void SetCurrentFiltersAsDefaults( NihilismMod mymod ) {
			mymod.Config.DefaultItemsBlacklistPattern = this.ItemsBlacklistPattern;
			mymod.Config.DefaultRecipesBlacklistPattern = this.RecipesBlacklistPattern;
			mymod.Config.DefaultNpcLootBlacklistPattern = this.NpcLootBlacklistPattern;
			mymod.Config.DefaultNpcBlacklistPattern = this.NpcBlacklistPattern;
			
			mymod.Config.DefaultRecipeWhitelist = this.RecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultItemWhitelist = this.ItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultNpcWhitelist = this.NpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			mymod.Config.DefaultNpcLootWhitelist = this.NpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );

			if( !mymod.SuppressAutoSaving ) {
				mymod.JsonConfig.SaveFile();
			}
		}

		public void ResetFiltersFromDefaults( NihilismMod mymod ) {
			this.ItemsBlacklistPattern = mymod.Config.DefaultItemsBlacklistPattern;
			this.RecipesBlacklistPattern = mymod.Config.DefaultRecipesBlacklistPattern;
			this.NpcLootBlacklistPattern = mymod.Config.DefaultNpcLootBlacklistPattern;
			this.NpcBlacklistPattern = mymod.Config.DefaultNpcBlacklistPattern;
			
			this.RecipeWhitelist = mymod.Config.DefaultRecipeWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.ItemWhitelist = mymod.Config.DefaultItemWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.NpcWhitelist = mymod.Config.DefaultNpcWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
			this.NpcLootWhitelist = mymod.Config.DefaultNpcLootWhitelist.ToDictionary( entry => entry.Key, entry => entry.Value );
		}
	}
}
