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
		internal NihilismFilterData Data = null;


		////////////////

		public NihilismLogic() {
			this.Data = new NihilismFilterData();
		}

		////////////////

		public bool IsCurrentWorldNihilated() {
			return this.Data.IsActive;
		}


		////////////////

		private string GetDataFileName() {
			return WorldHelpers.GetUniqueId( true ) + " Filters";
		}

		public void LoadWorldData( NihilismMod mymod ) {
			bool success;
			var filters = DataFileHelpers.LoadJson<NihilismFilterData>( mymod, this.GetDataFileName(), out success );

			if( success ) {
				this.Data = filters;
			}
		}

		public void SaveWorldData( NihilismMod mymod ) {
			DataFileHelpers.SaveAsJson<NihilismFilterData>( mymod, this.GetDataFileName(), this.Data );
		}


		////////////////

		internal void OnEnterWorldForSingle( NihilismMod mymod, Player player ) {
			this.OnPostFiltersSyncToMe( mymod );
		}

		internal void OnEnterWorldForClient( NihilismMod mymod, Player player ) {
			PacketProtocol.QuickRequestFromServer<ModSettingsProtocol>();
			PacketProtocol.QuickRequestFromServer<WorldFiltersProtocol>();
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
