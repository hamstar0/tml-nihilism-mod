﻿using System;
using System.Collections.Generic;


namespace Nihilism {
	public class ConfigurationData {
		public readonly static Version CurrentVersion = new Version( 1, 0, 0 );


		public string VersionSinceUpdate = "";

		public bool Enabled = true;
		
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
			var new_config = new ConfigurationData();
			var vers_since = this.VersionSinceUpdate != "" ?
				new Version( this.VersionSinceUpdate ) :
				new Version();

			if( vers_since >= ConfigurationData.CurrentVersion ) {
				return false;
			}
			
			this.VersionSinceUpdate = ConfigurationData.CurrentVersion.ToString();

			return true;
		}
	}
}
