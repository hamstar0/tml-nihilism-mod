using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		internal static object Call( string call_type, params object[] args ) {
			string pattern, ent_name;
			
			switch( call_type ) {
			case "GetModSettings":
				return NihilismAPI.GetModSettings();
			case "SaveModSettingsChanges":
				NihilismAPI.SaveModSettingsChanges();
				return null;

			case "ItemBlacklistSet":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.ItemBlacklistSet( pattern );
				return null;
			case "ItemWhitelistEntrySet":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.ItemWhitelistEntrySet( ent_name );
				return null;
			case "RecipeBlacklistSet":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.RecipeBlacklistSet( pattern );
				return null;
			case "RecipeWhitelistEntrySet":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.RecipeWhitelistEntrySet( ent_name );
				return null;
			case "LootBlacklistSet":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.NpcLootBlacklistSet( pattern );
				return null;
			case "NpcLootWhitelistEntrySet":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.NpcLootWhitelistEntrySet( ent_name );
				return null;
			case "NpcBlacklistSet":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.NpcBlacklistSet( pattern );
				return null;
			case "NpcWhitelistEntrySet":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.NpcWhitelistEntrySet( ent_name );
				return null;
			}

			throw new Exception( "No such api call " + call_type );
		}
	}
}
