using HamstarHelpers.Utilities.Config;
using System;
using System.Collections.Generic;


namespace Nihilism {
	public class NihilismConfigData : ConfigurationDataBase {
		public readonly static Version ConfigVersion = new Version( 1, 3, 3 );
		public readonly static string ConfigFileName = "Nihilism Config.json";


		////////////////

		public string VersionSinceUpdate = NihilismConfigData.ConfigVersion.ToString();

		public bool Enabled = true;

		public bool RecipesBlacklistChecksFirst = false;
		public bool ItemsBlacklistChecksFirst = false;
		public bool NpcsBlacklistChecksFirst = false;
		public bool NpcItemDropsBlacklistChecksFirst = false;

		public string RecipesBlacklistPattern = "(.*?)";
		public string ItemsBlacklistPattern = "(.*?)";
		public string NpcsBlacklistPattern = "(.*?)";
		public string NpcItemDropsBlacklistPattern = "(.*?)";

		public IDictionary<string, bool> RecipeWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> ItemWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> NpcWhitelist = new Dictionary<string, bool> { };
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


		////////////////

		public void SetDefaults() {
			this.RecipeWhitelist["Copper Pickaxe"] = true;
			this.ItemWhitelist["Copper Pickaxe"] = true;
			this.NpcWhitelist["Green Slime"] = true;
			this.NpcItemDropWhitelist["Green Slime"] = true;
		}


		public override void OnLoad( bool success ) {
			NihilismLogic.ResetCachedPatterns();
		}
	}
}
