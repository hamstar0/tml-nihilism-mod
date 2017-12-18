using HamstarHelpers.UIHelpers;
using HamstarHelpers.UIHelpers.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nihilism.ControlPanel;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;


namespace Nihilism.UI {
	partial class ControlPanelUI : UIState {
		public static float PanelWidth = 288f;
		public static float PanelHeight = 84f;
		

		public bool IsOpen { get; private set; }

		private UITheme Theme = new ControlPanelTheme();
		private UserInterface Backend = null;

		private UIElement OuterContainer = null;
		private UIPanel InnerContainer = null;
		
		private UITextPanelButton ActivateButton = null;
		private UITextPanelButton DeactivateButton = null;

		private bool HasClicked = false;
		
		private bool CloseDialog = false;


		////////////////

		public ControlPanelUI() {
			this.IsOpen = false;
			this.InitializeToggler();
		}

		public override void OnInitialize() {
			this.InitializeComponents();
		}


		////////////////

		public void UpdateInteractivity( GameTime game_time ) {
			if( this.Backend == null ) { return; }

			this.Backend.Update( game_time );
		}


		public void UpdateDialog() {
			if( !this.IsOpen ) { return; }

			if( Main.playerInventory || Main.npcChatText != "" ) {
				this.Close();
				return;
			}

			if( this.OuterContainer.IsMouseHovering ) {
				Main.LocalPlayer.mouseInterface = true;
			}

			if( this.CloseDialog ) {
				this.CloseDialog = false;
				if( this.IsOpen ) {
					this.Close();
				}
			}
		}


		////////////////

		public void RecalculateBackend() {
			if( this.Backend != null ) {
				this.Backend.Recalculate();
			}
		}


		////////////////

		public override void Draw( SpriteBatch sb ) {
			if( !this.IsOpen ) { return; }

			base.Draw( sb );
		}


		////////////////

		public bool CanOpen() {
			return !this.IsOpen && !Main.inFancyUI;
		}


		public void Open() {
			this.IsOpen = true;

			Main.playerInventory = false;
			Main.editChest = false;
			Main.npcChatText = "";

			Main.inFancyUI = true;
			Main.InGameUI.SetState( (UIState)this );

			this.OuterContainer.Top.Set( -(ControlPanelUI.ContainerHeight * 0.5f), 0.5f );
			this.OuterContainer.Left.Set( -(ControlPanelUI.ContainerWidth * 0.5f), 0.5f );
			this.Recalculate();

			this.Backend = Main.InGameUI;
			UserInterface.ActiveInstance = this.Backend;
		}


		public void Close() {
			this.IsOpen = false;

			//this.Container.Top.Set( -ControlPanelUI.PanelHeight * 2f, 0f );
			this.Deactivate();

			Main.inFancyUI = false;
			Main.InGameUI.SetState( (UIState)null );

			this.Backend = null;
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
