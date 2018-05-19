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

		public override void OnLoad( bool success ) {
			this.ResetCachedPatterns();
		}
	}
}
