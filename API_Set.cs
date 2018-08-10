using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.TmlHelpers;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static void SetItemBlacklistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception("World not loaded"); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemBlacklistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetRecipeBlacklistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeBlacklistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcBlacklistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcBlacklistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootBlacklistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootBlacklistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void SetItemWhitelistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }
			
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemWhitelistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void SetRecipeWhitelistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeWhitelistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcWhitelistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcWhitelistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootWhitelistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootWhitelistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void UnsetItemBlacklistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemBlacklistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeBlacklistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeBlacklistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcBlacklistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcBlacklistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootBlacklistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootBlacklistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void UnsetItemWhitelistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemWhitelistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeWhitelistEntry( string item_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeWhitelistEntry( item_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcWhitelistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcWhitelistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootWhitelistEntry( string npc_name, bool local_only ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootWhitelistEntry( npc_name );

			if( !local_only ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
