﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismItem : GlobalItem {
		public override void PostDrawInInventory( Item item, SpriteBatch sb, Vector2 position, Rectangle frame, Color draw_color, Color item_color, Vector2 origin, float scale ) {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.EnableItemFilters ) { return; }

			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.IsCurrentWorldNihilated() ) { return; }

			if( item == null || item.IsAir ) { return; }

			if( !myworld.Logic.IsItemEnabled( item ) ) {
				float pos_x = position.X + (((float)frame.Width / 2f) * scale) - (((float)mymod.DisabledItem.Width / 2f) * scale);
				float pos_y = position.Y + (((float)frame.Height / 2f) * scale) - (((float)mymod.DisabledItem.Height / 2f) * scale);
				var pos = new Vector2( pos_x, pos_y );
				var rect = new Rectangle( 0, 0, mymod.DisabledItem.Width, mymod.DisabledItem.Height );

				sb.Draw( mymod.DisabledItem, pos, rect, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f );
			}
		}

		public override bool CanUseItem( Item item, Player player ) {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.EnableItemFilters ) { return base.CanUseItem( item, player ); }

			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.IsCurrentWorldNihilated() ) { return base.CanUseItem(item, player); }
			
			return myworld.Logic.IsItemEnabled( item );
		}
	}
}
