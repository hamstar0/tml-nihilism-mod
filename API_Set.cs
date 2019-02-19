using HamstarHelpers.Components.Errors;
using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.TmlHelpers;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static void SetItemBlacklistEntry( string itemName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded"); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemBlacklistEntry( itemName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetRecipeBlacklistEntry( string itemName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeBlacklistEntry( itemName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcBlacklistEntry( string npcName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcBlacklistEntry( npcName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootBlacklistEntry( string npcName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootBlacklistEntry( npcName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void SetItemWhitelistEntry( string itemName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemWhitelistEntry( itemName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void SetRecipeWhitelistEntry( string itemName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeWhitelistEntry( itemName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcWhitelistEntry( string npcName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcWhitelistEntry( npcName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootWhitelistEntry( string npcName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootWhitelistEntry( npcName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void UnsetItemBlacklistEntry( string itemName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemBlacklistEntry( itemName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeBlacklistEntry( string itemName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeBlacklistEntry( itemName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcBlacklistEntry( string npcName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcBlacklistEntry( npcName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootBlacklistEntry( string npcName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootBlacklistEntry( npcName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void UnsetItemWhitelistEntry( string itemName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemWhitelistEntry( itemName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeWhitelistEntry( string itemName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeWhitelistEntry( itemName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcWhitelistEntry( string npcName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcWhitelistEntry( npcName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootWhitelistEntry( string npcName, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootWhitelistEntry( npcName );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
