using HamstarHelpers.Utilities.Config;
using Nihilism.Logic;
using System;


namespace Nihilism.Data {
	public class NihilismConfigData : ConfigurationDataBase {
		public readonly static Version ConfigVersion = new Version( 2, 0, 0 );
		public readonly static string ConfigFileName = "Nihilism Config.json";


		////////////////

		public string VersionSinceUpdate = NihilismConfigData.ConfigVersion.ToString();



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
		
		public override void OnLoad( bool success ) {
			NihilismLogic.ResetCachedPatterns();
		}
	}
}
