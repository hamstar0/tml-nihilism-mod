using HamstarHelpers.Components.Config;
using HamstarHelpers.Services.EntityGroups;
using HamstarHelpers.Services.Messages;
using Microsoft.Xna.Framework.Graphics;
using Nihilism.Data;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismMod : Mod {
		public static string GithubUserName => "hamstar0";
		public static string GithubProjectName => "tml-nihilism-mod";

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
			if( !NihilismMod.Instance.ConfigJson.LoadFile() ) {
				NihilismMod.Instance.ConfigJson.SaveFile();
			}
		}

		public static void ResetConfigFromDefaults() {
			if( Main.netMode != 0 ) {
				throw new Exception( "Cannot reset to default configs outside of single player." );
			}

			var configData = new NihilismConfigData();
			configData.SetDefaults();

			NihilismMod.Instance.ConfigJson.SetData( configData );
			NihilismMod.Instance.ConfigJson.SaveFile();
		}
	}
}
