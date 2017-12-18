using HamstarHelpers.UIHelpers.Elements;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;


namespace Nihilism.UI {
	partial class ControlPanelUI : UIState {
		public static float ContainerWidth = 288f;
		public static float ContainerHeight = 84f;

		public static Color ButtonEdgeColor = new Color( 128, 128, 128 );
		public static Color ButtonBodyColor = new Color( 16, 16, 16 );
		public static Color ButtonBodyLitColor = new Color( 32, 32, 32 );



		public void InitializeComponents() {
			ControlPanelUI self = this;
			float top = 0;

			this.OuterContainer = new UIElement();
			this.OuterContainer.Width.Set( ControlPanelUI.ContainerWidth, 0f );
			this.OuterContainer.Height.Set( ControlPanelUI.ContainerHeight, 0f );
			this.OuterContainer.MaxWidth.Set( ControlPanelUI.ContainerWidth, 0f );
			this.OuterContainer.MaxHeight.Set( ControlPanelUI.ContainerHeight, 0f );
			this.OuterContainer.HAlign = 0f;
			//this.MainElement.BackgroundColor = ControlPanelUI.MainBgColor;
			//this.MainElement.BorderColor = ControlPanelUI.MainEdgeColor;
			this.Append( this.OuterContainer );

			CalculatedStyle dim = this.OuterContainer.GetDimensions();
			this.OuterContainer.Left.Set( dim.Width * -0.5f, 0.5f );
			this.OuterContainer.Top.Set( dim.Height * -0.5f, 0.5f );

			this.InnerContainer = new UIPanel();
			this.InnerContainer.Width.Set( 0f, 1f );
			this.InnerContainer.Height.Set( 0f, 1f );
			this.OuterContainer.Append( (UIElement)this.InnerContainer );

			this.Theme.ApplyPanel( this.InnerContainer );

			top += 2f;
			this.ActivateButton = new UITextPanelButton( this.Theme, "Enable Nihilism for this world" );
			this.ActivateButton.SetPadding( 4f );
			this.ActivateButton.Width.Set( ControlPanelUI.PanelWidth - 24f, 0f );
			this.ActivateButton.Left.Set( 0f, 0 );
			this.ActivateButton.Top.Set( top, 0f );
			this.ActivateButton.BackgroundColor = ControlPanelUI.ButtonBodyColor;
			this.ActivateButton.BorderColor = ControlPanelUI.ButtonEdgeColor;
			this.ActivateButton.OnClick += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				self.ActivateNihilism();
				self.Close();
			};
			this.ActivateButton.OnMouseOver += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				self.ActivateButton.BackgroundColor = ControlPanelUI.ButtonBodyLitColor;
			};
			this.ActivateButton.OnMouseOut += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				self.ActivateButton.BackgroundColor = ControlPanelUI.ButtonBodyColor;
			};
			this.InnerContainer.Append( this.ActivateButton );

			top += 32f;
			this.DeactivateButton = new UITextPanelButton( this.Theme, "Disable Nihilism for this world" );
			this.DeactivateButton.SetPadding( 4f );
			this.DeactivateButton.Width.Set( ControlPanelUI.PanelWidth - 24f, 0f );
			this.DeactivateButton.Left.Set( 0f, 0 );
			this.DeactivateButton.Top.Set( top, 0f );
			this.DeactivateButton.BackgroundColor = ControlPanelUI.ButtonBodyColor;
			this.DeactivateButton.BorderColor = ControlPanelUI.ButtonEdgeColor;
			this.DeactivateButton.OnClick += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				self.DeactivateNihilism();
				self.Close();
			};
			this.DeactivateButton.OnMouseOver += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				self.DeactivateButton.BackgroundColor = ControlPanelUI.ButtonBodyLitColor;
			};
			this.DeactivateButton.OnMouseOut += delegate ( UIMouseEvent evt, UIElement listeningElement ) {
				self.DeactivateButton.BackgroundColor = ControlPanelUI.ButtonBodyColor;
			};
			this.InnerContainer.Append( this.DeactivateButton );
		}
	}
}
