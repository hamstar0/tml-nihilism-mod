using HamstarHelpers.DebugHelpers;
using HamstarHelpers.PlayerHelpers;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismPlayer : ModPlayer {
		public override bool CloneNewInstances { get { return false; } }
		
		public override void Initialize() {
			//this.HasEnteredWorld = false;
		}

		public override void clientClone( ModPlayer client_clone ) {
			var clone = (NihilismPlayer)client_clone;
			//clone.HasEnteredWorld = this.HasEnteredWorld;
		}


		////////////////

		public override void PreUpdate() {
			if( this.player.whoAmI != Main.myPlayer ) { return; }

			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			if( myworld.Logic.DataAccess.IsActive() ) {
				if( this.IsSynced() ) {
					this.BlockEquipsIfDisabled();
				}
			}
		}


		////////////////

		private void BlockEquipsIfDisabled() {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.EnableItemEquipsFilters ) { return; }

			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.DataAccess.IsActive() ) { return; }

			for( int i=0; i<this.player.armor.Length; i++ ) {
				Item item = this.player.armor[i];
				if( item == null || item.IsAir ) { continue; }

				if( myworld.Logic.DataAccess.IsItemEnabled( item ) ) { continue; }
				
				PlayerItemHelpers.DropEquippedItem( player, i );
			}

			for( int i = 0; i < this.player.miscEquips.Length; i++ ) {
				Item item = this.player.armor[i];
				if( item == null || item.IsAir ) { continue; }

				if( myworld.Logic.DataAccess.IsItemEnabled( item ) ) { continue; }

				PlayerItemHelpers.DropEquippedMiscItem( player, i );
			}
		}
	}
}
