using HamstarHelpers.DebugHelpers;
using HamstarHelpers.MiscHelpers;
using HamstarHelpers.TmlHelpers;
using HamstarHelpers.Utilities.Messages;
using HamstarHelpers.Utilities.Network;
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

				if( !myworld.Logic.Data.IsActive() ) {
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
		
		public bool AreItemsFiltered( NihilismMod mymod ) {
			return this.Data.IsActive() && mymod.Config.EnableItemFilters;
		}

		public bool AreItemEquipsFiltered( NihilismMod mymod ) {
			return this.Data.IsActive() && mymod.Config.EnableItemEquipsFilters;
		}

		public bool AreRecipesFiltered( NihilismMod mymod ) {
			return this.Data.IsActive() && mymod.Config.EnableRecipeFilters;
		}

		public bool AreNpcsFiltered( NihilismMod mymod ) {
			return this.Data.IsActive() && mymod.Config.EnableNpcFilters;
		}

		public bool AreNpcLootsFiltered( NihilismMod mymod ) {
			return this.Data.IsActive() && mymod.Config.EnableNpcLootFilters;
		}
	}
}
