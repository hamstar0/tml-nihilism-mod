﻿using HamstarHelpers.Components.Config;
using HamstarHelpers.Helpers.DebugHelpers;
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
		public NihilismConfigData Config { get { return this.ConfigJson.Data; } }


		public Texture2D DisabledItem { get; private set; }

		public bool SuppressAutoSaving { get; internal set; }

		private bool HasUpdated = false;

		internal Mod WingSlotMod = null;


		////////////////

		public NihilismMod() {
			this.Properties = new ModProperties() {
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};

			this.ConfigJson = new JsonConfig<NihilismConfigData>( NihilismConfigData.ConfigFileName,
					ConfigurationDataBase.RelativePath, new NihilismConfigData() );
		}

		////////////////

		public override void Load() {
			NihilismMod.Instance = this;

			if( Main.netMode != 2 ) {   // Not server
				this.DisabledItem = ModLoader.GetTexture( "Terraria/MapDeath" );
			}

			EntityGroups.Enable();

			this.LoadConfig();
			
			this.WingSlotMod = ModLoader.GetMod( "WingSlot" );
			if( this.WingSlotMod == null ) {
				if( this.Config.DebugModeInfo ) {
					LogHelpers.Log( "NihilismMod.Load - Wing Mod not detected; ignoring wing slots..." );
				}
			} else {
				LogHelpers.Log( "NihilismMod.Load - Wing Mod detected. Compatibility will be attempted." );
			}
		}

		private void LoadConfig() {
			if( !this.ConfigJson.LoadFile() ) {
				this.ConfigJson.SaveFile();
				ErrorLogger.Log( "Nihilism config " + NihilismConfigData.ConfigVersion.ToString() + " created." );
			}

			this.HasUpdated = this.Config.UpdateToLatestVersion();

			if( this.HasUpdated ) {
				ErrorLogger.Log( "Nihilism updated to " + NihilismConfigData.ConfigVersion.ToString() );
				this.ConfigJson.SaveFile();
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
			if( args.Length == 0 ) { throw new Exception( "Undefined call type." ); }

			string call_type = args[0] as string;
			if( args == null ) { throw new Exception( "Invalid call type." ); }

			var new_args = new object[args.Length - 1];
			Array.Copy( args, 1, new_args, 0, args.Length - 1 );

			return NihilismAPI.Call( call_type, new_args );
		}
	}
}
