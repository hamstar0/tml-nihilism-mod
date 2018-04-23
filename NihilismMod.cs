using HamstarHelpers.TmlHelpers;
using HamstarHelpers.Utilities.Config;
using HamstarHelpers.Utilities.Messages;
using Microsoft.Xna.Framework.Graphics;
using Nihilism.Data;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;


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
			if( !NihilismMod.Instance.JsonConfig.LoadFile() ) {
				NihilismMod.Instance.JsonConfig.SaveFile();
			}
		}


		////////////////

		public JsonConfig<NihilismConfigData> JsonConfig { get; private set; }
		public NihilismConfigData Config { get; internal set; }

		public Texture2D DisabledItem { get; private set; }


		////////////////

		public NihilismMod() {
			this.Properties = new ModProperties() {
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
			
			this.JsonConfig = new JsonConfig<NihilismConfigData>( NihilismConfigData.ConfigFileName,
					ConfigurationDataBase.RelativePath, new NihilismConfigData() );
			this.Config = this.JsonConfig.Data;
		}

		////////////////

		public override void Load() {
			NihilismMod.Instance = this;
			
			if( Main.netMode != 2 ) {   // Not server
				this.DisabledItem = ModLoader.GetTexture( "Terraria/MapDeath" );
			}

			this.LoadConfig();

			TmlLoadHelpers.AddWorldLoadPromise( () => {
				if( Main.netMode != 1 ) { return; }

				var myworld = this.GetModWorld<NihilismWorld>();
				if( !myworld.Logic.IsCurrentWorldNihilated() ) {
					InboxMessages.SetMessage( "nihilism_init", "Enter the /nihilate command to begin Nihilism.", true );
				}
			} );
		}

		private void LoadConfig() {
			if( !this.JsonConfig.LoadFile() ) {
				this.JsonConfig.SaveFile();
				ErrorLogger.Log( "Nihilism config " + NihilismConfigData.ConfigVersion.ToString() + " created." );
			}

			if( this.Config.UpdateToLatestVersion() ) {
				ErrorLogger.Log( "Nihilism updated to " + NihilismConfigData.ConfigVersion.ToString() );
				this.JsonConfig.SaveFile();
			}
		}

		public override void Unload() {
			NihilismMod.Instance = null;
		}
	}
}
