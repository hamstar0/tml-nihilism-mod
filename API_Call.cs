using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		internal static object Call( string call_type, params object[] args ) {
			bool on;
			string ent_name;
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

			case "SetItemFilter":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[0] is bool ) ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }
				on = (bool)args[0];

				if( !(args[1] is bool) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetItemFilter( on, local_only );
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
			case "SetRecipesFilter":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[0] is bool ) ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }
				on = (bool)args[0];

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetRecipesFilter( on, local_only );
				return null;
			case "SetRecipeWhitelistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetRecipeWhitelistEntry( ent_name, local_only );
				return null;
			case "SetNpcLootFilter":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !(args[0] is bool) ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }
				on = (bool)args[0];

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcLootFilter( on, local_only );
				return null;
			case "SetNpcLootWhitelistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcLootWhitelistEntry( ent_name, local_only );
				return null;
			case "SetNpcFilter":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[0] is bool ) ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }
				on = (bool)args[0];

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcFilter( on, local_only );
				return null;
			case "SetNpcWhitelistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

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
