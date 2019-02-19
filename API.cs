using HamstarHelpers.Components.Errors;
using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.TmlHelpers;
using Nihilism.Data;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static NihilismConfigData GetModSettings() {
			return NihilismMod.Instance.Config;
		}

		public static void SaveModSettingsChanges() {
			NihilismMod.Instance.ConfigJson.SaveFile();
		}


		////////////////

		public static bool NihilateCurrentWorld() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			if( myworld.Logic.DataAccess.IsActive() ) {
				return false;
			}

			myworld.Logic.DataAccess.Activate();
			myworld.Logic.SyncDataChanges();

			return true;
		}

		public static bool UnnihilateCurrentWorld() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.DataAccess.IsActive() ) {
				return false;
			}

			myworld.Logic.DataAccess.Deactivate();
			myworld.Logic.SyncDataChanges();

			return true;
		}

		////////////////

		public static void SuppressAutoSavingOn() {
			NihilismMod.Instance.SuppressAutoSaving = true;
		}
		
		public static void SuppressAutoSavingOff() {
			NihilismMod.Instance.SuppressAutoSaving = false;
		}


		////////////////

		public static void SetCurrentFiltersAsDefaults() {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.DataAccess.SetCurrentFiltersAsDefaults();
		}

		public static void ResetFiltersFromDefaults() {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.DataAccess.ResetFiltersFromDefaults();
		}
	}
}
