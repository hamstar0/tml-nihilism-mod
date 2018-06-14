using HamstarHelpers.DebugHelpers;
using HamstarHelpers.PlayerHelpers;
using HamstarHelpers.TmlHelpers;
using HamstarHelpers.Utilities.Network;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismPlayer : ModPlayer {
		private bool IsModSettingsSynced = false;
		private bool IsFiltersSynced = false;


		////////////////

		public override void SyncPlayer( int to_who, int from_who, bool new_player ) {
			if( Main.netMode == 2 ) {
				if( to_who == -1 && from_who == this.player.whoAmI ) {
					var mymod = (NihilismMod)this.mod;
					var myworld = mymod.GetModWorld<NihilismWorld>();

					this.OnEnterWorldForServer( mymod, this.player );
				}
			}
		}
		
		public override void OnEnterWorld( Player player ) {
			if( player.whoAmI != this.player.whoAmI ) { return; }

			var mymod = (NihilismMod)this.mod;

			if( Main.netMode == 0 ) {
				if( !mymod.SuppressAutoSaving ) {
					if( !mymod.ConfigJson.LoadFile() ) {
						mymod.ConfigJson.SaveFile();
						LogHelpers.Log( "Nihilism config " + NihilismConfigData.ConfigVersion.ToString() + " created (ModPlayer.OnEnterWorld())." );
					}
				}
			}

			if( Main.netMode == 0 ) {
				this.OnEnterWorldForSingle( mymod, player );
			} else if( Main.netMode == 1 ) {
				this.OnEnterWorldForClient( mymod, player );
			}
		}


		////////////////

		internal void OnEnterWorldForSingle( NihilismMod mymod, Player player ) {
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			myworld.Logic.PostFiltersLoad( mymod );

			this.FinishModSettingsSync();
			this.FinishFiltersSync();
		}

		internal void OnEnterWorldForClient( NihilismMod mymod, Player player ) {
			PacketProtocol.QuickRequestToServer<ModSettingsProtocol>();
			PacketProtocol.QuickRequestToServer<FiltersProtocol>();
		}

		internal void OnEnterWorldForServer( NihilismMod mymod, Player player ) {
			this.FinishModSettingsSync();
			this.FinishFiltersSync();
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
