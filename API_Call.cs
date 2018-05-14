using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		internal static object Call( string call_type, params object[] args ) {
			string pattern, ent_name;
			bool local_only;
			
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

			case "SuppressAutoSavingOn":
				NihilismAPI.SuppressAutoSavingOn();
				return null;
			case "SuppressAutoSavingOff":
				NihilismAPI.SuppressAutoSavingOff();
				return null;

			case "SetItemsBlacklistPattern":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !(args[1] is bool) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetItemsBlacklistPattern( pattern, local_only );
				return null;
			case "SetItemWhitelistEntry":
			case "SetItemsWhitelistEntry":  // Oops (v1.4.0.1)
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetItemsWhitelistEntry( ent_name, local_only );
				return null;
			case "SetRecipesBlacklistPattern":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetRecipesBlacklistPattern( pattern, local_only );
				return null;
			case "SetRecipeWhitelistEntry":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetRecipeWhitelistEntry( ent_name, local_only );
				return null;
			case "SetNpcLootBlacklistPattern":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcLootBlacklistPattern( pattern, local_only );
				return null;
			case "SetNpcLootWhitelistEntry":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcLootWhitelistEntry( ent_name, local_only );
				return null;
			case "SetNpcBlacklistPattern":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				pattern = args[0] as string;
				if( pattern == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcBlacklistPattern( pattern, local_only );
				return null;
			case "SetNpcWhitelistEntry":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcWhitelistEntry( ent_name, local_only );
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
