using System;
using System.Collections.Generic;


namespace Nihilism {
	public class NihilismConfigData {
		public readonly static Version ConfigVersion = new Version( 1, 2, 0 );
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

		public IDictionary<string, bool> RecipeWhitelist = new Dictionary<string, bool> {
			{ "Copper Pickaxe", true }
		};
		public IDictionary<string, bool> ItemWhitelist = new Dictionary<string, bool> {
			{ "Copper Pickaxe", true }
		};
		public IDictionary<string, bool> NpcWhitelist = new Dictionary<string, bool> {
			{ "Green Slime", true }
		};
		public IDictionary<string, bool> NpcItemDropWhitelist = new Dictionary<string, bool> {
			{ "Green Slime", true }
		};



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
