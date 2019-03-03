using HamstarHelpers.Components.Config;
using HamstarHelpers.Components.Errors;
using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.DotNetHelpers;
using HamstarHelpers.Helpers.TmlHelpers;
using HamstarHelpers.Helpers.TmlHelpers.ModHelpers;
using HamstarHelpers.Services.EntityGroups;
using HamstarHelpers.Services.Messages;
using Microsoft.Xna.Framework.Graphics;
using Nihilism.Data;
using System;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismMod : Mod {
		public static NihilismMod Instance { get; private set; }



		////////////////

		public JsonConfig<NihilismConfigData> ConfigJson { get; private set; }
		public NihilismConfigData Config => this.ConfigJson.Data;


		public Texture2D DisabledItem { get; private set; }

		public bool SuppressAutoSaving { get; internal set; }

		private bool HasUpdated = false;

		internal Mod WingSlotMod = null;



		////////////////

		public NihilismMod() {
			this.ConfigJson = new JsonConfig<NihilismConfigData>( NihilismConfigData.ConfigFileName,
					ConfigurationDataBase.RelativePath, new NihilismConfigData() );
		}

		////////////////

		public override void Load() {
			string depErr = TmlHelpers.ReportBadDependencyMods( this );
			if( depErr != null ) { throw new HamstarException( depErr ); }

			NihilismMod.Instance = this;

			if( Main.netMode != 2 ) {   // Not server
				this.DisabledItem = ModLoader.GetTexture( "Terraria/MapDeath" );
			}

			EntityGroups.Enable();

			this.LoadConfig();
			
			this.WingSlotMod = ModLoader.GetMod( "WingSlot" );
			if( this.WingSlotMod == null ) {
				if( this.Config.DebugModeInfo ) {
					LogHelpers.Alert( "Wing Mod not detected; ignoring wing slots..." );
				}
			} else {
				LogHelpers.Alert( "Wing Mod detected. Compatibility will be attempted." );
			}
		}

		private void LoadConfig() {
			if( !this.ConfigJson.LoadFile() ) {
				LogHelpers.Alert( "Creating rewards configs anew..." );
				this.ConfigJson.SaveFile();
			}

			if( this.Config.CanUpdateVersion() ) {
				this.Config.UpdateToLatestVersion();
				LogHelpers.Alert( "Nihilism settings updated to " + this.Version.ToString() );

				this.ConfigJson.SaveFile();
				this.HasUpdated = true;
			}
		}

		public override void Unload() {
			NihilismMod.Instance = null;
		}


		public override void PostAddRecipes() {
			if( this.HasUpdated && this.Version == new Version( 1, 5, 9 ) ) {
				InboxMessages.SetMessage( "nihilism_update", "A version update has put your world data into a new file. You may need to manually copy this (see Documents/My Games/Terraria/ModLoader/Mod Specific Data/Nihilism).", true );
			}
		}


		////////////////

		public override object Call( params object[] args ) {
			return ModBoilerplateHelpers.HandleModCall( typeof( NihilismAPI ), args );
		}
	}
}
