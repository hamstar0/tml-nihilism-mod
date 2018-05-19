﻿using HamstarHelpers.DebugHelpers;
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
			if( myworld.Logic.Data.IsActive() ) {
				return false;
			}

			myworld.Logic.Data.Activate();
			myworld.Logic.SyncData();

			return true;
		}

		public static bool UnnihilateCurrentWorld() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.Data.IsActive() ) {
				return false;
			}

			myworld.Logic.Data.Deactivate();
			myworld.Logic.SyncData();

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

		public static void SetItemsBlacklistPattern( string pattern, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception("World not loaded"); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.SetItemsBlacklistPattern( pattern );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		public static void SetItemsWhitelistEntry( string item_name, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.SetItemWhitelistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}


		public static void SetRecipesBlacklistPattern( string pattern, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.SetRecipesBlacklistPattern( pattern );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		public static void SetRecipeWhitelistEntry( string item_name, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.SetRecipeWhitelistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}


		public static void SetNpcLootBlacklistPattern( string pattern, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.SetNpcLootBlacklistPattern( pattern );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		public static void SetNpcLootWhitelistEntry( string npc_name, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.SetNpcLootWhitelistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}


		public static void SetNpcBlacklistPattern( string pattern, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.SetNpcBlacklistPattern( pattern );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		public static void SetNpcWhitelistEntry( string npc_name, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.SetNpcWhitelistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		////////////////

		public static void SetCurrentFiltersAsDefaults() {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.Data.SetCurrentFiltersAsDefaults( mymod );
		}

		public static void ResetFiltersFromDefaults() {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.Data.ResetFiltersFromDefaults( mymod );
		}
	}
}
