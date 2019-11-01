using Nihilism.NetProtocol;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismPlayer : ModPlayer {
		internal void OnEnterWorldOnSingle() {
			var mymod = (NihilismMod)this.mod;
			var myworld = ModContent.GetInstance<NihilismWorld>();

			myworld.Logic.PostFiltersLoad();

			this.FinishModSettingsSync();
			this.FinishFiltersSync();

			mymod.RunSyncOrWorldLoadActions( false );
		}

		internal void OnEnterWorldOnClient() {
			FiltersProtocol.SyncToMe();
		}

		internal void OnEnterWorldOnServer() {
			var mymod = (NihilismMod)this.mod;

			this.IsModSettingsSynced = true;
			this.IsFiltersSynced = true;

			mymod.RunSyncOrWorldLoadActions( false );
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
