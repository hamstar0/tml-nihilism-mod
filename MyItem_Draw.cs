using HamstarHelpers.Helpers.Debug;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismItem : GlobalItem {
		public override void ModifyTooltips( Item item, List<TooltipLine> tooltips ) {
			var mymod = (NihilismMod)this.mod;

			if( mymod.Config.DebugModePerItemInfo ) {
				IList<string> blGrps = NihilismAPI.GetItemBlacklistGroupsForItem( item );
				IList<string> bl2Grps = NihilismAPI.GetItemBlacklist2GroupsForItem( item );
				IList<string> wlGrps = NihilismAPI.GetItemWhitelistGroupsForItem( item );

				if( blGrps != null && blGrps.Count > 0 ) {
					var tip = new TooltipLine( mymod, item.Name + "_BlacklistGroups", "Blacklisted by groups: " + string.Join( ", ", blGrps ) );
					tooltips.Add( tip );
				}
				if( wlGrps != null && wlGrps.Count > 0 ) {
					var tip = new TooltipLine( mymod, item.Name + "_WhitelistGroups", "Whitelisted by groups: " + string.Join( ", ", wlGrps ) );
					tooltips.Add( tip );
				}
				if( bl2Grps != null && bl2Grps.Count > 0 ) {
					var tip = new TooltipLine( mymod, item.Name + "_Blacklist2Groups", "Blacklisted2 by groups: " + string.Join( ", ", bl2Grps ) );
					tooltips.Add( tip );
				}
			}
		}

		////////////////

		public override void PostDrawInInventory( Item item, SpriteBatch sb, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale ) {
			if( item == null || item.IsAir ) { return; }

			var mymod = (NihilismMod)this.mod;
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic == null ) {
				LogHelpers.WarnOnce( "Logic not loaded." );
				return;
			}

			if( !myworld.Logic.AreItemFiltersEnabled() ) {
				return;
			}
			
			bool _;
			if( !myworld.Logic.DataAccess.IsItemEnabled( item, out _, out _ ) ) {
				float posX = position.X + (((float)frame.Width / 2f) * scale) - (((float)mymod.DisabledItemTex.Width / 2f) * scale);
				float posY = position.Y + (((float)frame.Height / 2f) * scale) - (((float)mymod.DisabledItemTex.Height / 2f) * scale);
				var pos = new Vector2( posX, posY );
				var rect = new Rectangle( 0, 0, mymod.DisabledItemTex.Width, mymod.DisabledItemTex.Height );
				var color = Color.White * 0.625f;

				sb.Draw( mymod.DisabledItemTex, pos, rect, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f );
			}
		}
	}
}
