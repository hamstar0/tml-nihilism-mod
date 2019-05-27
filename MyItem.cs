using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.ItemHelpers;
using HamstarHelpers.Helpers.PlayerHelpers;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismItem : GlobalItem {
		public override bool CanUseItem( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogHelpers.Warn( "Logic not loaded." );
				return base.CanUseItem( item, player );
			}
			
			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return base.CanUseItem( item, player );
			}

			bool _;
			if( !myworld.Logic.DataAccess.IsItemEnabled( item, out _, out _ ) ) {
				return false;
			} else if( item.useAmmo != 0 ) {
				Item ammoItem = PlayerItemFinderHelpers.GetCurrentAmmo( player, item );

				if( ammoItem != null ) {
					if( !myworld.Logic.DataAccess.IsItemEnabled( ammoItem, out _, out _ ) ) {
						return false;
					}
				}
			}
			
			return base.CanUseItem( item, player );
		}


		public override bool CanRightClick( Item item ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogHelpers.Warn( "Logic not loaded." );
				return base.CanRightClick( item );
			}

			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return base.CanRightClick( item );
			}

			bool _;
			if( !myworld.Logic.DataAccess.IsItemEnabled( item, out _, out _ ) ) {
				return false;
			}
			return base.CanRightClick( item );
		}


		public override bool AltFunctionUse( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogHelpers.Warn( "Logic not loaded." );
				return base.AltFunctionUse( item, player );
			}

			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return base.AltFunctionUse( item, player );
			}

			bool _;
			if( !myworld.Logic.DataAccess.IsItemEnabled( item, out _, out _ ) ) {
				return false;
			}
			return base.AltFunctionUse( item, player );
		}


		public override bool ConsumeItem( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogHelpers.Warn( "Logic not loaded." );
				return base.ConsumeItem( item, player );
			}

			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return base.ConsumeItem( item, player );
			}

			bool _;
			if( !myworld.Logic.DataAccess.IsItemEnabled( item, out _, out _ ) ) {
				return false;
			}
			return base.ConsumeItem( item, player );
		}


		public override bool ConsumeAmmo( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogHelpers.Warn( "Logic not loaded." );
				return base.ConsumeAmmo( item, player );
			}

			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return base.ConsumeAmmo( item, player );
			}

			bool _;
			if( !myworld.Logic.DataAccess.IsItemEnabled( item, out _, out _ ) ) {
				return false;
			}
			return base.ConsumeAmmo( item, player );
		}


		public override bool PreOpenVanillaBag( string context, Player player, int arg ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogHelpers.Warn( "Logic not loaded." );
				return base.PreOpenVanillaBag( context, player, arg );
			}

			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return base.PreOpenVanillaBag( context, player, arg );
			}

			IList<int> containers = ItemFinderHelpers.FindMatches( player.inventory, ( item ) => {
				if( item == null || item.IsAir ) { return false; }
				if( ItemAttributeHelpers.GetContainerContext( item ) != context ) { return false; }
				if( arg != 0 ) { return item.type == arg; }
				return true;
			} );
			if( containers.Count == 0 ) {
				LogHelpers.Alert( "Unknown bad of context " + context + ", " + arg );
				return base.PreOpenVanillaBag( context, player, arg );	// Shouldn't happen?
			}

			Item container = player.inventory[ containers[0] ];
			bool isAir = container.IsAir;

			if( isAir ) {
				int containerType = arg != 0 ? arg : ItemAttributeHelpers.GetContainerItemTypes( context )[0];
				container = new Item();
				container.SetDefaults( containerType, true );
			}

			bool _;
			bool canOpen = myworld.Logic.DataAccess.IsItemEnabled( container, out _, out _ );

			if( !canOpen ) {
				if( containers.Count > 1 || isAir ) {
					Main.NewText( "Due to a tModLoader bug, opening blacklisted bags and boxes will sometimes consume the item. Sorry. :(", Color.Red );
				}
				return false;
			}

			return base.PreOpenVanillaBag( context, player, arg );
		}
	}
}
