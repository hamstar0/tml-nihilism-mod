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

			case "NihilateCurrentWorld":
				return NihilismAPI.NihilateCurrentWorld();
			case "UnnihilateCurrentWorld":
				return NihilismAPI.UnnihilateCurrentWorld();

			case "SetItemsBlacklistPattern":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.SetItemsBlacklistPattern( pattern );
				return null;
			case "SetItemWhitelistEntry":
			case "SetItemsWhitelistEntry":  // Oops (v1.4.0.1)
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.SetItemsWhitelistEntry( ent_name );
				return null;
			case "SetRecipesBlacklistPattern":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.SetRecipesBlacklistPattern( pattern );
				return null;
			case "SetRecipeWhitelistEntry":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.SetRecipeWhitelistEntry( ent_name );
				return null;
			case "SetNpcLootBlacklistPattern":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.SetNpcLootBlacklistPattern( pattern );
				return null;
			case "SetNpcLootWhitelistEntry":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.SetNpcLootWhitelistEntry( ent_name );
				return null;
			case "SetNpcBlacklistPattern":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.SetNpcBlacklistPattern( pattern );
				return null;
			case "SetNpcWhitelistEntry":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				NihilismAPI.SetNpcWhitelistEntry( ent_name );
				return null;
			case "SetCurrentFiltersAsDefaults":
				NihilismAPI.SetCurrentFiltersAsDefaults();
				return null;
			case "ResetFiltersFromDefaults":
				NihilismAPI.ResetFiltersFromDefaults();
				return null;
			}

			throw new Exception( "No such api call " + call_type );
		}
	}
}
