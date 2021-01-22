using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.Players;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismProjectile : GlobalProjectile {
		public override bool? CanUseGrapple( int projType, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic == null ) { return null; }

			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return null;
			}

			Item grappleItem = PlayerItemHelpers.GetGrappleItem( player );

			bool _;
			if( grappleItem != null && myworld.Logic.DataAccess.IsItemEnabled( grappleItem, out _, out _ ) ) {
				return null;
			}
			return false;
		}
	}
}
