using HamstarHelpers.HudHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;


namespace Nihilism {
	class NihilismUI : UIState {
		public static float PanelWidth = 288f;
		public static float PanelHeight = 84f;
		public static Color ButtonEdgeColor = new Color( 128, 128, 128 );
		public static Color ButtonBodyColor = new Color( 16, 16, 16 );
		public static Color ButtonBodyLitColor = new Color( 32, 32, 32 );

		public UIPanel MainPanel;
		private UserInterface Backend;

		public bool IsOpen { get; private set; }
		public bool IsTogglerLit { get; private set; }

		private bool HasBeenSetup = false;



		////////////////

		public NihilismUI() {
			this.Backend = new UserInterface();
			this.IsOpen = false;
			this.IsTogglerLit = false;
		}

		public void PostSetupContent() {
			this.Activate();
			this.Backend.SetState( this );
			this.HasBeenSetup = true;
		}


		////////////////

		public override void OnInitialize() {
			float top = 0;
			
			this.MainPanel = new UIPanel();
			this.MainPanel.Left.Set( -(NihilismUI.PanelWidth / 2f), 0.5f );
			this.MainPanel.Top.Set( 8f - NihilismUI.PanelHeight, 0f );
			this.MainPanel.Width.Set( NihilismUI.PanelWidth, 0f );
			this.MainPanel.Height.Set( NihilismUI.PanelHeight, 0f );
			this.MainPanel.SetPadding( 12f );
			this.MainPanel.BackgroundColor = new Color( 0, 0, 0 );

			top += 2f;
			var enable_button = new UITextPanel<string>( "Enable Nihilism for this world" );
			enable_button.SetPadding( 4f );
			enable_button.Width.Set( NihilismUI.PanelWidth - 24f, 0f );
			enable_button.Left.Set( 0f, 0 );
			enable_button.Top.Set( top, 0f );
			enable_button.BackgroundColor = NihilismUI.ButtonBodyColor;
			enable_button.BorderColor = NihilismUI.ButtonEdgeColor;
			enable_button.OnClick += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				this.ActivateNihilism();
			};
			enable_button.OnMouseOver += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				enable_button.BackgroundColor = NihilismUI.ButtonBodyLitColor;
			};
			enable_button.OnMouseOut += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				enable_button.BackgroundColor = NihilismUI.ButtonBodyColor;
			};
			this.MainPanel.Append( enable_button );

			top += 32f;
			var disable_button = new UITextPanel<string>( "Disable Nihilism for this world" );
			disable_button.SetPadding( 4f );
			disable_button.Width.Set( NihilismUI.PanelWidth - 24f, 0f );
			disable_button.Left.Set( 0f, 0 );
			disable_button.Top.Set( top, 0f );
			disable_button.BackgroundColor = NihilismUI.ButtonBodyColor;
			disable_button.BorderColor = NihilismUI.ButtonEdgeColor;
			disable_button.OnClick += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				this.DeactivateNihilism();
			};
			disable_button.OnMouseOver += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				disable_button.BackgroundColor = NihilismUI.ButtonBodyLitColor;
			};
			disable_button.OnMouseOut += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				disable_button.BackgroundColor = NihilismUI.ButtonBodyColor;
			};
			this.MainPanel.Append( disable_button );

			this.Append( this.MainPanel );
		}


		////////////////

		public void UpdateBackend( GameTime game_time ) {
			if( !this.HasBeenSetup ) { return; }
			this.Backend.Update( game_time );
		}

		public override void Update( GameTime game_time ) {
			base.Update( game_time );

			if( this.MainPanel.ContainsPoint( Main.MouseScreen ) ) {
				Main.LocalPlayer.mouseInterface = true;
			}
		}

		////////////////

		public void RecalculateBackend() {
			if( !this.HasBeenSetup ) { return; }
			this.Backend.Recalculate();
		}


		////////////////

		public void Open() {
			this.IsOpen = true;
		}

		public void Close() {
			this.IsOpen = false;
		}


		private void GetTogglerDimensions( out Vector2 pos, out Vector2 size ) {
			size = new Vector2( 6, NihilismUI.PanelHeight );
			float y = ((Main.screenHeight / 2f) - (NihilismUI.PanelHeight / 2f));

			if( this.IsOpen ) {
				pos = new Vector2( (Main.screenWidth / 2f) - (NihilismUI.PanelWidth / 2f), y );
			} else {
				pos = new Vector2( 2, y );
			}
		}

		public void DrawToggler( SpriteBatch sb ) {
			Vector2 pos, size;
			Color body_color = NihilismUI.ButtonBodyColor;
			Color edge_color = NihilismUI.ButtonEdgeColor;

			if( this.IsTogglerLit ) { body_color = NihilismUI.ButtonBodyLitColor; }
			this.GetTogglerDimensions( out pos, out size );
			
			HudHelpers.DrawBorderedRect( sb, body_color, edge_color, pos, size, 2 );
		}
		
		public void CheckTogglerMouseInteraction() {
			bool is_click = Main.mouseLeft && Main.mouseLeftRelease;
			bool lit = false;
			Vector2 pos, size;

			this.GetTogglerDimensions( out pos, out size );
			
			if( Main.mouseX >= pos.X && Main.mouseX < (pos.X+size.X) ) {
				if( Main.mouseY >= pos.Y && Main.mouseY < (pos.Y + size.Y) ) {
					if( is_click ) {
						if( this.IsOpen ) { this.Close(); }
						else { this.Open(); }
					} else {
						lit = true;
					}
				}
			}
			
			this.IsTogglerLit = lit;
		}

		////////////////

		public override void Draw( SpriteBatch spriteBatch ) {
			if( !this.IsOpen ) { return; }
			base.Draw( spriteBatch );
		}


		////////////////

		private void ActivateNihilism() {
			var mymod = NihilismMod.Instance;
			var modworld = mymod.GetModWorld<NihilismWorld>();
			modworld.Logic.NihiliateCurrentWorld( mymod, true );
		}

		private void DeactivateNihilism() {
			var mymod = NihilismMod.Instance;
			var modworld = mymod.GetModWorld<NihilismWorld>();
			modworld.Logic.NihiliateCurrentWorld( mymod, false );
		}
	}
}
