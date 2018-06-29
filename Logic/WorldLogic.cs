using HamstarHelpers.Components.Network;
using HamstarHelpers.DebugHelpers;
using HamstarHelpers.Services.Messages;
using HamstarHelpers.Services.Promises;
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
			Promises.AddWorldLoadOncePromise( () => {
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

				Promises.TriggerCustomPromise( "NihilismOnEnterWorld" );
				Promises.AddWorldUnloadOncePromise( () => {
					Promises.ClearCustomPromise( "NihilismOnEnterWorld" );
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
