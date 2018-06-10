using HamstarHelpers.PlayerHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismItem : GlobalItem {
		public override void PostDrawInInventory( Item item, SpriteBatch sb, Vector2 position, Rectangle frame, Color draw_color, Color item_color, Vector2 origin, float scale ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();

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

		public override bool CanUseItem( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			if( !myworld.Logic.AreItemFiltersEnabled( mymod ) ) {
				return base.CanUseItem( item, player );
			}
			
			if( !myworld.Logic.DataAccess.IsItemEnabled( item ) ) {
				return false;
			} else if( item.useAmmo == 0 ) {
				return true;
			}

			Item ammo_item = PlayerItemFinderHelpers.GetCurrentAmmo( player, item );
			if( ammo_item != null ) {
				return myworld.Logic.DataAccess.IsItemEnabled( ammo_item );
			}

			return false;
		}
	}
}
