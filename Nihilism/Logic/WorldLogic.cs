﻿using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Services.Hooks.LoadHooks;
using HamstarHelpers.Services.Messages.Inbox;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria;
using Terraria.ModLoader;


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
		public NihilismFiltersAccess DataAccess { get; private set; }


		////////////////

		public WorldLogic() {
			this.DataAccess = new NihilismFiltersAccess();
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
			LoadHooks.AddWorldLoadOnceHook( () => {
				if( Main.netMode == 2 ) { return; }

				var mymod = NihilismMod.Instance;
				var myworld = ModContent.GetInstance<NihilismWorld>();

				if( !myworld.Logic.DataAccess.IsActive() ) {
					string msg;
					if( Main.netMode == 0 ) {
						msg = "Enter the /nih-on command to activate Nihilism restrictions for the current world. Enter /help for a list of other commands.";
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
			return this.DataAccess.IsActive() && NihilismConfig.Instance.EnableItemFilters;
		}

		public bool AreItemEquipsFiltersEnabled() {
			return this.DataAccess.IsActive() && NihilismConfig.Instance.EnableItemEquipsFilters;
		}

		public bool AreRecipesFiltersEnabled() {
			return this.DataAccess.IsActive() && NihilismConfig.Instance.EnableRecipeFilters;
		}

		public bool AreNpcsFiltersEnabled() {
			return this.DataAccess.IsActive() && NihilismConfig.Instance.EnableNpcFilters;
		}

		public bool AreNpcLootsFiltersEnabled() {
			return this.DataAccess.IsActive() && NihilismConfig.Instance.EnableNpcLootFilters;
		}
	}
}
