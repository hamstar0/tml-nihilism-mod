using HamstarHelpers.Classes.Errors;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		[Obsolete("use the overload", true)]
		public static bool NihilateCurrentWorld() {
			return NihilismAPI.NihilateCurrentWorld( false );
		}

		[Obsolete( "use the overload", true )]
		public static bool UnnihilateCurrentWorld() {
			return NihilismAPI.NihilateCurrentWorld( false );
		}


		////////////////

		[Obsolete( "use the overload", true )]
		public static void SetCurrentFiltersAsDefaults() {
			NihilismAPI.SetCurrentFiltersAsDefaults( false );
		}

		[Obsolete( "use the overload", true )]
		public static void ResetFiltersFromDefaults() {
			NihilismAPI.ResetFiltersFromDefaults( false );
		}

		////

		[Obsolete( "use the overload", true )]
		public static void ClearFiltersForCurrentWorld() {
			NihilismAPI.ClearFiltersForCurrentWorld( false );
		}
	}
}
