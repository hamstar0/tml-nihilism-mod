using Terraria.ModLoader;
using HamstarHelpers.Classes.PlayerData;
using Nihilism.NetProtocol;


namespace Nihilism {
	partial class NihilismCustomPlayer : CustomPlayerData {
		private void OnEnterWorldOnSingle() {
			var mymod = NihilismMod.Instance;
			var myworld = ModContent.GetInstance<NihilismWorld>();

			myworld.Logic.PostFiltersLoad();

			this.FinishModSettingsSync();
			this.FinishFiltersSync();

			mymod.RunSyncOrWorldLoadActions( false );
		}

		private void OnEnterWorldOnClient() {
			FiltersProtocol.SyncToMe();
		}

		private void OnEnterWorldOnServer() {
			var mymod = NihilismMod.Instance;

			this.IsModSettingsSynced = true;
			this.IsFiltersSynced = true;

			mymod.RunSyncOrWorldLoadActions( false );
		}


		////////////////

		private void FinishModSettingsSync() {
			this.IsModSettingsSynced = true;
		}

		internal void FinishFiltersSync() {
			this.IsFiltersSynced = true;
		}

		////////////////

		public bool IsSynced() {
			return this.IsModSettingsSynced && this.IsFiltersSynced;
		}
	}
}
