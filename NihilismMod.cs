using HamstarHelpers.MiscHelpers;
using HamstarHelpers.Utilities.Config;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;


namespace Nihilism {
    public class NihilismMod : Mod {
		public JsonConfig<ConfigurationData> Config { get; private set; }
		public Texture2D DisabledItem = null;

		public NihilismUI UI = null;
		private int LastSeenScreenWidth = -1;
		private int LastSeenScreenHeight = -1;


		public NihilismMod() {
			this.Properties = new ModProperties() {
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};

			string filename = "Nihilism Config.json";
			this.Config = new JsonConfig<ConfigurationData>( filename, "Mod Configs", new ConfigurationData() );
		}

		public override void Load() {
			if( Main.netMode != 2 ) {   // Not server
				this.DisabledItem = ModLoader.GetTexture( "Terraria/MapDeath" );
			}

			this.LoadConfig();

			if( !Main.dedServ ) {
				this.UI = new NihilismUI();
			}
		}

		private void LoadConfig() {
			try {
				if( !this.Config.LoadFile() ) {
					this.Config.SaveFile();
				}
			} catch( Exception e ) {
				DebugHelpers.Log( e.Message );
				this.Config.SaveFile();
			}

			if( this.Config.Data.UpdateToLatestVersion() ) {
				ErrorLogger.Log( "Nihilism updated to " + ConfigurationData.CurrentVersion.ToString() );
				this.Config.SaveFile();
			}
		}

		public override void PostSetupContent() {
			if( !Main.dedServ ) {
				this.UI.PostSetupContent();
			}
		}


		////////////////

		public override void HandlePacket( BinaryReader reader, int whoAmI ) {
			NihilismNetProtocol.RouteReceivedPackets( this, reader );
		}

		////////////////

		public override void ModifyInterfaceLayers( List<GameInterfaceLayer> layers ) {
			var modworld = this.GetModWorld<NihilismWorld>();
			if( !this.Config.Data.Enabled ) { return; }

			if( !modworld.Logic.IsInitialized ) {
				int idx = layers.FindIndex( layer => layer.Name.Equals( "Vanilla: Mouse Text" ) );
				if( idx != -1 ) {
					var interface_layer = new LegacyGameInterfaceLayer( "Nihilism: Activator",
						delegate {
							if( this.LastSeenScreenWidth != Main.screenWidth || this.LastSeenScreenHeight != Main.screenHeight ) {
								this.LastSeenScreenWidth = Main.screenWidth;
								this.LastSeenScreenHeight = Main.screenHeight;
								this.UI.RecalculateBackend();
							}

							this.UI.CheckTogglerMouseInteraction();
							this.UI.UpdateBackend( Main._drawInterfaceGameTime );

							this.UI.Draw( Main.spriteBatch );
							this.UI.DrawToggler( Main.spriteBatch );

							return true;
						}, InterfaceScaleType.None );
					layers.Insert( idx, interface_layer );
				}
			}
		}
	}
}
