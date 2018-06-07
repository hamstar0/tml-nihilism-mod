using HamstarHelpers.DebugHelpers;
using HamstarHelpers.PlayerHelpers;
using Nihilism.Data;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismPlayer : ModPlayer {
		public bool HasEnteredWorld { get; private set; }


		////////////////

		public override bool CloneNewInstances { get { return false; } }

		public override void Initialize() {
			this.HasEnteredWorld = false;
		}

		public override void clientClone( ModPlayer client_clone ) {
			var clone = (NihilismPlayer)client_clone;
			clone.HasEnteredWorld = this.HasEnteredWorld;
		}


		////////////////

		public override void SyncPlayer( int to_who, int from_who, bool new_player ) {
			if( Main.netMode == 2 ) {
				if( to_who == -1 && from_who == this.player.whoAmI ) {
					var mymod = (NihilismMod)this.mod;
					var myworld = mymod.GetModWorld<NihilismWorld>();

					myworld.Logic.OnEnterWorldForServer( mymod, this.player );
				}
			}
		}
		
		public override void OnEnterWorld( Player player ) {
			if( player.whoAmI != this.player.whoAmI ) { return; }

			var mymod = (NihilismMod)this.mod;
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			if( Main.netMode != 2 ) {   // Not server
				if( !mymod.SuppressAutoSaving ) {
					if( !mymod.ConfigJson.LoadFile() ) {
						mymod.ConfigJson.SaveFile();
						LogHelpers.Log( "Nihilism config " + NihilismConfigData.ConfigVersion.ToString() + " created (ModPlayer.OnEnterWorld())." );
					}
				}
			}

			if( Main.netMode == 0 ) {
				myworld.Logic.OnEnterWorldForSingle( mymod, player );
			} else if( Main.netMode == 1 ) {
				myworld.Logic.OnEnterWorldForClient( mymod, player );
			}
			
			this.HasEnteredWorld = true;
		}


		public override void PreUpdate() {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			if( !myworld.Logic.Data.IsActive() ) { return; }
			if( !this.HasEnteredWorld ) { return; }

			if( this.player.whoAmI == Main.myPlayer ) {
				this.BlockEquipsIfDisabled();
			}
		}

		
		private void BlockEquipsIfDisabled() {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.EnableItemEquipsFilters ) { return; }///////////////////////////////

			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.Data.IsActive() ) { return; }

			for( int i=0; i<this.player.armor.Length; i++ ) {
				Item item = this.player.armor[i];
				if( item == null || item.IsAir ) { continue; }

				if( myworld.Logic.Data.IsItemEnabled( item ) ) { continue; }
				
				PlayerItemHelpers.DropEquippedItem( player, i );
			}
		}
	}
}
