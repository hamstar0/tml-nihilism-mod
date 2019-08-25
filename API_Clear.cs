using HamstarHelpers.Classes.Errors;
using HamstarHelpers.Helpers.TModLoader;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static void ClearItemBlacklist( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearItemBlacklist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearRecipeBlacklist( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearRecipeBlacklist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcBlacklist( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcBlacklist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcLootBlacklist( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcLootBlacklist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void ClearItemBlacklist2( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearItemBlacklist2();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearRecipeBlacklist2( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearRecipeBlacklist2();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcBlacklist2( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcBlacklist2();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcLootBlacklist2( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcLootBlacklist2();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void ClearItemWhitelist( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearItemWhitelist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearRecipeWhitelist( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearRecipeWhitelist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void ClearNpcWhitelist( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcWhitelist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcLootWhitelist( bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcLootWhitelist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
