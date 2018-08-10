using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		internal static object Call( string call_type, params object[] args ) {
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

			////

			case "SetItemBlacklistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !(args[1] is bool) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetItemBlacklistEntry( ent_name, local_only );
				return null;
			case "SetRecipesBlacklistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetRecipeBlacklistEntry( ent_name, local_only );
				return null;
			case "SetNpcBlacklistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcBlacklistEntry( ent_name, local_only );
				return null;
			case "SetNpcLootBlacklistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcLootBlacklistEntry( ent_name, local_only );
				return null;

			case "SetItemWhitelistEntry":
			case "SetItemsWhitelistEntry":  // Oops @v1.4.0.1
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetItemWhitelistEntry( ent_name, local_only );
				return null;
			case "SetRecipeWhitelistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetRecipeWhitelistEntry( ent_name, local_only );
				return null;
			case "SetNpcWhitelistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcWhitelistEntry( ent_name, local_only );
				return null;
			case "SetNpcLootWhitelistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.SetNpcLootWhitelistEntry( ent_name, local_only );
				return null;
			
			////

			case "UnsetItemBlacklistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.UnsetItemBlacklistEntry( ent_name, local_only );
				return null;
			case "UnsetRecipesBlacklistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.UnsetRecipeBlacklistEntry( ent_name, local_only );
				return null;
			case "UnsetNpcBlacklistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.UnsetNpcBlacklistEntry( ent_name, local_only );
				return null;
			case "UnsetNpcLootBlacklistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.UnsetNpcLootBlacklistEntry( ent_name, local_only );
				return null;
				
			case "UnsetItemsWhitelistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.UnsetItemWhitelistEntry( ent_name, local_only );
				return null;
			case "UnsetRecipeWhitelistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.UnsetRecipeWhitelistEntry( ent_name, local_only );
				return null;
			case "UnsetNpcWhitelistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.UnsetNpcWhitelistEntry( ent_name, local_only );
				return null;
			case "UnsetNpcLootWhitelistEntry":
				if( args.Length < 2 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				ent_name = args[0] as string;
				if( ent_name == null ) { throw new Exception( "Invalid parameter player for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.UnsetNpcLootWhitelistEntry( ent_name, local_only );
				return null;

			////

			case "ClearItemBlacklist":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }
				
				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.ClearItemBlacklist( local_only );
				return null;
			case "ClearRecipeBlacklist":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.ClearRecipeBlacklist( local_only );
				return null;
			case "ClearNpcBlacklist":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.ClearNpcBlacklist( local_only );
				return null;
			case "ClearNpcLootBlacklist":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.ClearNpcLootBlacklist( local_only );
				return null;

			case "ClearItemWhitelist":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.ClearItemWhitelist( local_only );
				return null;
			case "ClearRecipeWhitelist":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.ClearRecipeWhitelist( local_only );
				return null;
			case "ClearNpcWhitelist":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.ClearNpcWhitelist( local_only );
				return null;
			case "ClearNpcLootWhitelist":
				if( args.Length < 1 ) { throw new Exception( "Insufficient parameters for API call " + call_type ); }

				if( !( args[1] is bool ) ) { throw new Exception( "Invalid parameter local_only for API call " + call_type ); }
				local_only = (bool)args[1];

				NihilismAPI.ClearNpcLootWhitelist( local_only );
				return null;

			////

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
