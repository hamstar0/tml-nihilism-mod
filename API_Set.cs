﻿using HamstarHelpers.Components.Errors;
using HamstarHelpers.Helpers.TModLoader;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static void SetItemBlacklistEntry( int itemType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded"); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemBlacklistEntry( itemType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetRecipeBlacklistEntry( int itemType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeBlacklistEntry( itemType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcBlacklistEntry( int npcType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcBlacklistEntry( npcType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootBlacklistEntry( int npcType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootBlacklistEntry( npcType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void SetItemWhitelistEntry( int itemType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemWhitelistEntry( itemType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void SetRecipeWhitelistEntry( int itemType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeWhitelistEntry( itemType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcWhitelistEntry( int npcType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcWhitelistEntry( npcType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootWhitelistEntry( int npcType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootWhitelistEntry( npcType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void UnsetItemBlacklistEntry( int itemType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemBlacklistEntry( itemType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeBlacklistEntry( int itemType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeBlacklistEntry( itemType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcBlacklistEntry( int npcType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcBlacklistEntry( npcType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootBlacklistEntry( int npcType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootBlacklistEntry( npcType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void UnsetItemWhitelistEntry( int itemType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemWhitelistEntry( itemType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeWhitelistEntry( int itemType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeWhitelistEntry( itemType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcWhitelistEntry( int npcType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcWhitelistEntry( npcType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootWhitelistEntry( int npcType, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new HamstarException( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootWhitelistEntry( npcType );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
