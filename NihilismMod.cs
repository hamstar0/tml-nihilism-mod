using HamstarHelpers.DebugHelpers;
using HamstarHelpers.Utilities.Config;
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
			if( NihilismMod.Instance.SuppressAutoSaving ) {
				Main.NewText( "Nihilism config settings auto saving suppressed." );
				return;
			}
			if( !NihilismMod.Instance.JsonConfig.LoadFile() ) {
				NihilismMod.Instance.JsonConfig.SaveFile();
			}
		}


		////////////////

		public JsonConfig<NihilismConfigData> JsonConfig { get; private set; }
		public NihilismConfigData Config { get { return this.JsonConfig.Data; } }

		public Texture2D DisabledItem { get; private set; }

		public bool SuppressAutoSaving { get; internal set; }


		////////////////

		public NihilismMod() {
			this.Properties = new ModProperties() {
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
			
			this.JsonConfig = new JsonConfig<NihilismConfigData>( NihilismConfigData.ConfigFileName,
					ConfigurationDataBase.RelativePath, new NihilismConfigData() );
		}

		////////////////

		public override void Load() {
			NihilismMod.Instance = this;
			
			if( Main.netMode != 2 ) {   // Not server
				this.DisabledItem = ModLoader.GetTexture( "Terraria/MapDeath" );
			}

			this.LoadConfig();
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


		////////////////

		public override object Call( params object[] args ) {
			if( args.Length == 0 ) { throw new Exception( "Undefined call type." ); }

			string call_type = args[0] as string;
			if( args == null ) { throw new Exception( "Invalid call type." ); }

			var new_args = new object[args.Length - 1];
			Array.Copy( args, 1, new_args, 0, args.Length - 1 );

			return NihilismAPI.Call( call_type, new_args );
		}
	}
}
