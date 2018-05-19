using HamstarHelpers.DebugHelpers;
using HamstarHelpers.MiscHelpers;
using HamstarHelpers.TmlHelpers;
using HamstarHelpers.Utilities.Messages;
using HamstarHelpers.Utilities.Network;
using HamstarHelpers.WorldHelpers;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria;


namespace Nihilism.Logic {
	partial class NihilismLogic {
		public NihilismFilterAccess Data { get; private set; }


		////////////////

		public NihilismLogic() {
			this.Data = new NihilismFilterAccess( new NihilismFilterData() );
		}

		////////////////

		public bool IsCurrentWorldNihilated() {
			return this.Data.IsActive();
		}


		////////////////
		
		public void LoadWorldData( NihilismMod mymod ) {
			this.Data.Load( mymod );
		}

		public void SaveWorldData( NihilismMod mymod ) {
			this.Data.Save( mymod );
		}


		////////////////

		internal void OnEnterWorldForSingle( NihilismMod mymod, Player player ) {
			this.OnPostFiltersSyncToMe( mymod );
		}

		internal void OnEnterWorldForClient( NihilismMod mymod, Player player ) {
			PacketProtocol.QuickRequestToServer<ModSettingsProtocol>();
			PacketProtocol.QuickRequestToServer<WorldFiltersProtocol>();
		}

		internal void OnEnterWorldForServer( NihilismMod mymod, Player player ) { }

		////////////////

		internal void OnPostFiltersSyncToMe( NihilismMod mymod ) {
			TmlLoadHelpers.AddWorldLoadPromise( () => {
				if( Main.netMode == 2 ) { return; }

				var myworld = mymod.GetModWorld<NihilismWorld>();

				if( !myworld.Logic.IsCurrentWorldNihilated() ) {
					string msg;
					if( Main.netMode == 0 ) {
						msg = "Enter the /nihilate command to active Nihilism restrictions for the current world. Enter /help for a list of other commands.";
					} else {
						msg = "Enter nihilate in the server's command console to activate Nihilism restrictions for the current world. Enter help for a list of other commands.";
					}

					InboxMessages.SetMessage( "nihilism_init", msg, false );
				}
			} );
		}


		////////////////

		public void SyncData() {
			var mymod = NihilismMod.Instance;

			if( Main.netMode == 1 ) {
				PacketProtocol.QuickSyncToServerAndClients<WorldFiltersProtocol>();
			} else if( Main.netMode == 2 ) {
				if( !mymod.SuppressAutoSaving ) {
					this.SaveWorldData( NihilismMod.Instance );
				}
				PacketProtocol.QuickSendToClient<WorldFiltersProtocol>( -1, -1 );
			}
		}


		////////////////

		public void NihilateCurrentWorld() {
			this.Data.IsActive = true;
			this.SyncData();
		}

		public void UnnihilateCurrentWorld() {
			this.Data.IsActive = false;
			this.SyncData();
		}
	}
}
