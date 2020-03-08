using HamstarHelpers.Helpers.Debug;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismPlayer : ModPlayer {
		/*private bool IsModSettingsSynced = false;
		private bool IsFiltersSynced = false;*/
		
		////////////////

		public override bool CloneNewInstances => false;



		////////////////

		public override void Initialize() { }

		/*public override void clientClone( ModPlayer clientClone ) {
			var clone = (NihilismPlayer)clientClone;
			clone.IsModSettingsSynced = this.IsModSettingsSynced;
			clone.IsFiltersSynced = this.IsFiltersSynced;
		}


		////////////////

		public override void SyncPlayer( int toEho, int fromWho, bool newPlayer ) {
			if( Main.netMode == 2 ) {
				if( toEho == -1 && fromWho == this.player.whoAmI ) {
					this.OnEnterWorldOnServer();
				}
			}
		}

		public override void OnEnterWorld( Player player ) {
			if( player.whoAmI != Main.myPlayer ) { return; }
			if( this.player.whoAmI != Main.myPlayer ) { return; }

			if( Main.netMode == 0 ) {
				this.OnEnterWorldOnSingle();
			} else if( Main.netMode == 1 ) {
				this.OnEnterWorldOnClient();
			}
		}*/


		////////////////

		public override void PreUpdate() {
			if( Main.netMode != 2 ) {
				if( this.player.whoAmI != Main.myPlayer ) { return; }
			}
			
			var myworld = ModContent.GetInstance<NihilismWorld>();

			if( myworld.Logic?.DataAccess?.IsActive() ?? false ) {
				var customPlrData = NihilismCustomPlayer.GetPlayerData<NihilismCustomPlayer>( this.player.whoAmI );

				if( customPlrData.IsSynced() ) {
					this.BlockEquipsIfDisabled();
				}
			}
		}
	}
}
