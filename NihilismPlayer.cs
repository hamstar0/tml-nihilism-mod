using HamstarHelpers.DebugHelpers;
using HamstarHelpers.DotNetHelpers;
using HamstarHelpers.PlayerHelpers;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismPlayer : ModPlayer {
		private bool IsModSettingsSynced = false;
		private bool IsFiltersSynced = false;

		private Mod WingSlotMod = null;


		////////////////

		public override bool CloneNewInstances { get { return false; } }
		
		public override void Initialize() {
			//this.HasEnteredWorld = false;
			this.WingSlotMod = ModLoader.GetMod( "Wing Slot" );
		}

		public override void clientClone( ModPlayer client_clone ) {
			var clone = (NihilismPlayer)client_clone;
			//clone.HasEnteredWorld = this.HasEnteredWorld;
		}


		////////////////

		public override void SyncPlayer( int to_who, int from_who, bool new_player ) {
			if( Main.netMode == 2 ) {
				if( to_who == -1 && from_who == this.player.whoAmI ) {
					this.OnEnterWorldForServer();
				}
			}
		}

		public override void OnEnterWorld( Player player ) {
			if( player.whoAmI != this.player.whoAmI ) { return; }
			
			if( Main.netMode == 0 ) {
				this.OnEnterWorldForSingle();
			} else if( Main.netMode == 1 ) {
				this.OnEnterWorldForClient();
			}
		}


		////////////////

		public override void PreUpdate() {
			if( this.player.whoAmI != Main.myPlayer ) { return; }

			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return; }

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
			if( myworld.Logic == null ) { return; }
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

			if( this.WingSlotMod != null ) {
				this.BlockWingSlotIfDisabled( "EquipSlot" );
				this.BlockWingSlotIfDisabled( "VanitySlot" );
			}
		}


		private void BlockWingSlotIfDisabled( string field_name ) {
			bool success;
			var myworld = this.mod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return; }

			ModPlayer mywingplayer = this.player.GetModPlayer( this.WingSlotMod, "WingSlotPlayer" );
			object wing_equip_slot = ReflectionHelpers.GetField( mywingplayer, field_name, out success );

			if( !success || wing_equip_slot == null ) { return; }

			Item wing_item = (Item)ReflectionHelpers.GetProperty( wing_equip_slot, "Item", out success );

			if( !success || wing_item == null || wing_item.IsAir ) { return; }

			if( !myworld.Logic.DataAccess.IsItemEnabled( wing_item ) ) {
				int idx = Item.NewItem( player.position, wing_item.width, wing_item.height, wing_item.type, wing_item.stack, false, wing_item.prefix, false, false );

				wing_item.position = Main.item[idx].position;
				Main.item[idx] = wing_item;

				if( Main.netMode == 1 ) {   // Client
					NetMessage.SendData( 21, -1, -1, null, idx, 1f, 0f, 0f, 0, 0, 0 );
				}
				
				ReflectionHelpers.SetProperty( wing_equip_slot, "Item", new Item(), out success );
				ReflectionHelpers.SetField( mywingplayer, field_name, wing_equip_slot, out success );
			}
		}
	}
}
