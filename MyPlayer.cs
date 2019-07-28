using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.DotNET.Reflection;
using HamstarHelpers.Helpers.Players;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismPlayer : ModPlayer {
		private bool IsModSettingsSynced = false;
		private bool IsFiltersSynced = false;
		
		////////////////

		public override bool CloneNewInstances => false;



		////////////////

		public override void Initialize() { }

		public override void clientClone( ModPlayer clientClone ) {
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
		}


		////////////////

		public override void PreUpdate() {
			if( Main.netMode != 2 ) {
				if( this.player.whoAmI != Main.myPlayer ) { return; }
			}
			
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

			bool _;
			for( int i=0; i<this.player.armor.Length; i++ ) {
				Item item = this.player.armor[i];
				if( item == null || item.IsAir ) { continue; }

				if( !myworld.Logic.DataAccess.IsItemEnabled(item, out _, out _) ) {
					PlayerItemHelpers.DropEquippedArmorItem( player, i );
				}
			}

			for( int i = 0; i < this.player.miscEquips.Length; i++ ) {
				Item item = this.player.armor[i];
				if( item == null || item.IsAir ) { continue; }

				if( !myworld.Logic.DataAccess.IsItemEnabled( item, out _, out _ ) ) {
					PlayerItemHelpers.DropEquippedMiscItem( player, i );
				}
			}

			if( mymod.WingSlotMod != null ) {
				this.BlockWingSlotIfDisabled( "EquipSlot" );
				this.BlockWingSlotIfDisabled( "VanitySlot" );
			}
		}

		////

		private void BlockWingSlotIfDisabled( string fieldName ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( myworld.Logic == null ) { return; }

			ModPlayer mywingplayer = this.player.GetModPlayer( mymod.WingSlotMod, "WingSlotPlayer" );
			object wingEquipSlot;
			
			if( !ReflectionHelpers.Get( mywingplayer, fieldName, out wingEquipSlot ) || wingEquipSlot == null ) {
				return;
			}

			Item wingItem;
			if( !ReflectionHelpers.Get( wingEquipSlot, "Item", out wingItem ) || wingItem == null || wingItem.IsAir ) {
				return;
			}

			bool _;
			if( !myworld.Logic.DataAccess.IsItemEnabled( wingItem, out _, out _ ) ) {
				int idx = Item.NewItem( player.position, wingItem.width, wingItem.height, wingItem.type, wingItem.stack, false, wingItem.prefix, false, false );

				wingItem.position = Main.item[idx].position;
				Main.item[idx] = wingItem;

				if( Main.netMode == 1 ) {   // Client
					NetMessage.SendData( 21, -1, -1, null, idx, 1f, 0f, 0f, 0, 0, 0 );
				}
				
				ReflectionHelpers.Set( wingEquipSlot, "Item", new Item() );
				ReflectionHelpers.Set( mywingplayer, fieldName, wingEquipSlot );
			}
		}
	}
}
