using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismProjectile : GlobalProjectile {
		public override bool? CanUseGrapple( int item_type, Player player ) {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.Data.Enabled ) { return base.CanUseGrapple( item_type, player ); }
			var whitelist = mymod.Config.Data.ItemWhitelist;

			Item grapple_item = new Item();
			grapple_item.SetDefaults( item_type );

			return whitelist.ContainsKey( grapple_item.Name ) && whitelist[ grapple_item.Name ];
		}
	}
}
