using HamstarHelpers.DebugHelpers;
using HamstarHelpers.ItemHelpers;
using HamstarHelpers.PlayerHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismItem : GlobalItem {
		public override void PostDrawInInventory( Item item, SpriteBatch sb, Vector2 position, Rectangle frame, Color draw_color, Color item_color, Vector2 origin, float scale ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return; }

			if( !myworld.Logic.AreItemFiltersEnabled( mymod ) ) {
				return;
			}

			if( item == null || item.IsAir ) { return; }

			if( !myworld.Logic.DataAccess.IsItemEnabled( item ) ) {
				float pos_x = position.X + (((float)frame.Width / 2f) * scale) - (((float)mymod.DisabledItem.Width / 2f) * scale);
				float pos_y = position.Y + (((float)frame.Height / 2f) * scale) - (((float)mymod.DisabledItem.Height / 2f) * scale);
				var pos = new Vector2( pos_x, pos_y );
				var rect = new Rectangle( 0, 0, mymod.DisabledItem.Width, mymod.DisabledItem.Height );
				var color = Color.White * 0.625f;

				sb.Draw( mymod.DisabledItem, pos, rect, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f );
			}
		}

		////////////////

		public override bool CanUseItem( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return base.CanUseItem( item, player ); }
			
			if( !myworld.Logic.AreItemFiltersEnabled( mymod ) ) {
				return base.CanUseItem( item, player );
			}
			
			if( !myworld.Logic.DataAccess.IsItemEnabled( item ) ) {
				return false;
			} else if( item.useAmmo != 0 ) {
				Item ammo_item = PlayerItemFinderHelpers.GetCurrentAmmo( player, item );

				if( ammo_item != null ) {
					if( !myworld.Logic.DataAccess.IsItemEnabled( ammo_item ) ) {
						return false;
					}
				}
			}
			
			return base.CanUseItem( item, player );
		}


		public override bool CanRightClick( Item item ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return base.CanRightClick( item ); }

			if( !myworld.Logic.AreItemFiltersEnabled( mymod ) ) {
				return base.CanRightClick( item );
			}
			
			if( !myworld.Logic.DataAccess.IsItemEnabled( item ) ) {
				return false;
			}
			return base.CanRightClick( item );
		}


		public override bool AltFunctionUse( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return base.AltFunctionUse( item, player ); }

			if( !myworld.Logic.AreItemFiltersEnabled( mymod ) ) {
				return base.AltFunctionUse( item, player );
			}

			if( !myworld.Logic.DataAccess.IsItemEnabled( item ) ) {
				return false;
			}
			return base.AltFunctionUse( item, player );
		}


		public override bool ConsumeItem( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return base.ConsumeItem( item, player ); }

			if( !myworld.Logic.AreItemFiltersEnabled( mymod ) ) {
				return base.ConsumeItem( item, player );
			}

			if( !myworld.Logic.DataAccess.IsItemEnabled( item ) ) {
				return false;
			}
			return base.ConsumeItem( item, player );
		}


		public override bool ConsumeAmmo( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return base.ConsumeAmmo( item, player ); }

			if( !myworld.Logic.AreItemFiltersEnabled( mymod ) ) {
				return base.ConsumeAmmo( item, player );
			}

			if( !myworld.Logic.DataAccess.IsItemEnabled( item ) ) {
				return false;
			}
			return base.ConsumeAmmo( item, player );
		}


		public override bool PreOpenVanillaBag( string context, Player player, int arg ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) {
				return base.PreOpenVanillaBag( context, player, arg );
			}

			if( !myworld.Logic.AreItemFiltersEnabled( mymod ) ) {
				return base.PreOpenVanillaBag( context, player, arg );
			}

			IList<int> containers = ItemFinderHelpers.FindMatches( player.inventory, ( item ) => {
				if( item == null || item.IsAir ) { return false; }
				if( ItemAttributeHelpers.GetContainerContext( item ) != context ) { return false; }
				if( arg != 0 ) { return item.type == arg; }
				return true;
			} );
			if( containers.Count == 0 ) {
				LogHelpers.Log( "NihilismItem.PreOpenVanillaBag - Unknown bad of context " + context + ", " + arg );
				return base.PreOpenVanillaBag( context, player, arg );	// Shouldn't happen?
			}

			Item container = player.inventory[ containers[0] ];
			bool is_air = container.IsAir;

			if( is_air ) {
				container = new Item();
				container.SetDefaults( arg != 0 ? arg : ItemAttributeHelpers.GetContainerItemTypes(context)[0] );
			}

			bool can_open = myworld.Logic.DataAccess.IsItemEnabled( container );

			if( !can_open ) {
				if( containers.Count > 1 || is_air ) {
					Main.NewText( "Due to a tModLoader bug, opening blacklisted bags and boxes will sometimes consume the item. Sorry. :(", Color.Red );
				} else {
					container.stack++;
				}

				return false;
			}

			return base.PreOpenVanillaBag( context, player, arg );
		}
	}
}
