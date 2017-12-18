using HamstarHelpers.Utilities.Config;
using Microsoft.Xna.Framework.Graphics;
using Nihilism.NetProtocol;
using Nihilism.UI;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;


namespace Nihilism {
    class NihilismMod : Mod {
		public static NihilismMod Instance { get; private set; }

		public static string GithubUserName { get { return "hamstar0"; } }
		public static string GithubProjectName { get { return "tml-nihilism-mod"; } }

		public static string ConfigFileRelativePath {
			get { return ConfigurationDataBase.RelativePath + Path.DirectorySeparatorChar + NihilismConfigData.ConfigFileName; }
		}
		public static void ReloadConfigFromFile() {
			if( Main.netMode != 0 ) {
				throw new Exception( "Cannot reload configs outside of single player." );
			}
			if( !NihilismMod.Instance.Config.LoadFile() ) {
				NihilismMod.Instance.Config.SaveFile();
			}
		}


		////////////////

		public JsonConfig<NihilismConfigData> Config { get; private set; }
		public Texture2D DisabledItem = null;

		public ControlPanelUI ControlPanel = null;
		private int LastSeenScreenWidth = -1;
		private int LastSeenScreenHeight = -1;


		////////////////

		public NihilismMod() {
			this.Properties = new ModProperties() {
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
			
			this.Config = new JsonConfig<NihilismConfigData>( NihilismConfigData.ConfigFileName,
				ConfigurationDataBase.RelativePath, new NihilismConfigData() );
		}

		////////////////

		public override void Load() {
			NihilismMod.Instance = this;

			var hamhelpmod = ModLoader.GetMod( "HamstarHelpers" );
			var min_ver = new Version( 1, 2, 3, 1 );
			if( hamhelpmod.Version < min_ver ) {
				throw new Exception( "Hamstar Helpers must be version " + min_ver.ToString() + " or greater." );
			}

			if( Main.netMode != 2 ) {   // Not server
				this.DisabledItem = ModLoader.GetTexture( "Terraria/MapDeath" );
			}

			this.LoadConfig();
			
			this.ControlPanel = new ControlPanelUI();
		}

		private void LoadConfig() {
			if( !this.Config.LoadFile() ) {
				this.Config.Data.SetDefaults();
				this.Config.SaveFile();
				ErrorLogger.Log( "Nihilism config " + NihilismConfigData.ConfigVersion.ToString() + " created (Mod.Load())." );
			}

			if( this.Config.Data.UpdateToLatestVersion() ) {
				ErrorLogger.Log( "Nihilism updated to " + NihilismConfigData.ConfigVersion.ToString() );
				this.Config.SaveFile();
			}
		}

		public override void Unload() {
			NihilismMod.Instance = null;
		}

		////////////////


		public override void HandlePacket( BinaryReader reader, int player_who ) {
			if( Main.netMode == 1 ) {   // Client
				ClientPacketHandlers.HandlePacket( this, reader );
			} else if( Main.netMode == 2 ) {    // Server
				ServerPacketHandlers.HandlePacket( this, reader, player_who );
			}
		}

		////////////////

		public override void ModifyInterfaceLayers( List<GameInterfaceLayer> layers ) {
			var modworld = this.GetModWorld<NihilismWorld>();
			if( !this.Config.Data.Enabled ) { return; }

			if( !modworld.Logic.IsInitialized ) {
				int idx = layers.FindIndex( layer => layer.Name.Equals( "Vanilla: Mouse Text" ) );
				if( idx != -1 ) {
					GameInterfaceDrawMethod draw_method = delegate {
						if( this.LastSeenScreenWidth != Main.screenWidth || this.LastSeenScreenHeight != Main.screenHeight ) {
							this.LastSeenScreenWidth = Main.screenWidth;
							this.LastSeenScreenHeight = Main.screenHeight;
							this.ControlPanel.RecalculateBackend();
						}

						this.ControlPanel.UpdateInteractivity( Main._drawInterfaceGameTime );
						this.ControlPanel.UpdateDialog();
						this.ControlPanel.UpdateToggler();

						this.ControlPanel.Draw( Main.spriteBatch );
						this.ControlPanel.DrawToggler( Main.spriteBatch );

						return true;
					};

					var interface_layer = new LegacyGameInterfaceLayer( "Nihilism: Activator", draw_method,
						InterfaceScaleType.UI );

					layers.Insert( idx, interface_layer );
				}
			}
		}
	}
}
