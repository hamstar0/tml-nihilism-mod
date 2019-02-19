using HamstarHelpers.Helpers.DebugHelpers;
using System;


namespace Nihilism {
	public static partial class NihilismAPI {
		[Obsolete("use SetItemWhitelistEntry()")]
		public static void SetItemsWhitelistEntry( string itemName, bool localOnly ) {
			NihilismAPI.SetItemWhitelistEntry( itemName, localOnly );
		}
	}
}
