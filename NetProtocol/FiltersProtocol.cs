using HamstarHelpers.Classes.Errors;
using HamstarHelpers.Classes.Protocols.Packet.Interfaces;
using HamstarHelpers.Helpers.TModLoader;
using Nihilism.Data;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.NetProtocol {
	class FiltersProtocol : PacketProtocolSyncClient {
		public static void SyncToMe() {
			PacketProtocolSyncClient.SyncToMe<FiltersProtocol>( -1 );
		}

		public static void SyncFromMe() {
			PacketProtocolSyncClient.SyncFromMe<FiltersProtocol>();
		}

		public static void QuickSendToClient() {
			PacketProtocolSyncClient.QuickSendToClient<FiltersProtocol>( -1, -1 );
		}



		////////////////

		public NihilismFilterConfig Filters;



		////////////////

		private FiltersProtocol() { }


		////////////////

		protected override void InitializeClientSendData() {
			this.SetMyDefaults();
		}

		protected override void InitializeServerRequestReplyDataOfClient( int toWho, int fromWho ) {
			this.SetMyDefaults();
		}

		private void SetMyDefaults() {
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic.DataAccess == null ) { throw new ModHelpersException( "No filters to send" ); }

			myworld.Logic.DataAccess.Give( ref this.Filters );
		}


		////////////////

		private void ReceiveOnAny() {
			var mymod = NihilismMod.Instance;
			var myworld = ModContent.GetInstance<NihilismWorld>();

			myworld.Logic.DataAccess.Take( this.Filters );

			mymod.RunSyncOrWorldLoadActions( true );
		}

		////////////////

		protected override void ReceiveOnServer( int from_who ) {
			this.ReceiveOnAny();
		}

		protected override void ReceiveOnClient() {
			this.ReceiveOnAny();

			var mymod = NihilismMod.Instance;
			var myworld = ModContent.GetInstance<NihilismWorld>();
			var myplayer = (NihilismPlayer)TmlHelpers.SafelyGetModPlayer( Main.LocalPlayer, mymod, "NihilismPlayer" );

			myworld.Logic.PostFiltersLoad();

			myplayer.FinishFiltersSync();
		}
	}
}
