using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace Nihilism.Data {
	public class NihilismConfigMetaData {
		public readonly static Version ConfigVersion = new Version( 3, 0, 0 );
		public readonly static string ConfigFileName = "Nihilism Config.json";
	}



	[Label( "Game Settings" )]
	public class NihilismConfigData : ModConfig {
		public override MultiplayerSyncMode Mode {
			get { return MultiplayerSyncMode.ServerDictates; }
		}

		public override void PostAutoLoad() {
			var mymod = (NihilismMod)this.mod;
			mymod.ServerConfig = this;
		}


		////////////////

		[DefaultValue( "" )]
		public string VersionSinceUpdate;	// Would like this to be read-only/programmatically editable only

		[DefaultValue( false )]
		public bool DebugModeInfo;


		private JSONItem SharedPicker;
		
		public JSONItem DefaultItemBlacklistPicker {
			get { return this.SharedPicker; }
			set {
				if( value != null && NihilismMod.Instance != null ) {
					this.DefaultItemBlacklist.Add( value.name );
					NihilismMod.Instance.ServerConfig.DefaultItemBlacklist.Add( value.name );
				}
			}
		}
		public JSONItem DefaultRecipeBlacklistPicker {
			get { return this.SharedPicker; }
			set {
				if( value != null && NihilismMod.Instance != null ) {
					this.DefaultRecipeBlacklist.Add( value.name );
					NihilismMod.Instance.ServerConfig.DefaultRecipeBlacklist.Add( value.name );
				}
			}
		}
		public JSONItem DefaultNpcBlacklistPicker {
			get { return this.SharedPicker; }
			set {
				if( value != null && NihilismMod.Instance != null ) {
					this.DefaultNpcBlacklist.Add( value.name );
					NihilismMod.Instance.ServerConfig.DefaultNpcBlacklist.Add( value.name );
				}
			}
		}
		public JSONItem DefaultNpcLootBlacklistPicker {
			get { return this.SharedPicker; }
			set {
				if( value != null && NihilismMod.Instance != null ) {
					this.DefaultNpcLootBlacklist.Add( value.name );
					NihilismMod.Instance.ServerConfig.DefaultNpcLootBlacklist.Add( value.name );
				}
			}
		}
		
		public JSONItem DefaultItemWhitelistPicker {
			get { return this.SharedPicker; }
			set {
				if( value != null && NihilismMod.Instance != null ) {
					this.DefaultItemWhitelist.Add( value.name );
					NihilismMod.Instance.ServerConfig.DefaultItemWhitelist.Add( value.name );
				}
			}
		}
		public JSONItem DefaultRecipeWhitelistPicker {
			get { return this.SharedPicker; }
			set {
				if( value != null && NihilismMod.Instance != null ) {
					this.DefaultRecipeWhitelist.Add( value.name );
					NihilismMod.Instance.ServerConfig.DefaultRecipeWhitelist.Add( value.name );
				}
			}
		}
		public JSONItem DefaultNpcWhitelistPicker {
			get { return this.SharedPicker; }
			set {
				if( value != null && NihilismMod.Instance != null ) {
					this.DefaultNpcWhitelist.Add( value.name );
					NihilismMod.Instance.ServerConfig.DefaultNpcWhitelist.Add( value.name );
				}
			}
		}
		public JSONItem DefaultNpcLootWhitelistPicker {
			get { return this.SharedPicker; }
			set {
				if( value != null && NihilismMod.Instance != null ) {
					this.DefaultNpcLootWhitelist.Add( value.name );
					NihilismMod.Instance.ServerConfig.DefaultNpcLootWhitelist.Add( value.name );
				}
			}
		}


		public HashSet<string> DefaultItemBlacklist = null;
		public HashSet<string> DefaultRecipeBlacklist = null;
		public HashSet<string> DefaultNpcBlacklist = null;
		public HashSet<string> DefaultNpcLootBlacklist = null;

		public HashSet<string> DefaultItemWhitelist = null;
		public HashSet<string> DefaultRecipeWhitelist = null;
		public HashSet<string> DefaultNpcWhitelist = null;
		public HashSet<string> DefaultNpcLootWhitelist = null;


		[DefaultValue( true )]
		public bool EnableItemFilters = true;
		[DefaultValue( true )]
		public bool EnableItemEquipsFilters = true;
		[DefaultValue( true )]
		public bool EnableRecipeFilters = true;
		[DefaultValue( true )]
		public bool EnableNpcFilters = true;
		[DefaultValue( true )]
		public bool EnableNpcLootFilters = true;



		////////////////
		
		public void SetDefaults() {
			this.SharedPicker = new JSONItem();

			this.DefaultItemBlacklist = new HashSet<string> { "Any Equipment" };
			this.DefaultRecipeBlacklist = new HashSet<string> { "Any Equipment" };
			this.DefaultNpcBlacklist = new HashSet<string> { "Any Hostile Npc" };
			this.DefaultNpcLootBlacklist = new HashSet<string> { "Any Hostile Npc" };

			this.DefaultItemWhitelist = new HashSet<string> { "Any Copper Or Tin Equipment" };
			this.DefaultRecipeWhitelist = new HashSet<string> { "Any Copper Or Tin Equipment" };
			this.DefaultNpcWhitelist = new HashSet<string> { "Any Slime" };
			this.DefaultNpcLootWhitelist = new HashSet<string> { "Blue Slime" };
		}


		////////////////

		[OnDeserialized]
		internal void OnDeserializedMethod( StreamingContext context ) {
			var vers_since = this.VersionSinceUpdate != "" ?
				new Version( this.VersionSinceUpdate ) :
				new Version();

			if( vers_since < this.mod.Version ) {
				this.VersionSinceUpdate = NihilismConfigMetaData.ConfigVersion.ToString();
			}

			this.SetDefaults();
		}

		public override ModConfig Clone() {
			var clone = (NihilismConfigData)base.Clone();
			clone.DefaultItemBlacklist = new HashSet<string>( this.DefaultItemBlacklist );
			clone.DefaultRecipeBlacklist = new HashSet<string>( this.DefaultRecipeBlacklist );
			clone.DefaultNpcBlacklist = new HashSet<string>( this.DefaultNpcBlacklist );
			clone.DefaultNpcLootBlacklist = new HashSet<string>( this.DefaultNpcLootBlacklist );
			clone.DefaultItemWhitelist = new HashSet<string>( this.DefaultItemWhitelist );
			clone.DefaultRecipeWhitelist = new HashSet<string>( this.DefaultRecipeWhitelist );
			clone.DefaultNpcWhitelist = new HashSet<string>( this.DefaultNpcWhitelist );
			clone.DefaultNpcLootWhitelist = new HashSet<string>( this.DefaultNpcLootWhitelist );
			return clone;
		}
	}
}
