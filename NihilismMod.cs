using HamstarHelpers.MiscHelpers;
using HamstarHelpers.Utilities.Config;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
    public class NihilismMod : Mod {
		public JsonConfig<ConfigurationData> Config { get; private set; }
		public Texture2D DisabledItem = null;


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


		////////////////

		public override void HandlePacket( BinaryReader reader, int whoAmI ) {
			NihilismNetProtocol.RouteReceivedPackets( this, reader );
		}
	}
}
