using HamstarHelpers.Helpers.PlayerHelpers;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismProjectile : GlobalProjectile {
		public override bool? CanUseGrapple( int projType, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return null; }

			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return null;
			}

			Item grappleItem = PlayerItemHelpers.GetGrappleItem( player );
			
			if( grappleItem != null && myworld.Logic.DataAccess.IsItemEnabled( grappleItem ) ) {
				return null;
			}
			return false;
		}
	}
}
