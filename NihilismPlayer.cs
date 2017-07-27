using HamstarHelpers.PlayerHelpers;
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

		public override void OnEnterWorld( Player player ) {
			var mymod = (NihilismMod)this.mod;

			if( player.whoAmI == this.player.whoAmI ) {
				if( Main.netMode != 2 ) {   // Not server
					if( !mymod.Config.LoadFile() ) {
						mymod.Config.SaveFile();
					}
				}

				if( Main.netMode == 1 ) {   // Client
					NihilismNetProtocol.SendModSettingsRequestFromClient( this.mod );
				}

				if( mymod.Config.Data.Enabled ) {
					this.BlockRecipesIfNotWhitelisted();
				}
			}

			this.HasEnteredWorld = true;
		}

		public override void PreUpdate() {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.Data.Enabled ) { return; }
			if( !this.HasEnteredWorld ) { return; }

			if( this.player.whoAmI == Main.myPlayer ) {
				this.BlockRecipesIfNotWhitelisted();
				this.BlockEquipsIfNotWhitelisted();
			}
		}

		public override bool PreItemCheck() {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.Data.Enabled ) { return base.PreItemCheck(); }

			return !this.BlockHeldItemIfNotWhitelisted();
		}

		////////////////

		private bool BlockHeldItemIfNotWhitelisted() {
			var mymod = (NihilismMod)this.mod;
			var held_item = this.player.HeldItem;
			bool has_mouse_item = this.player.whoAmI == Main.myPlayer && Main.mouseItem != null && !Main.mouseItem.IsAir;
			bool is_using_blocked = false;

			if( held_item != null && !held_item.IsAir ) {
				var whitelist = mymod.Config.Data.ItemWhitelist;

				is_using_blocked = !whitelist.ContainsKey( held_item.Name ) || !whitelist[held_item.Name];
				if( is_using_blocked ) {
					this.player.noItems = true;
					
					if( !has_mouse_item || (this.player.controlLeft || this.player.controlRight) ) {
						PlayerItemHelpers.UnhandItem( player );
					}
				}
			}
			
//HamstarHelpers.MiscHelpers.DebugHelpers.Display["can use item"] = held_item.Name+" "+ is_using_blocked;
			return is_using_blocked;
		}


		private void BlockEquipsIfNotWhitelisted() {
			var mymod = (NihilismMod)this.mod;
			var whitelist = mymod.Config.Data.ItemWhitelist;

			for( int i=0; i<this.player.armor.Length; i++ ) {
				Item item = this.player.armor[i];
				if( item == null || item.IsAir ) { continue; }
				if( whitelist.ContainsKey(item.Name) && whitelist[item.Name] ) { continue; }
				 
				PlayerItemHelpers.DropEquippedItem( player, i );
			}
		}


		private void BlockRecipesIfNotWhitelisted() {
			var mymod = (NihilismMod)this.mod;

			for( int i=0; i<Main.recipe.Length; i++ ) {
				Recipe old = Main.recipe[i];
				Item item = old.createItem;

				if( item == null || item.IsAir ) { continue; }
				if( mymod.Config.Data.RecipeWhitelist.ContainsKey(item.Name) ) { continue; }

				Main.recipe[i] = new Recipe();
			}
		}
	}
}
