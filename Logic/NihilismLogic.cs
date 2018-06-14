using HamstarHelpers.DebugHelpers;
using HamstarHelpers.TmlHelpers;
using HamstarHelpers.Utilities.Messages;
using HamstarHelpers.Utilities.Network;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria;


namespace Nihilism.Logic {
	partial class NihilismLogic {
		public NihilismFilterAccess DataAccess { get; private set; }


		////////////////

		public NihilismLogic( NihilismMod mymod ) {
			var data = new NihilismFilterData();
			this.DataAccess = new NihilismFilterAccess( data );
		}


		////////////////
		
		public void LoadWorldData( NihilismMod mymod ) {
			this.DataAccess.Load( mymod );
		}

		public void SaveWorldData( NihilismMod mymod ) {
			this.DataAccess.Save( mymod );
		}


		////////////////

		internal void OnEnterWorldForSingle( NihilismMod mymod, Player player ) {
			this.OnFiltersLoad( mymod );
		}

		internal void OnEnterWorldForClient( NihilismMod mymod, Player player ) {
			PacketProtocol.QuickRequestToServer<ModSettingsProtocol>();
			PacketProtocol.QuickRequestToServer<FiltersProtocol>();
		}

		internal void OnEnterWorldForServer( NihilismMod mymod, Player player ) { }

		////////////////

		internal void OnFiltersLoad( NihilismMod mymod ) {
			TmlLoadHelpers.AddWorldLoadOncePromise( () => {
				if( Main.netMode == 2 ) { return; }

				var myworld = mymod.GetModWorld<NihilismWorld>();

				if( !myworld.Logic.DataAccess.IsActive() ) {
					string msg;
					if( Main.netMode == 0 ) {
						msg = "Enter the /nihon command to active Nihilism restrictions for the current world. Enter /help for a list of other commands.";
					} else {
						msg = "Enter nihon in the server's command console to activate Nihilism restrictions for the current world. Enter help for a list of other commands.";
					}

					InboxMessages.SetMessage( "nihilism_init", msg, false );
				}

				TmlLoadHelpers.TriggerCustomPromise( "NihilismOnEnterWorld" );
				TmlLoadHelpers.AddWorldUnloadOncePromise( () => {
					TmlLoadHelpers.ClearCustomPromise( "NihilismOnEnterWorld" );
				} );
			} );
		}


		////////////////

		public void SyncData() {
			var mymod = NihilismMod.Instance;

			if( Main.netMode == 1 ) {
				PacketProtocol.QuickSyncToServerAndClients<FiltersProtocol>();
			} else if( Main.netMode == 2 ) {
				if( !mymod.SuppressAutoSaving ) {
					this.SaveWorldData( NihilismMod.Instance );
				}
				PacketProtocol.QuickSendToClient<FiltersProtocol>( -1, -1 );
			}
		}


		////////////////
		
		public bool AreItemFiltersEnabled( NihilismMod mymod ) {
			return this.DataAccess.IsActive() && mymod.Config.EnableItemFilters;
		}

		public bool AreItemEquipsFiltersEnabled( NihilismMod mymod ) {
			return this.DataAccess.IsActive() && mymod.Config.EnableItemEquipsFilters;
		}

		public bool AreRecipesFiltersEnabled( NihilismMod mymod ) {
			return this.DataAccess.IsActive() && mymod.Config.EnableRecipeFilters;
		}

		public bool AreNpcsFiltersEnabled( NihilismMod mymod ) {
			return this.DataAccess.IsActive() && mymod.Config.EnableNpcFilters;
		}

		public bool AreNpcLootsFiltersEnabled( NihilismMod mymod ) {
			return this.DataAccess.IsActive() && mymod.Config.EnableNpcLootFilters;
		}
	}
}
