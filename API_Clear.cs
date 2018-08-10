using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.TmlHelpers;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
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
	}
}
