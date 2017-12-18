using HamstarHelpers.UIHelpers;
using HamstarHelpers.UIHelpers.Elements;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;


namespace Nihilism.ControlPanel {
	public class ControlPanelTheme : UITheme {
		public new Color MainBgColor = Color.Black;
		public new Color MainEdgeColor = Color.White;

		////////////////

		public new Color ButtonBgColor = new Color( 0, 0, 0, 128 );
		public new Color ButtonEdgeColor = new Color( 224, 224, 224, 224 );
		public new Color ButtonTextColor = new Color( 224, 224, 224, 224 );

		public new Color ButtonBgLitColor = new Color( 32, 32, 32, 160 );
		public new Color ButtonEdgeLitColor = new Color( 255, 255, 255, 255 );
		public new Color ButtonTextLitColor = new Color( 255, 255, 255, 255 );



		////////////////

		public override void ApplyPanel( UIPanel panel ) {
			panel.BackgroundColor = this.MainBgColor;
			panel.BorderColor = this.MainEdgeColor;
		}

		////////////////

		public override void ApplyButton( UITextPanelButton panel ) {
			panel.BackgroundColor = this.ButtonBgColor;
			panel.BorderColor = this.ButtonEdgeColor;
			panel.TextColor = this.ButtonTextColor;
		}

		public override void ApplyButtonLit( UITextPanelButton panel ) {
			panel.BackgroundColor = this.ButtonBgLitColor;
			panel.BorderColor = this.ButtonEdgeLitColor;
			panel.TextColor = this.ButtonTextLitColor;
		}
	}
}
