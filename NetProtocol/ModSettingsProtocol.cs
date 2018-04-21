using HamstarHelpers.Utilities.Network;
using Terraria;

namespace Nihilism.NetProtocol {
	class NihilismModSettingsProtocol : PacketProtocol {
		public NihilismConfigData Settings;

		
		public override void SetServerDefaults() {
			this.Settings = NihilismMod.Instance.Config;
		}
		
		public override void ReceiveOnClient() {
			NihilismMod.Instance.Config = this.Settings;
		}
	}
}
