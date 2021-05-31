using System;
using Terraria.ModLoader;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.TModLoader;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static void OnSyncOrWorldLoad( Action<bool> action, float priority ) {
			var mymod = NihilismMod.Instance;
			int count = mymod.SyncOrWorldLoadActions.Count;

			if( priority >= 1f ) {
				mymod.SyncOrWorldLoadActions.Add( (1f, action) );
			} else if( priority <= 0f ) {
				mymod.SyncOrWorldLoadActions.Insert( 0, (0f, action) );
			} else {
				for( int i = 0; i < count; i++ ) {
					(float priority, Action<bool> action) entry = mymod.SyncOrWorldLoadActions[i];

					if( priority >= entry.priority ) {
						mymod.SyncOrWorldLoadActions.Insert( i+1, (priority, action) );
						return;
					}
				}

				mymod.SyncOrWorldLoadActions.Add( (priority, action) );
			}
		}


		////////////////

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
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();

			myworld.Logic.DataAccess.SetCurrentFiltersAsDefaults();

			if( !localOnly ) {
				myworld.Logic.SyncDataChanges();
			}
		}

		public static void ResetFiltersFromDefaults( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();

			myworld.Logic.DataAccess.ResetFiltersFromDefaults();

			if( !localOnly ) {
				myworld.Logic.SyncDataChanges();
			}
		}

		////

		public static void ClearFiltersForCurrentWorld( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

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

			myworld.Logic.DataAccess.ClearItemGroupBlacklist();
			myworld.Logic.DataAccess.ClearNpcGroupBlacklist();
			myworld.Logic.DataAccess.ClearNpcLootGroupBlacklist();
			myworld.Logic.DataAccess.ClearRecipeGroupBlacklist();

			myworld.Logic.DataAccess.ClearItemGroupWhitelist();
			myworld.Logic.DataAccess.ClearNpcLootGroupWhitelist();
			myworld.Logic.DataAccess.ClearNpcGroupWhitelist();
			myworld.Logic.DataAccess.ClearRecipeGroupWhitelist();

			myworld.Logic.DataAccess.ClearItemGroupBlacklist2();
			myworld.Logic.DataAccess.ClearNpcGroupBlacklist2();
			myworld.Logic.DataAccess.ClearNpcLootGroupBlacklist2();
			myworld.Logic.DataAccess.ClearRecipeGroupBlacklist2();

			if( !localOnly ) {
				myworld.Logic.SyncDataChanges();
			}
		}
	}
}
