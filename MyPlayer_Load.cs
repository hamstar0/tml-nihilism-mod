using Nihilism.NetProtocol;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismPlayer : ModPlayer {
		internal void OnEnterWorldOnSingle() {
			var mymod = (NihilismMod)this.mod;
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			myworld.Logic.PostFiltersLoad();

			this.FinishModSettingsSync();
			this.FinishFiltersSync();
		}

		internal void OnEnterWorldOnClient() {
			FiltersProtocol.SyncToMe();
		}

		internal void OnEnterWorldOnServer() {
			this.IsModSettingsSynced = true;
			this.IsFiltersSynced = true;
		}


		////////////////

		internal void FinishModSettingsSync() {
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
