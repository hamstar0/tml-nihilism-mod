using HamstarHelpers.Components.Network;
using HamstarHelpers.DebugHelpers;
using HamstarHelpers.Services.Messages;
using HamstarHelpers.TmlHelpers;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria;


namespace Nihilism.Logic {
	partial class WorldLogic {
		public NihilismFilterAccess DataAccess { get; private set; }


		////////////////

		public WorldLogic( NihilismMod mymod ) {
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

		internal void PostFiltersLoad( NihilismMod mymod ) {
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

		public void SyncDataChanges() {
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
			return this.DataAccess.IsActive() && mymod.ServerConfig.EnableItemFilters;
		}

		public bool AreItemEquipsFiltersEnabled( NihilismMod mymod ) {
			return this.DataAccess.IsActive() && mymod.ServerConfig.EnableItemEquipsFilters;
		}

		public bool AreRecipesFiltersEnabled( NihilismMod mymod ) {
			return this.DataAccess.IsActive() && mymod.ServerConfig.EnableRecipeFilters;
		}

		public bool AreNpcsFiltersEnabled( NihilismMod mymod ) {
			return this.DataAccess.IsActive() && mymod.ServerConfig.EnableNpcFilters;
		}

		public bool AreNpcLootsFiltersEnabled( NihilismMod mymod ) {
			return this.DataAccess.IsActive() && mymod.ServerConfig.EnableNpcLootFilters;
		}
	}
}
