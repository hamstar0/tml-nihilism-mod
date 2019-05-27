using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.ItemHelpers;
using HamstarHelpers.Helpers.PlayerHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismItem : GlobalItem {
		public override void PostDrawInInventory( Item item, SpriteBatch sb, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogHelpers.Warn( "Logic not loaded." );
				return;
			}
			
			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return;
			}
			
			if( item == null || item.IsAir ) { return; }

			bool _;
			if( !myworld.Logic.DataAccess.IsItemEnabled( item, out _, out _ ) ) {
				float posX = position.X + (((float)frame.Width / 2f) * scale) - (((float)mymod.DisabledItem.Width / 2f) * scale);
				float posY = position.Y + (((float)frame.Height / 2f) * scale) - (((float)mymod.DisabledItem.Height / 2f) * scale);
				var pos = new Vector2( posX, posY );
				var rect = new Rectangle( 0, 0, mymod.DisabledItem.Width, mymod.DisabledItem.Height );
				var color = Color.White * 0.625f;

				sb.Draw( mymod.DisabledItem, pos, rect, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f );
			}
		}

		////////////////

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
