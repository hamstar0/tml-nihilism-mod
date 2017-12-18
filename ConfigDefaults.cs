using HamstarHelpers.Utilities.Config;
using System;
using System.Collections.Generic;


namespace Nihilism {
	public class NihilismConfigData : ConfigurationDataBase {
		public readonly static Version ConfigVersion = new Version( 1, 3, 2 );
		public readonly static string ConfigFileName = "Nihilism Config.json";


		////////////////

		public string VersionSinceUpdate = "";

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

			if( vers_since < new Version(1, 3, 2) ) {
				if( this.RecipeWhitelist.Count == 1 && this.RecipeWhitelist.ContainsKey("Copper Pickaxe") ) {
					this.RecipeWhitelist = new_config.RecipeWhitelist;
				}
				if( this.ItemWhitelist.Count == 1 && this.ItemWhitelist.ContainsKey( "Copper Pickaxe" ) ) {
					this.ItemWhitelist = new_config.ItemWhitelist;
				}
				if( this.NpcWhitelist.Count == 1 && this.NpcWhitelist.ContainsKey( "Green Slime" ) ) {
					this.NpcWhitelist = new_config.NpcWhitelist;
				}
				if( this.NpcItemDropWhitelist.Count == 1 && this.NpcItemDropWhitelist.ContainsKey( "Green Slime" ) ) {
					this.NpcItemDropWhitelist = new_config.NpcItemDropWhitelist;
				}
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
