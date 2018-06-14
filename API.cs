using HamstarHelpers.DebugHelpers;
using HamstarHelpers.TmlHelpers;
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
			myworld.Logic.SyncData();

			return true;
		}

		public static bool UnnihilateCurrentWorld() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.DataAccess.IsActive() ) {
				return false;
			}

			myworld.Logic.DataAccess.Deactivate();
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

		public static void SetItemFilter( bool on, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception("World not loaded"); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemFilter( on );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		public static void SetRecipesFilter( bool on, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeFilter( on );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		public static void SetNpcLootFilter( bool on, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootFilter( on );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		public static void SetNpcFilter( bool on, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcFilter( on );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}


		[Obsolete("use SetItemWhitelistEntry()")]
		public static void SetItemsWhitelistEntry( string item_name, bool local_only ) {
			NihilismAPI.SetItemWhitelistEntry( item_name, local_only );
		}
		public static void SetItemWhitelistEntry( string item_name, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemWhitelistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}
		
		public static void SetRecipeWhitelistEntry( string item_name, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeWhitelistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}
		
		public static void SetNpcLootWhitelistEntry( string npc_name, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootWhitelistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}
		
		public static void SetNpcWhitelistEntry( string npc_name, bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcWhitelistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncData(); }
		}


		////////////////

		public static void ClearItemWhitelist( bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearItemWhitelist();

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		public static void ClearRecipeWhitelist( bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearRecipeWhitelist();

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		public static void ClearNpcWhitelist( bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcWhitelist();

			if( !local_only ) { myworld.Logic.SyncData(); }
		}

		public static void ClearNpcLootWhitelist( bool local_only ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcLootWhitelist();

			if( !local_only ) { myworld.Logic.SyncData(); }
		}
		

		////////////////

		public static void SetCurrentFiltersAsDefaults() {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.DataAccess.SetCurrentFiltersAsDefaults( mymod );
		}

		public static void ResetFiltersFromDefaults() {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.DataAccess.ResetFiltersFromDefaults( mymod );
		}
	}
}
