using HamstarHelpers.Components.Network;
using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Services.Messages;
using HamstarHelpers.Services.Promises;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria;


namespace Nihilism.Logic {
	partial class WorldLogic {
		internal readonly static object MyValidatorKey;
		public readonly static PromiseValidator LoadAllValidator;



		////////////////

		static WorldLogic() {
			WorldLogic.MyValidatorKey = new object();
			WorldLogic.LoadAllValidator = new PromiseValidator( WorldLogic.MyValidatorKey );
		}


		////////////////
		public NihilismFilterAccess DataAccess { get; private set; }


		////////////////

		public WorldLogic() {
			this.DataAccess = new NihilismFilterAccess();
		}


		////////////////
		
		public void LoadWorldData() {
			this.DataAccess.Load();
		}

		public void SaveWorldData() {
			this.DataAccess.Save();
		}
		

		////////////////

		internal void PostFiltersLoad() {
			Promises.AddWorldLoadOncePromise( () => {
				if( Main.netMode == 2 ) { return; }

				var mymod = NihilismMod.Instance;
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

				Promises.TriggerValidatedPromise( WorldLogic.LoadAllValidator, WorldLogic.MyValidatorKey );
				Promises.AddWorldUnloadOncePromise( () => {
					Promises.ClearValidatedPromise( WorldLogic.LoadAllValidator, WorldLogic.MyValidatorKey );
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
					this.SaveWorldData();
				}
				PacketProtocol.QuickSendToClient<FiltersProtocol>( -1, -1 );
			}
		}


		////////////////
		
		public bool AreItemFiltersEnabled() {
			var mymod = NihilismMod.Instance;
			return this.DataAccess.IsActive() && mymod.Config.EnableItemFilters;
		}

		public bool AreItemEquipsFiltersEnabled() {
			var mymod = NihilismMod.Instance;
			return this.DataAccess.IsActive() && mymod.Config.EnableItemEquipsFilters;
		}

		public bool AreRecipesFiltersEnabled() {
			var mymod = NihilismMod.Instance;
			return this.DataAccess.IsActive() && mymod.Config.EnableRecipeFilters;
		}

		public bool AreNpcsFiltersEnabled() {
			var mymod = NihilismMod.Instance;
			return this.DataAccess.IsActive() && mymod.Config.EnableNpcFilters;
		}

		public bool AreNpcLootsFiltersEnabled() {
			var mymod = NihilismMod.Instance;
			return this.DataAccess.IsActive() && mymod.Config.EnableNpcLootFilters;
		}
	}
}
