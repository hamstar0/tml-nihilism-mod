using HamstarHelpers.TmlHelpers;
using Nihilism.Data;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static NihilismConfigData GetModSettings() {
			return NihilismMod.Instance.Config;
		}

		public static void SaveModSettingsChanges() {
			NihilismMod.Instance.JsonConfig.SaveFile();
		}


		////////////////

		public static bool NihilateCurrentWorld() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			if( myworld.Logic.Data.IsActive ) {
				return false;
			}

			myworld.Logic.NihilateCurrentWorld();
			return true;
		}

		public static bool UnnihilateCurrentWorld() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.Data.IsActive ) {
				return false;
			}

			myworld.Logic.UnnihilateCurrentWorld();
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

		public static void SetItemsBlacklistPattern( string pattern ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception("World not loaded"); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.SetItemsBlacklistPattern( pattern );
		}

		public static void SetItemsWhitelistEntry( string item_name ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.SetItemWhitelistEntry( item_name );
		}


		public static void SetRecipesBlacklistPattern( string pattern ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.SetRecipesBlacklistPattern( pattern );
		}

		public static void SetRecipeWhitelistEntry( string item_name ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.SetRecipeWhitelistEntry( item_name );
		}


		public static void SetNpcLootBlacklistPattern( string pattern ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.SetNpcLootBlacklistPattern( pattern );
		}

		public static void SetNpcLootWhitelistEntry( string npc_name ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.SetNpcLootWhitelistEntry( npc_name );
		}


		public static void SetNpcBlacklistPattern( string pattern ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.SetNpcBlacklistPattern( pattern );
		}

		public static void SetNpcWhitelistEntry( string npc_name ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.SetNpcWhitelistEntry( npc_name );
		}

		////////////////

		public static void SetCurrentFiltersAsDefaults() {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.SetCurrentFiltersAsDefaults( mymod );
		}

		public static void ResetFiltersFromDefaults() {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.ResetFiltersFromDefaults( mymod );
		}
	}
}
