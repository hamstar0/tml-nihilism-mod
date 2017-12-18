using HamstarHelpers.HudHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;


namespace Nihilism.UI {
	partial class ControlPanelUI : UIState {
		private static Vector2 TogglerSize = new Vector2( 12, 128 );
		

		////////////////

		public bool IsTogglerLit { get; private set; }


		////////////////

		private void InitializeToggler() {
			this.IsTogglerLit = false;
		}


		////////////////

		public bool IsTogglerShown() {
			return Main.playerInventory;
		}


		////////////////

		public void UpdateToggler() {
			this.CheckTogglerMouseInteraction();

			if( this.IsTogglerLit ) {
				Main.LocalPlayer.mouseInterface = true;
			}
		}


		////////////////

		public void DrawToggler( SpriteBatch sb ) {
			if( !this.IsTogglerShown() ) { return; }
			
			Color color;
			Vector2 pos = new Vector2( 0, (Main.screenHeight / 2) - (ControlPanelUI.TogglerSize.Y / 2) );

			if( this.IsTogglerLit ) {
				color = new Color( 192, 192, 192, 192 );
			} else {
				color = new Color( 160, 160, 160, 160 );
			}
			
			HudHelpers.DrawBorderedRect( sb, Color.Black, color, pos, ControlPanelUI.TogglerSize, 1 );
		}

		////////////////

		private void CheckTogglerMouseInteraction() {
			bool is_click = Main.mouseLeft && Main.mouseLeftRelease;
			Vector2 pos = new Vector2( 0, (Main.screenHeight / 2) - (ControlPanelUI.TogglerSize.Y / 2) );
			Vector2 size = ControlPanelUI.TogglerSize;

			this.IsTogglerLit = false;

			if( this.IsTogglerShown() ) {
				if( Main.mouseX >= pos.X && Main.mouseX < (pos.X + size.X) ) {
					if( Main.mouseY >= pos.Y && Main.mouseY < (pos.Y + size.Y) ) {
						if( is_click && !this.HasClicked ) {
							if( this.IsOpen ) {
								this.Close();
							} else if( this.CanOpen() ) {
								this.Open();
							}
						}

						this.IsTogglerLit = true;
					}
				}
			}

			this.HasClicked = is_click;
		}
	}
}
