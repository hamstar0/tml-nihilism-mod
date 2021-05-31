using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.TModLoader;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static IList<string> GetItemBlacklistGroupsForItem( Item item ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetItemBlacklistGroupEntriesForItem( item );
		}

		public static IList<string> GetItemWhitelistGroupsForItem( Item item ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetItemWhitelistGroupEntriesForItem( item );
		}

		public static IList<string> GetItemBlacklist2GroupsForItem( Item item ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetItemBlacklist2GroupEntriesForItem( item );
		}

		////

		public static IList<string> GetRecipeBlacklistGroupsForItem( Item item ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetRecipeBlacklistGroupEntriesForItemRecipe( item );
		}

		public static IList<string> GetRecipeWhitelistGroupsForItem( Item item ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetRecipeWhitelistGroupEntriesForItemRecipe( item );
		}

		public static IList<string> GetRecipeBlacklist2GroupsForItem( Item item ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetRecipeBlacklist2GroupEntriesForItemRecipe( item );
		}

		////

		public static IList<string> GetNpcBlacklistGroupsForNpc( NPC npc ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetNpcBlacklistGroupEntriesForNpc( npc );
		}

		public static IList<string> GetNpcWhitelistGroupsForNpc( NPC npc ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetNpcWhitelistGroupEntriesForNpc( npc );
		}

		public static IList<string> GetNpcBlacklist2GroupsForNpc( NPC npc ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetNpcBlacklist2GroupEntriesForNpc( npc );
		}

		////

		public static IList<string> GetNpcLootBlacklistGroupsForNpc( NPC npc ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetNpcLootBlacklistGroupEntriesForNpc( npc );
		}

		public static IList<string> GetNpcLootWhitelistGroupsForNpc( NPC npc ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetNpcLootWhitelistGroupEntriesForNpc( npc );
		}

		public static IList<string> GetNpcLootBlacklist2GroupsForNpc( NPC npc ) {
			if( !LoadLibraries.IsWorldLoaded() ) { throw new ModLibsException( "World not loaded" ); }

			var myworld = ModContent.GetInstance<NihilismWorld>();
			return myworld.Logic?.DataAccess?.GetNpcLootBlacklist2GroupEntriesForNpc( npc );
		}
	}
}
