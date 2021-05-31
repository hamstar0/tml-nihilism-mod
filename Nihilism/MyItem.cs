using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Libraries.DotNET;
using ModLibsGeneral.Libraries.Items;
using ModLibsGeneral.Libraries.Items.Attributes;
using ModLibsGeneral.Libraries.Players;


namespace Nihilism {
	partial class NihilismItem : GlobalItem {
		public override bool CanUseItem( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogLibraries.WarnOnce( "Logic not loaded." );
				return base.CanUseItem( item, player );
			}
			
			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return base.CanUseItem( item, player );
			}

			bool _;
			if( !myworld.Logic.DataAccess.IsItemEnabled( item, out _, out _ ) ) {
				return false;
			} else if( item.useAmmo != 0 ) {
				Item ammoItem = PlayerItemFinderLibraries.GetCurrentAmmo( player, item );

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
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogLibraries.WarnOnce( "Logic not loaded." );
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
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogLibraries.WarnOnce( "Logic not loaded." );
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
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogLibraries.WarnOnce( "Logic not loaded." );
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
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogLibraries.WarnOnce( "Logic not loaded." );
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
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogLibraries.WarnOnce( "Logic not loaded." );
				return base.PreOpenVanillaBag( context, player, arg );
			}

			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return base.PreOpenVanillaBag( context, player, arg );
			}

			IList<Item> containerInvIndexes = player.inventory
				.SafeWhere( ( item ) => {
					if( item == null || item.IsAir ) { return false; }
					if( ItemAttributeLibraries.GetVanillaContainerContext( item ) != context ) { return false; }
					if( arg != 0 ) { return item.type == arg; }
					return true;
				} )
				.ToList();

			if( containerInvIndexes.Count == 0 ) {
				LogLibraries.Alert( "Unknown bag of context " + context + ", " + arg );
				return base.PreOpenVanillaBag( context, player, arg );	// Shouldn't happen?
			}

			Item containerItem = containerInvIndexes.FirstOrDefault();
			bool isAir = containerItem?.IsAir ?? true;

			if( isAir ) {
				int containerType = arg != 0
					? arg
					: ItemCommonGroupsLibraries.GetVanillaContainerItemTypes( context )[0];
				containerItem = new Item();
				containerItem.SetDefaults( containerType, true );
			}

			bool _;
			bool canOpen = myworld.Logic.DataAccess.IsItemEnabled( containerItem, out _, out _ );

			if( !canOpen ) {
				if( containerInvIndexes.Count > 1 || isAir ) {
					Main.NewText( "Due to a tModLoader bug, opening blacklisted bags and boxes will sometimes consume the item. Sorry. :(", Color.Red );
				}
				return false;
			}

			return base.PreOpenVanillaBag( context, player, arg );
		}
	}
}
