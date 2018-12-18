using HamstarHelpers.Components.Network;
using HamstarHelpers.Components.Network.Data;
using Nihilism.Data;
using Terraria;


namespace Nihilism.NetProtocol {
	class ModSettingsProtocol : PacketProtocolRequestToServer {
		public NihilismConfigData Settings;


		////////////////

		protected ModSettingsProtocol( PacketProtocolDataConstructorLock ctor_lock ) : base( ctor_lock ) { }

		protected override void InitializeServerSendData( int to_who ) {
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
