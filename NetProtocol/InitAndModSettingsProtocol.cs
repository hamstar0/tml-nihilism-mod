using HamstarHelpers.Utilities.Network;


namespace Nihilism.NetProtocol {
	class NihilismInitAndModSettingsProtocol : PacketProtocol {
		public bool IsNihilistic;
		public NihilismConfigData Settings;


		////////////////

		public override void SetClientDefaults() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();

			this.IsNihilistic = myworld.Logic.IsNihilistic;
			this.Settings = NihilismMod.Instance.Config;
		}

		////////////////

		public override void ReceiveOnClient() {
			this.ReceiveOnAny();
		}

		public override void ReceiveOnServer( int from_who ) {
			this.ReceiveOnAny();
		}

		////////////////

		private void ReceiveOnAny() {
			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.NihiliateCurrentWorld( mymod, this.IsNihilistic );
			NihilismMod.Instance.Config = this.Settings;
		}
	}
}
