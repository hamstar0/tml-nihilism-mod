﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Libraries.TModLoader.Mods;
using ModLibsCore.Services.Debug.DataDumper;
using Nihilism.Data;


namespace Nihilism {
	partial class NihilismMod : Mod {
		public static NihilismMod Instance { get; private set; }


		////////////////

		public static string GithubUserName => "hamstar0";
		public static string GithubProjectName => "tml-nihilism-mod";



		////////////////

		internal Mod WingSlotMod = null;

		internal IList<(float, Action<bool>)> SyncOrWorldLoadActions = new List<(float, Action<bool>)>();


		////

		public Texture2D DisabledItemTex { get; private set; }

		public bool InstancedFilters { get; internal set; }



		////////////////

		public NihilismMod() {
			NihilismMod.Instance = this;
		}

		////////////////

		public override void Load() {
			if( Main.netMode != 2 ) {   // Not server
				this.DisabledItemTex = ModContent.GetTexture( "Terraria/MapDeath" );
			}

			this.WingSlotMod = ModLoader.GetMod( "WingSlot" );
			if( this.WingSlotMod == null ) {
				if( NihilismConfig.Instance.DebugModeInfo ) {
					LogLibraries.Alert( "Wing Mod not detected; ignoring wing slots..." );
				}
			} else {
				LogLibraries.Alert( "Wing Mod detected. Compatibility will be attempted." );
			}
		}

		public override void Unload() {
			NihilismMod.Instance = null;
		}


		public override void PostAddRecipes() {
			DataDumper.SetDumpSource( "NihilismShowFiltersForMouseItem", () => {
				if( Main.mouseItem == null || Main.mouseItem.IsAir ) {
					return "  No mouse item selected.";
				}

				var myworld = ModContent.GetInstance<NihilismWorld>();
				if( myworld.Logic == null ) {
					return "  Logic not loaded.";
				}

				if( !myworld.Logic.AreItemFiltersEnabled() ) {
					return "  Item filters not enabled.";
				}
				
				string name = ItemID.GetUniqueKey( Main.mouseItem );
				bool isEnabled, isBlackList, isGroup;
				isEnabled = myworld.Logic.DataAccess.IsItemEnabled( Main.mouseItem, out isBlackList, out isGroup );

				return "  Item " + name + " enabled? "+isEnabled+", blacklisted? " + isBlackList + ", is group? " + isGroup;
			} );
		}


		////////////////

		public override object Call( params object[] args ) {
			return ModBoilerplateLibraries.HandleModCall( typeof( NihilismAPI ), args );
		}


		////////////////

		public void RunSyncOrWorldLoadActions( bool isSync ) {
			foreach( (float priority, Action<bool> action) in this.SyncOrWorldLoadActions ) {
				action( isSync );
			}
		}
	}
}
