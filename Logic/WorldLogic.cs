using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Services.Hooks.LoadHooks;
using HamstarHelpers.Services.Messages.Inbox;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria;


namespace Nihilism.Logic {
	partial class WorldLogic {
		internal readonly static object MyValidatorKey;
		public readonly static CustomLoadHookValidator<object> LoadAllValidator;



		////////////////

		static WorldLogic() {
			WorldLogic.MyValidatorKey = new object();
			WorldLogic.LoadAllValidator = new CustomLoadHookValidator<object>( WorldLogic.MyValidatorKey );
		}


		////////////////
		public NihilismFilterAccess DataAccess { get; private set; }


		////////////////

		public WorldLogic() {
			this.DataAccess = new NihilismFilterAccess();
		}


		////////////////
		
		public void LoadWorldData() {
			//this.DataAccess.Load();
		}

		public void SaveWorldData() {
			//this.DataAccess.Save();
		}
		

		////////////////

		internal void PostFiltersLoad() {
			LoadHooks.AddWorldLoadOnceHook( () => {
				if( Main.netMode == 2 ) { return; }

				var mymod = NihilismMod.Instance;
				var myworld = mymod.GetModWorld<NihilismWorld>();

				if( !myworld.Logic.DataAccess.IsActive() ) {
					string msg;
					if( Main.netMode == 0 ) {
						msg = "Enter the /nih-on command to active Nihilism restrictions for the current world. Enter /help for a list of other commands.";
					} else {
						msg = "Enter nih-on in the server's command console to activate Nihilism restrictions for the current world. Enter help for a list of other commands.";
					}

					InboxMessages.SetMessage( "nihilism_init", msg, false );
				}

				CustomLoadHooks.TriggerHook( WorldLogic.LoadAllValidator, WorldLogic.MyValidatorKey );
				LoadHooks.AddWorldUnloadOnceHook( () => {
					CustomLoadHooks.ClearHook( WorldLogic.LoadAllValidator, WorldLogic.MyValidatorKey );
				} );
			} );
		}


		////////////////

		public void SyncDataChanges() {
			var mymod = NihilismMod.Instance;

			if( Main.netMode == 1 ) {
				FiltersProtocol.SyncFromMe();
			} else if( Main.netMode == 2 ) {
				if( !mymod.InstancedFilters ) {
					this.SaveWorldData();
				}
				FiltersProtocol.QuickSendToClient();
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
