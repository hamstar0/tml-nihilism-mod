using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismProjectile : GlobalProjectile {
		public override bool? CanUseGrapple( int item_type, Player player ) {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.EnableItemFilters ) { return base.CanUseGrapple( item_type, player ); }

			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.IsCurrentWorldNihilated() ) { return base.CanUseGrapple( item_type, player ); }

			Item grapple_item = new Item();
			grapple_item.SetDefaults( item_type );
			
			return myworld.Logic.IsItemEnabled( grapple_item );
		}
	}
}
