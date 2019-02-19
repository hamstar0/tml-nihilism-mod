using HamstarHelpers.Components.Network;
using Nihilism.Data;
using Terraria;


namespace Nihilism.NetProtocol {
	class ModSettingsProtocol : PacketProtocolRequestToServer {
		public NihilismConfigData Settings;


		////////////////

		private ModSettingsProtocol() { }

		protected override void InitializeServerSendData( int toWho ) {
			this.Settings = NihilismMod.Instance.Config;
		}

		////////////////

		protected override void ReceiveReply() {
			var mymod = NihilismMod.Instance;
			var myplayer = Main.LocalPlayer.GetModPlayer<NihilismPlayer>();

			mymod.ConfigJson.SetData( this.Settings );

			myplayer.FinishModSettingsSync();
		}
	}
}
