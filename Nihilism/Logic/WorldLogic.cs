using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Services.Hooks.LoadHooks;
using Nihilism.Data;
using Nihilism.NetProtocol;


namespace Nihilism.Logic {
	partial class WorldLogic {
		private static void MessageAboutModUsage( string description ) {
			Messages.MessagesAPI.AddMessagesCategoriesInitializeEvent( () => {
				Messages.MessagesAPI.AddMessage(
					title: "How to use Nihilism mod",
					description: description,
					modOfOrigin: NihilismMod.Instance,
					isImportant: false,
					alertPlayer: false,
					id: "NihilismUsage",
					parentMessage: Messages.MessagesAPI.ModInfoCategoryMsg
				);
			} );
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
				if( Main.netMode == NetmodeID.Server ) {
					return;
				}

				var myworld = ModContent.GetInstance<NihilismWorld>();
				if( myworld.Logic.DataAccess.IsActive() ) {
					return;
				}

				string msg;
				if( Main.netMode == NetmodeID.SinglePlayer ) {
					msg = "Enter the /nih-on command to activate Nihilism restrictions for the current world. Enter /help for a list of other commands.";
				} else {
					msg = "Enter nih-on in the server's command console to activate Nihilism restrictions for the current world. Enter help for a list of other commands.";
				}

				if( ModLoader.GetMod("Messages") != null ) {
					WorldLogic.MessageAboutModUsage( msg );
				}
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
