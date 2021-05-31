using Terraria;
using ModLibsCore.Classes.PlayerData;
using ModLibsCore.Libraries.Debug;


namespace Nihilism {
	partial class NihilismCustomPlayer : CustomPlayerData {
		private bool IsModSettingsSynced = false;
		private bool IsFiltersSynced = false;



		////////////////

		protected override void OnEnter( bool isCurrentPlayer, object data ) {
			if( Main.netMode != 2 ) {
				if( this.PlayerWho != Main.myPlayer ) { return; }
			}

			if( Main.netMode == 0 ) {
				this.OnEnterWorldOnSingle();
			} else if( Main.netMode == 1 ) {
				this.OnEnterWorldOnClient();
			} else if( Main.netMode == 2 ) {
				this.OnEnterWorldOnServer();
			}
		}
	}
}
