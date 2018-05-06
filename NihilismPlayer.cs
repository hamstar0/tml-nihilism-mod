using HamstarHelpers.DotNetHelpers;
using HamstarHelpers.PlayerHelpers;
using Nihilism.Data;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismPlayer : ModPlayer {
		public bool HasEnteredWorld { get; private set; }


		////////////////

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
			if( player.whoAmI == this.player.whoAmI ) {
				var mymod = (NihilismMod)this.mod;
				var myworld = this.mod.GetModWorld<NihilismWorld>();

				if( Main.netMode != 2 ) {   // Not server
					if( !mymod.JsonConfig.LoadFile() ) {
						mymod.JsonConfig.SaveFile();
						ErrorLogger.Log( "Nihilism config " + NihilismConfigData.ConfigVersion.ToString() + " created (ModPlayer.OnEnterWorld())." );
					}
				}

				if( Main.netMode == 0 ) {
					myworld.Logic.OnEnterWorldForSingle( mymod, player );
				} else if( Main.netMode == 1 ) {
					myworld.Logic.OnEnterWorldForClient( mymod, player );
				}
			}

//Main.NewText("whitelist "+string.Join(", ", mymod.Config.Data.ItemWhitelist.Select(kv => kv.Key+":"+kv.Value).ToArray()) );
			this.HasEnteredWorld = true;
		}

		public override void PreUpdate() {
			var mymod = (NihilismMod)this.mod;
			var modworld = mymod.GetModWorld<NihilismWorld>();
			if( !modworld.Logic.IsCurrentWorldNihilated() ) { return; }
			if( !this.HasEnteredWorld ) { return; }

			if( this.player.whoAmI == Main.myPlayer ) {
				this.BlockRecipesIfDisabled();
				this.BlockEquipsIfDisabled();
			}
		}


		/*public override bool PreItemCheck() {	Redundant?!
			var mymod = (NihilismMod)this.mod;
			var modworld = mymod.GetModWorld<NihilismWorld>();
			if( !modworld.Logic.IsCurrentWorldNihilated( mymod ) ) { return base.PreItemCheck(); }
			
			return !this.BlockHeldItemIfDisabled();
		}*/

		////////////////

		/*private bool BlockHeldItemIfDisabled() {
			var mymod = (NihilismMod)this.mod;
			var modworld = mymod.GetModWorld<NihilismWorld>();
			var held_item = this.player.HeldItem;
			bool has_mouse_item = this.player.whoAmI == Main.myPlayer && Main.mouseItem != null && !Main.mouseItem.IsAir;
			bool is_using_blocked = false;

			if( held_item != null && !held_item.IsAir ) {
				is_using_blocked = !modworld.Logic.IsItemEnabled( mymod, held_item );
				if( is_using_blocked ) {
					this.player.noItems = true;
					
					if( !has_mouse_item || (this.player.controlLeft || this.player.controlRight) ) {
						PlayerItemHelpers.UnhandItem( player );
					}
				}
			}
			
			return is_using_blocked;
		}*/

		
		private void BlockEquipsIfDisabled() {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.EnableItemEquipsFilters ) { return; }

			var myworld = mymod.GetModWorld<NihilismWorld>();

			for( int i=0; i<this.player.armor.Length; i++ ) {
				Item item = this.player.armor[i];
				if( item == null || item.IsAir ) { continue; }
				if( myworld.Logic.IsItemEnabled( item ) ) { continue; }
				 
				PlayerItemHelpers.DropEquippedItem( player, i );
			}
		}


		private void BlockRecipesIfDisabled() {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.EnableRecipeFilters ) { return; }

			var modworld = mymod.GetModWorld<NihilismWorld>();

			for( int i=0; i<Main.recipe.Length; i++ ) {
				Recipe old = Main.recipe[i];
				Item item = old.createItem;

				if( item == null || item.IsAir ) { continue; }
				if( modworld.Logic.IsRecipeOfItemEnabled( item ) ) { continue; }

				Main.recipe[i] = new Recipe();
			}
		}
	}
}
