using HamstarHelpers.Components.Network;
using Nihilism.Data;
using Terraria;


namespace Nihilism.NetProtocol {
	class ModSettingsProtocol : PacketProtocol {
		public NihilismConfigData Settings;


		////////////////

		protected override void SetServerDefaults() {
			this.Settings = NihilismMod.Instance.Config;
		}

		////////////////

		protected override void ReceiveWithClient() {
			var mymod = NihilismMod.Instance;
			var myplayer = Main.LocalPlayer.GetModPlayer<NihilismPlayer>();

			mymod.ConfigJson.SetData( this.Settings );

			myplayer.FinishModSettingsSync();
		}
	}
}
