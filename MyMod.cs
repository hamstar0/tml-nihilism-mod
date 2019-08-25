using HamstarHelpers.Classes.Errors;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.Items;
using HamstarHelpers.Helpers.TModLoader.Mods;
using HamstarHelpers.Services.Debug.DataDumper;
using HamstarHelpers.Services.EntityGroups;
using Microsoft.Xna.Framework.Graphics;
using Nihilism.Data;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismMod : Mod {
		public static NihilismMod Instance { get; private set; }



		////////////////

		public NihilismConfig Config => this.GetConfig<NihilismConfig>();


		public Texture2D DisabledItemTex { get; private set; }

		public bool InstancedFilters { get; internal set; }

		////

		internal Mod WingSlotMod = null;



		////////////////

		public NihilismMod() {
			NihilismMod.Instance = this;
		}

		////////////////

		public override void Load() {
			if( Main.netMode != 2 ) {   // Not server
				this.DisabledItemTex = ModContent.GetTexture( "Terraria/MapDeath" );
			}

			EntityGroups.Enable();

			this.WingSlotMod = ModLoader.GetMod( "WingSlot" );
			if( this.WingSlotMod == null ) {
				if( this.Config.DebugModeInfo ) {
					LogHelpers.Alert( "Wing Mod not detected; ignoring wing slots..." );
				}
			} else {
				LogHelpers.Alert( "Wing Mod detected. Compatibility will be attempted." );
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

				var myworld = this.GetModWorld<NihilismWorld>();
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
			return ModBoilerplateHelpers.HandleModCall( typeof( NihilismAPI ), args );
		}
	}
}
