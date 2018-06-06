using HamstarHelpers.Utilities.Config;
using System;
using System.Collections.Generic;


namespace Nihilism.Data {
	public class NihilismConfigData : ConfigurationDataBase {
		public readonly static Version ConfigVersion = new Version( 1, 5, 9 );
		public readonly static string ConfigFileName = "Nihilism Config.json";


		////////////////

		public string VersionSinceUpdate = NihilismConfigData.ConfigVersion.ToString();

		public bool DebugModeInfo = false;
		
		public string DefaultRecipesBlacklistPattern = "(.*?)";
		public string DefaultItemsBlacklistPattern = "(.*?)";
		public string DefaultNpcBlacklistPattern = "(.*?)";
		public string DefaultNpcLootBlacklistPattern = "(.*?)";

		public IDictionary<string, bool> DefaultRecipeWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> DefaultItemWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> DefaultNpcWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> DefaultNpcLootWhitelist = new Dictionary<string, bool> { };

		public bool EnableItemFilters = true;
		public bool EnableItemEquipsFilters = true;
		public bool EnableRecipeFilters = true;
		public bool EnableNpcFilters = true;
		public bool EnableNpcLootFilters = true;


		////////

		[Obsolete( "Not a useable setting", true )]
		public string _OLD_SETTINGS_BELOW_ = "";

		[Obsolete( "Use NihilismFilterData.RecipesBlacklistChecksFirst", true )]
		public bool RecipesBlacklistChecksFirst = false;
		[Obsolete( "Use NihilismFilterData.ItemsBlacklistChecksFirst", true )]
		public bool ItemsBlacklistChecksFirst = false;
		[Obsolete( "Use NihilismFilterData.NpcsBlacklistChecksFirst", true )]
		public bool NpcsBlacklistChecksFirst = false;
		[Obsolete( "Use NihilismFilterData.NpcItemDropsBlacklistChecksFirst", true )]
		public bool NpcItemDropsBlacklistChecksFirst = false;

		[Obsolete( "Use NihilismConfigData.DefaultRecipeWhitelist or NihilismFilterData.RecipesBlacklistPattern", true )]
		public string RecipesBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultItemWhitelist or NihilismFilterData.ItemsBlacklistPattern", true )]
		public string ItemsBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultNpcWhitelist or NihilismFilterData.NpcsBlacklistPattern", true )]
		public string NpcsBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultNpcLootWhitelist or NihilismFilterData.NpcItemDropsBlacklistPattern", true )]
		public string NpcItemDropsBlacklistPattern = "(.*?)";

		[Obsolete( "Use NihilismConfigData.DefaultRecipeWhitelist or NihilismFilterData.RecipeWhitelist", true )]
		public IDictionary<string, bool> RecipeWhitelist = new Dictionary<string, bool> { };
		[Obsolete( "Use NihilismConfigData.DefaultItemWhitelist or NihilismFilterData.ItemWhitelist", true )]
		public IDictionary<string, bool> ItemWhitelist = new Dictionary<string, bool> { };
		[Obsolete( "Use NihilismConfigData.DefaultNpcWhitelist or NihilismFilterData.NpcWhitelist", true )]
		public IDictionary<string, bool> NpcWhitelist = new Dictionary<string, bool> { };
		[Obsolete( "Use NihilismConfigData.DefaultNpcItemDropWhitelist or NihilismFilterData.NpcItemDropWhitelist", true )]
		public IDictionary<string, bool> NpcItemDropWhitelist = new Dictionary<string, bool> { };


		////////////////

		public bool UpdateToLatestVersion() {
			var new_config = new NihilismConfigData();
			var vers_since = this.VersionSinceUpdate != "" ?
				new Version( this.VersionSinceUpdate ) :
				new Version();

			if( vers_since >= NihilismConfigData.ConfigVersion ) {
				return false;
			}

			this.VersionSinceUpdate = NihilismConfigData.ConfigVersion.ToString();

			return true;
		}
	}
}
