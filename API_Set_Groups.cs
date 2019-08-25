using HamstarHelpers.Classes.Errors;
using HamstarHelpers.Helpers.TModLoader;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static void SetItemBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded"); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetRecipeBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void SetItemWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void SetRecipeWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void UnsetItemBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootBlacklistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootBlacklistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		////

		public static void UnsetItemWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootWhitelistGroupEntry( string groupName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootWhitelistGroupEntry( groupName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
