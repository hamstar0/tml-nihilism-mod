using HamstarHelpers.Utilities.Network;
using Nihilism.Data;


namespace Nihilism.NetProtocol {
	class ModSettingsProtocol : PacketProtocol {
		public NihilismConfigData Settings;

		
		public override void SetServerDefaults() {
			this.Settings = NihilismMod.Instance.Config;
		}
		
		protected override void ReceiveWithClient() {
			NihilismMod.Instance.JsonConfig.SetData( this.Settings );
		}
	}
}
