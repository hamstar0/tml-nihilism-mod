using HamstarHelpers.Utilities.Network;
using Nihilism.Data;


namespace Nihilism.NetProtocol {
	class NihilismModSettingsProtocol : PacketProtocol {
		public NihilismConfigData Settings;

		
		public override void SetServerDefaults() {
			this.Settings = NihilismMod.Instance.Config;
		}
		
		protected override void ReceiveWithClient() {
			NihilismMod.Instance.Config = this.Settings;
		}
	}
}
