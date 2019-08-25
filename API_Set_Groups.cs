using HamstarHelpers.Classes.Errors;
using HamstarHelpers.Helpers.TModLoader;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static void SetItemBlacklistGroupsEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded"); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemGroupBlacklistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetRecipeGroupBlacklistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeGroupBlacklistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcGroupBlacklistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcGroupBlacklistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootGroupBlacklistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootGroupBlacklistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void SetItemGroupWhitelistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemGroupWhitelistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void SetRecipeGroupWhitelistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeGroupWhitelistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcGroupWhitelistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcGroupWhitelistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootGroupWhitelistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootGroupWhitelistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void UnsetItemGroupBlacklistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemGroupBlacklistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeGroupBlacklistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeGroupBlacklistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcGroupBlacklistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcGroupBlacklistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootGroupBlacklistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootGroupBlacklistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		////

		public static void UnsetItemGroupWhitelistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemGroupWhitelistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeGroupWhitelistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeGroupWhitelistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcGroupWhitelistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcGroupWhitelistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootGroupWhitelistEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootGroupWhitelistEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
