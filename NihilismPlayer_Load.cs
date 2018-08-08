using HamstarHelpers.Components.Network;
using HamstarHelpers.Helpers.DebugHelpers;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismPlayer : ModPlayer {
		internal void OnEnterWorldForSingle() {
			var mymod = (NihilismMod)this.mod;
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			if( !mymod.SuppressAutoSaving ) {
				if( !mymod.ConfigJson.LoadFile() ) {
					mymod.ConfigJson.SaveFile();
					LogHelpers.Log( "Nihilism config " + NihilismConfigData.ConfigVersion.ToString() + " created (ModPlayer.OnEnterWorld())." );
				}
			}

			myworld.Logic.PostFiltersLoad( mymod );

			this.FinishModSettingsSync();
			this.FinishFiltersSync();
		}

		internal void OnEnterWorldForClient() {
			PacketProtocol.QuickRequestToServer<ModSettingsProtocol>();
			PacketProtocol.QuickRequestToServer<FiltersProtocol>();
		}

		internal void OnEnterWorldForServer() {
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
