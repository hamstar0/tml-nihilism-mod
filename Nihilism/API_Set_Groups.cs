using System;
using Terraria.ModLoader;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.TModLoader;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static void SetItemBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded"); }
			
			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetRecipeBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void SetItemWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }
			
			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void SetRecipeWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void SetItemBlacklist2GroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemBlacklist2GroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetRecipeBlacklist2GroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeBlacklist2GroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcBlacklist2GroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcBlacklist2GroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootBlacklist2GroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootBlacklist2GroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void UnsetItemBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		////

		public static void UnsetItemWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
