using Terraria;
using Terraria.ModLoader;
using HamstarHelpers.Classes.Errors;
using HamstarHelpers.Classes.Protocols.Packet.Interfaces;
using HamstarHelpers.Helpers.Debug;
using Nihilism.Data;


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

		public NihilismFilters Filters;



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

//LogHelpers.LogOnce( "\n"+JsonConvert.SerializeObject(this.Filters, Formatting.Indented)+"\n" );
			myworld.Logic.DataAccess.Take( this.Filters );

			mymod.RunSyncOrWorldLoadActions( true );
		}

		////////////////

		protected override void ReceiveOnServer( int fromWho ) {
			this.ReceiveOnAny();
		}

		protected override void ReceiveOnClient() {
			this.ReceiveOnAny();

			var myworld = ModContent.GetInstance<NihilismWorld>();
			var customPlrData = NihilismCustomPlayer.GetPlayerData<NihilismCustomPlayer>( Main.myPlayer );

			myworld.Logic.PostFiltersLoad();

			customPlrData.FinishFiltersSync();
		}
	}
}
