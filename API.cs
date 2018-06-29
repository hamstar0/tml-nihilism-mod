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

		public static void SetItemBlacklistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception("World not loaded"); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemBlacklistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetRecipeBlacklistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeBlacklistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcBlacklistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcBlacklistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootBlacklistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootBlacklistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void SetItemWhitelistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemWhitelistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void SetRecipeWhitelistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeWhitelistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcWhitelistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcWhitelistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootWhitelistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootWhitelistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void ClearItemBlacklist( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearItemBlacklist();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void ClearRecipeBlacklist( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearRecipeBlacklist();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcBlacklist( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcBlacklist();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcLootBlacklist( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcLootBlacklist();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		////////////////

		public static void ClearItemWhitelist( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearItemWhitelist();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearRecipeWhitelist( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearRecipeWhitelist();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void ClearNpcWhitelist( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcWhitelist();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcLootWhitelist( bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcLootWhitelist();

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}
		

		////////////////

		public static void SetCurrentFiltersAsDefaults() {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.DataAccess.SetCurrentFiltersAsDefaults( mymod );
		}

		public static void ResetFiltersFromDefaults() {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.DataAccess.ResetFiltersFromDefaults( mymod );
		}
	}
}
