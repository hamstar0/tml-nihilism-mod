using HamstarHelpers.Components.Config;
using System;
using System.Collections.Generic;


namespace Nihilism.Data {
	public class NihilismConfigData : ConfigurationDataBase {
		public readonly static Version ConfigVersion = new Version( 2, 1, 2, 1 );
		public readonly static string ConfigFileName = "Nihilism Config.json";


		////////////////

		public string VersionSinceUpdate = NihilismConfigData.ConfigVersion.ToString();

		public bool DebugModeInfo = false;

		public ISet<string> DefaultItemBlacklist = new HashSet<string> { };
		public ISet<string> DefaultRecipeBlacklist = new HashSet<string> { };
		public ISet<string> DefaultNpcBlacklist = new HashSet<string> { };
		public ISet<string> DefaultNpcLootBlacklist = new HashSet<string> { };

		public ISet<string> DefaultItemWhitelist = new HashSet<string> { };
		public ISet<string> DefaultRecipeWhitelist = new HashSet<string> { };
		public ISet<string> DefaultNpcWhitelist = new HashSet<string> { };
		public ISet<string> DefaultNpcLootWhitelist = new HashSet<string> { };

		public bool EnableItemFilters = true;
		public bool EnableItemEquipsFilters = true;
		public bool EnableRecipeFilters = true;
		public bool EnableNpcFilters = true;
		public bool EnableNpcLootFilters = true;


		////////////////

		public override void OnLoad( bool success ) {
			if( !success ) {
				this.SetDefaults();
			}
		}

		
		public void SetDefaults() {
			this.DefaultItemBlacklist.Add( "Any Equipment" );
			this.DefaultRecipeBlacklist.Add( "Any Equipment" );
			this.DefaultNpcBlacklist.Add( "Any Hostile NPC" );
			this.DefaultNpcLootBlacklist.Add( "Any Hostile NPC" );

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
			
			if( vers_since < new Version(2, 1, 2, 2) ) {
				if( this.DefaultItemBlacklist.Count == 1 &&
						this.DefaultRecipeBlacklist.Count == 1 &&
						this.DefaultNpcBlacklist.Count == 1 &&
						this.DefaultNpcLootBlacklist.Count == 1 &&
						this.DefaultItemWhitelist.Count == 1 &&
						this.DefaultRecipeWhitelist.Count == 1 &&
						this.DefaultNpcWhitelist.Count == 1 &&
						this.DefaultNpcLootWhitelist.Count == 1 ) {
					this.DefaultItemBlacklist.Clear();
					this.DefaultRecipeBlacklist.Clear();
					this.DefaultNpcBlacklist.Clear();
					this.DefaultNpcLootBlacklist.Clear();

					this.DefaultItemWhitelist.Clear();
					this.DefaultRecipeWhitelist.Clear();
					this.DefaultNpcWhitelist.Clear();
					this.DefaultNpcLootWhitelist.Clear();

					this.SetDefaults();
				}
			}

			this.VersionSinceUpdate = NihilismConfigData.ConfigVersion.ToString();

			return true;
		}
	}
}
