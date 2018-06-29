using HamstarHelpers.PlayerHelpers;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismProjectile : GlobalProjectile {
		public override bool? CanUseGrapple( int proj_type, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return null; }

			if( !myworld.Logic.AreItemFiltersEnabled( mymod ) ) {
				return null;
			}

			Item grapple_item = PlayerItemHelpers.GetGrappleItem( player );
			
			if( grapple_item != null && myworld.Logic.DataAccess.IsItemEnabled( grapple_item ) ) {
				return null;
			}
			return false;
		}
	}
}
