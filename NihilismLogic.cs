using System.IO;
using Terraria;
using Terraria.ModLoader.IO;


namespace Nihilism {
	class NihilismLogic {
		public bool IsInitialized { get; private set; }
		public bool IsNihilistic { get; private set; }


		public bool IsCurrentWorldNihilated( NihilismMod mymod ) {
			if( !mymod.Config.Data.Enabled ) { return false; }
			if( !this.IsInitialized ) { return false; }

			return this.IsNihilistic;
		}


		public bool IsItemEnabled( NihilismMod mymod, Item item ) {
			if( !mymod.Config.Data.ItemWhitelist.ContainsKey( item.Name ) ) {
				return false;
			}
			return mymod.Config.Data.ItemWhitelist[ item.Name ];
		}


		public bool IsRecipeOfItemEnabled( NihilismMod mymod, Item item ) {
			if( !mymod.Config.Data.RecipeWhitelist.ContainsKey( item.Name ) ) {
				return false;
			}
			return mymod.Config.Data.RecipeWhitelist[ item.Name ];
		}


		public bool IsNpcEnabled( NihilismMod mymod, NPC npc ) {
			if( !mymod.Config.Data.NpcWhitelist.ContainsKey( npc.TypeName ) ) {
				return false;
			}
			return mymod.Config.Data.NpcWhitelist[ npc.TypeName ];
		}


		public bool IsNpcItemDropEnabled( NihilismMod mymod, NPC npc ) {
			if( !mymod.Config.Data.NpcItemDropWhitelist.ContainsKey( npc.TypeName ) ) {
				return false;
			}
			return mymod.Config.Data.NpcItemDropWhitelist[npc.TypeName];
		}
		
		////////////////

		public void NihiliateCurrentWorld( NihilismMod mymod, bool is_nihilated ) {
			if( this.IsInitialized ) { return; }

			this.IsNihilistic = is_nihilated;
			this.IsInitialized = true;

			if( Main.netMode == 1 ) {   // Client
				NihilismNetProtocol.SendInitAndModSettingsFromClient( mymod );
			}
		}


		////////////////

		public void LoadWorldData( TagCompound tag ) {
			this.IsNihilistic = tag.GetBool( "enabled" );
			this.IsInitialized = tag.GetBool( "init" );
		}

		public TagCompound SaveWorldData() {
			return new TagCompound {
				{ "enabled", this.IsNihilistic },
				{ "init", this.IsInitialized }
			};
		}

		public void NetReceiveWorldData( BinaryReader reader ) {
			if( Main.netMode != 1 ) { return; } // Client only
			this.IsNihilistic = reader.ReadBoolean();
			this.IsInitialized = reader.ReadBoolean();
		}

		public void NetSendWorldData( BinaryWriter writer ) {
			if( Main.netMode != 2 ) { return; }	// Server only
			writer.Write( this.IsNihilistic );
			writer.Write( this.IsInitialized );
		}
	}
}
