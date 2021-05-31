using System;
using Terraria.ModLoader;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.TModLoader;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static void ClearItemGroupBlacklist( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearItemGroupBlacklist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearRecipeGroupBlacklist( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearRecipeGroupBlacklist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcGroupBlacklist( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcGroupBlacklist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcLootGroupBlacklist( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcLootGroupBlacklist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void ClearItemGroupBlacklist2( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearItemGroupBlacklist2();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearRecipeGroupBlacklist2( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearRecipeGroupBlacklist2();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcGroupBlacklist2( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcGroupBlacklist2();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcLootGroupBlacklist2( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcLootGroupBlacklist2();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void ClearItemGroupWhitelist( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearItemGroupWhitelist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearRecipeGroupWhitelist( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearRecipeGroupWhitelist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void ClearNpcGroupWhitelist( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcGroupWhitelist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void ClearNpcLootGroupWhitelist( bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.ClearNpcLootGroupWhitelist();

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
