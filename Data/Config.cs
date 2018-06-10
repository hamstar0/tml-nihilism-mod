using HamstarHelpers.Utilities.Config;
using System;
using System.Collections.Generic;


namespace Nihilism.Data {
	public class NihilismConfigData : ConfigurationDataBase {
		public readonly static Version ConfigVersion = new Version( 2, 0, 0 );
		public readonly static string ConfigFileName = "Nihilism Config.json";


		////////////////

		public string VersionSinceUpdate = NihilismConfigData.ConfigVersion.ToString();

		public bool DebugModeInfo = false;

		public bool DefaultRecipesBlacklisted = true;
		public bool DefaultItemsBlacklisted = true;
		public bool DefaultNpcBlacklisted = true;
		public bool DefaultNpcLootBlacklisted = true;

		public ISet<string> DefaultRecipeWhitelist = new HashSet<string> { };
		public ISet<string> DefaultItemWhitelist = new HashSet<string> { };
		public ISet<string> DefaultNpcWhitelist = new HashSet<string> { };
		public ISet<string> DefaultNpcLootWhitelist = new HashSet<string> { };

		public bool EnableItemFilters = true;
		public bool EnableItemEquipsFilters = true;
		public bool EnableRecipeFilters = true;
		public bool EnableNpcFilters = true;
		public bool EnableNpcLootFilters = true;


		////////

		[Obsolete( "Not a useable setting", true )]
		public string _OLD_SETTINGS_BELOW_ = "";

		[Obsolete( "Use NihilismConfigData.DefaultRecipesBlacklisted", true )]
		public string DefaultRecipesBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultItemsBlacklisted", true )]
		public string DefaultItemsBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultNpcBlacklisted", true )]
		public string DefaultNpcBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultNpcLootBlacklisted", true )]
		public string DefaultNpcLootBlacklistPattern = "(.*?)";

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

		public override void OnLoad( bool success ) {
			if( !success ) {
				this.SetDefaults();
			}
		}


		public void SetDefaults() {
			this.DefaultItemWhitelist.Add( "Any Copper Or Tin Equipment" );
			this.DefaultRecipeWhitelist.Add( "Any Copper Or Tin Equipment" );
			this.DefaultNpcWhitelist.Add( "Any Slime" );
			this.DefaultNpcLootWhitelist.Add( "Blue Slime" );
		}


		public bool UpdateToLatestVersion() {
			var new_config = new NihilismConfigData();
			var vers_since = this.VersionSinceUpdate != "" ?
				new Version( this.VersionSinceUpdate ) :
				new Version();

			if( vers_since >= NihilismConfigData.ConfigVersion ) {
				return false;
			}

			if( vers_since < new Version(2, 0, 0) ) {
				this.SetDefaults();
			}

			this.VersionSinceUpdate = NihilismConfigData.ConfigVersion.ToString();

			return true;
		}
	}
}
