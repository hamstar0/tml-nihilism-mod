﻿using HamstarHelpers.Classes.Errors;
using HamstarHelpers.Helpers.TModLoader;
using System;
using Terraria.ModLoader;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static bool NihilateCurrentWorld( bool localOnly ) {
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic.DataAccess.IsActive() ) {
				return false;
			}

			myworld.Logic.DataAccess.Activate();
			if( !localOnly ) {
				myworld.Logic.SyncDataChanges();
			}

			return true;
		}

		public static bool UnnihilateCurrentWorld( bool localOnly ) {
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( !myworld.Logic.DataAccess.IsActive() ) {
				return false;
			}

			myworld.Logic.DataAccess.Deactivate();
			if( !localOnly ) {
				myworld.Logic.SyncDataChanges();
			}

			return true;
		}

		////////////////

		public static void InstancedFiltersOn() {
			NihilismMod.Instance.InstancedFilters = true;
		}
		
		public static void InstancedFiltersOff() {
			NihilismMod.Instance.InstancedFilters = false;
		}


		////////////////

		public static void SetCurrentFiltersAsDefaults( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = ModContent.GetInstance<NihilismWorld>();

			myworld.Logic.DataAccess.SetCurrentFiltersAsDefaults();

			if( !localOnly ) {
				myworld.Logic.SyncDataChanges();
			}
		}

		public static void ResetFiltersFromDefaults( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = ModContent.GetInstance<NihilismWorld>();

			myworld.Logic.DataAccess.ResetFiltersFromDefaults();

			if( !localOnly ) {
				myworld.Logic.SyncDataChanges();
			}
		}

		////

		public static void ClearFiltersForCurrentWorld( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var mymod = NihilismMod.Instance;
			var myworld = ModContent.GetInstance<NihilismWorld>();

			myworld.Logic.DataAccess.ClearItemBlacklist();
			myworld.Logic.DataAccess.ClearNpcBlacklist();
			myworld.Logic.DataAccess.ClearNpcLootBlacklist();
			myworld.Logic.DataAccess.ClearRecipeBlacklist();

			myworld.Logic.DataAccess.ClearItemWhitelist();
			myworld.Logic.DataAccess.ClearNpcLootWhitelist();
			myworld.Logic.DataAccess.ClearNpcWhitelist();
			myworld.Logic.DataAccess.ClearRecipeWhitelist();

			myworld.Logic.DataAccess.ClearItemBlacklist2();
			myworld.Logic.DataAccess.ClearNpcBlacklist2();
			myworld.Logic.DataAccess.ClearNpcLootBlacklist2();
			myworld.Logic.DataAccess.ClearRecipeBlacklist2();

			if( !localOnly ) {
				myworld.Logic.SyncDataChanges();
			}
		}
	}
}
