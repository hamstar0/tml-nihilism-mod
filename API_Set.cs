using HamstarHelpers.Classes.Errors;
using HamstarHelpers.Helpers.TModLoader;
using System;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static void SetItemBlacklistEntry( ItemDefinition itemDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded"); }
			
			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemBlacklistEntry( itemDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetRecipeBlacklistEntry( ItemDefinition itemDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeBlacklistEntry( itemDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcBlacklistEntry( NPCDefinition npcDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcBlacklistEntry( npcDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootBlacklistEntry( NPCDefinition npcDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootBlacklistEntry( npcDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void SetItemWhitelistEntry( ItemDefinition itemDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }
			
			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetItemWhitelistEntry( itemDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
		
		public static void SetRecipeWhitelistEntry( ItemDefinition itemDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetRecipeWhitelistEntry( itemDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcWhitelistEntry( NPCDefinition npcDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcWhitelistEntry( npcDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void SetNpcLootWhitelistEntry( NPCDefinition npcDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.SetNpcLootWhitelistEntry( npcDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		////////////////

		public static void UnsetItemBlacklistEntry( ItemDefinition itemDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemBlacklistEntry( itemDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeBlacklistEntry( ItemDefinition itemDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeBlacklistEntry( itemDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcBlacklistEntry( NPCDefinition npcDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcBlacklistEntry( npcDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootBlacklistEntry( NPCDefinition npcDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootBlacklistEntry( npcDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}


		public static void UnsetItemWhitelistEntry( ItemDefinition itemDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetItemWhitelistEntry( itemDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetRecipeWhitelistEntry( ItemDefinition itemDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetRecipeWhitelistEntry( itemDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcWhitelistEntry( NPCDefinition npcDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcWhitelistEntry( npcDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}

		public static void UnsetNpcLootWhitelistEntry( NPCDefinition npcDef, bool localOnly ) {
			if( !LoadHelpers.IsWorldLoaded() ) { throw new ModHelpersException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			myworld.Logic.DataAccess.UnsetNpcLootWhitelistEntry( npcDef );

			if( !localOnly ) { myworld.Logic.SyncDataChanges(); }
		}
	}
}
