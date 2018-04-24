using HamstarHelpers.TmlHelpers;
using Nihilism.Data;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		public static NihilismConfigData GetModSettings() {
			return NihilismMod.Instance.Config;
		}

		public static void SaveModSettingsChanges() {
			NihilismMod.Instance.JsonConfig.SaveFile();
		}


		////////////////
		
		public static void ItemBlacklistSet( string pattern ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception("World not loaded"); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.ItemsBlacklistPattern = pattern;
		}

		public static void ItemWhitelistEntrySet( string item_name ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.ItemWhitelist[ item_name ] = true;
		}


		public static void RecipeBlacklistSet( string pattern ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.RecipesBlacklistPattern = pattern;
		}

		public static void RecipeWhitelistEntrySet( string item_name ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.RecipeWhitelist[ item_name ] = true;
		}


		public static void NpcLootBlacklistSet( string pattern ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.NpcLootBlacklistPattern = pattern;
		}

		public static void NpcLootWhitelistEntrySet( string npc_name ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.NpcLootWhitelist[ npc_name ] = true;
		}


		public static void NpcBlacklistSet( string pattern ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.NpcBlacklistPattern = pattern;
		}

		public static void NpcWhitelistEntrySet( string npc_name ) {
			if( !TmlLoadHelpers.IsWorldLoaded() ) { throw new Exception( "World not loaded" ); }

			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			myworld.Logic.Data.NpcWhitelist[ npc_name ] = true;
		}
	}
}
