using HamstarHelpers.DebugHelpers;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		[Obsolete("use SetItemWhitelistEntry()")]
		public static void SetItemsWhitelistEntry( string item_name, bool local_only ) {
			NihilismAPI.SetItemWhitelistEntry( item_name, local_only );
		}
	}
}
