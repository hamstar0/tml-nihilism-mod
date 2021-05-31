using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Services.Network.SimplePacket;
using Nihilism.Data;


namespace Nihilism.NetProtocol {
	[Serializable]
	class FiltersRequestProtocol : SimplePacketPayload {
		public static void QuickRequestFromMeToServer() {
			if( Main.netMode != NetmodeID.MultiplayerClient ) {
				throw new ModLibsException( "Not client." );
			}
			
			var packet = new FiltersRequestProtocol();

			SimplePacket.SendToServer( packet );
		}



		////////////////

		public override void ReceiveOnClient() {
			throw new NotImplementedException();
		}

		public override void ReceiveOnServer( int fromWho ) {
			FiltersProtocol.QuickSendToClient();
		}
	}




	[Serializable]
	class FiltersProtocol : SimplePacketPayload {
		public static void SyncFromMe() {
			var packet = new FiltersProtocol();
			packet.SetMyDefaults();

			SimplePacket.SendToServer( packet );
		}

		public static void QuickSendToClient( int toWho = -1, int ignoreWho = -1 ) {
			var packet = new FiltersProtocol();
			packet.SetMyDefaults();

			SimplePacket.SendToClient( packet, toWho, ignoreWho );
		}



		////////////////

		public NihilismFilters Filters;



		////////////////

		private FiltersProtocol() { }

		////

		private void SetMyDefaults() {
			var myworld = ModContent.GetInstance<NihilismWorld>();
			if( myworld.Logic.DataAccess == null ) { throw new ModLibsException( "No filters to send" ); }
			
			myworld.Logic.DataAccess.Give( ref this.Filters );
		}


		////////////////

		public override void ReceiveOnServer( int fromWho ) {
			this.ReceiveOnAny();

			// This is already being received from a client
			SimplePacket.SendToClient( this, -1, fromWho );
		}

		public override void ReceiveOnClient() {
			this.ReceiveOnAny();

			var myworld = ModContent.GetInstance<NihilismWorld>();
			var customPlrData = NihilismCustomPlayer.GetPlayerData<NihilismCustomPlayer>( Main.myPlayer );

			myworld.Logic.PostFiltersLoad();

			customPlrData.FinishFiltersSync();
		}


		////////////////

		private void ReceiveOnAny() {
			var mymod = NihilismMod.Instance;
			var myworld = ModContent.GetInstance<NihilismWorld>();

			//LogLibraries.LogOnce( "\n"+JsonConvert.SerializeObject(this.Filters, Formatting.Indented)+"\n" );
			myworld.Logic.DataAccess.Take( this.Filters );

			mymod.RunSyncOrWorldLoadActions( true );
		}
	}
}
