using HamstarHelpers.Components.Network;
using HamstarHelpers.Helpers.DebugHelpers;
using Nihilism.NetProtocol;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismPlayer : ModPlayer {
		internal void OnEnterWorldOnSingle() {
			var mymod = (NihilismMod)this.mod;
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			if( !mymod.SuppressAutoSaving ) {
				if( !mymod.ConfigJson.LoadFile() ) {
					mymod.ConfigJson.SaveFile();
					LogHelpers.Alert( "Nihilism config " + mymod.Version.ToString() + " created." );
				}
			}

			myworld.Logic.PostFiltersLoad();

			this.FinishModSettingsSync();
			this.FinishFiltersSync();
		}

		internal void OnEnterWorldOnClient() {
			PacketProtocolRequestToServer.QuickRequest<ModSettingsProtocol>( -1 );
			PacketProtocolSentToEither.QuickRequestToServer<FiltersProtocol>( -1 );
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
