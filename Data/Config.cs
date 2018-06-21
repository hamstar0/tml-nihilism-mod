using HamstarHelpers.Components.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria.ModLoader;


namespace Nihilism.Data {
	public class NihilismConfigMetaData {
		public readonly static Version ConfigVersion = new Version( 2, 1, 0 );
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

		[OnDeserialized]
		internal void OnDeserializedMethod( StreamingContext context ) {
			var vers_since = this.VersionSinceUpdate != "" ?
				new Version( this.VersionSinceUpdate ) :
				new Version();

			if( vers_since < this.mod.Version ) {
				this.VersionSinceUpdate = NihilismConfigMetaData.ConfigVersion.ToString();
			}
			if( this.DefaultItemBlacklist == null ) {
				this.DefaultItemBlacklist = new HashSet<string> { };
			}
			if( this.DefaultRecipeBlacklist == null ) {
				this.DefaultRecipeBlacklist = new HashSet<string> { };
			}
			if( this.DefaultNpcBlacklist == null ) {
				this.DefaultNpcBlacklist = new HashSet<string> { };
			}
			if( this.DefaultNpcLootBlacklist == null ) {
				this.DefaultNpcLootBlacklist = new HashSet<string> { };
			}
			if( this.DefaultItemWhitelist == null ) {
				this.DefaultItemWhitelist = new HashSet<string> { };
			}
			if( this.DefaultRecipeWhitelist == null ) {
				this.DefaultRecipeWhitelist = new HashSet<string> { };
			}
			if( this.DefaultNpcWhitelist == null ) {
				this.DefaultNpcWhitelist = new HashSet<string> { };
			}
			if( this.DefaultNpcLootWhitelist == null ) {
				this.DefaultNpcLootWhitelist = new HashSet<string> { };
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


		////////////////

		[DefaultValue( "" )]
		public string VersionSinceUpdate;

		[DefaultValue( false )]
		public bool DebugModeInfo;

		public ISet<string> DefaultItemBlacklist;
		public ISet<string> DefaultRecipeBlacklist;
		public ISet<string> DefaultNpcBlacklist;
		public ISet<string> DefaultNpcLootBlacklist;

		public ISet<string> DefaultItemWhitelist;
		public ISet<string> DefaultRecipeWhitelist;
		public ISet<string> DefaultNpcWhitelist;
		public ISet<string> DefaultNpcLootWhitelist;

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
			this.DefaultItemBlacklist.Add( "Any Equipment" );
			this.DefaultRecipeBlacklist.Add( "Any Equipment" );
			this.DefaultNpcBlacklist.Add( "Any Hostile Npc" );
			this.DefaultNpcLootBlacklist.Add( "Any Hostile Npc" );

			this.DefaultItemWhitelist.Add( "Any Copper Or Tin Equipment" );
			this.DefaultRecipeWhitelist.Add( "Any Copper Or Tin Equipment" );
			this.DefaultNpcWhitelist.Add( "Any Slime" );
			this.DefaultNpcLootWhitelist.Add( "Blue Slime" );
		}
	}
}
