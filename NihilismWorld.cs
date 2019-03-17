using HamstarHelpers.Helpers.DebugHelpers;
using Nihilism.Logic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


namespace Nihilism {
	class NihilismWorld : ModWorld {
		public WorldLogic Logic;



		////////////////

		public override void Initialize() {
			var mymod = NihilismMod.Instance;
			this.Logic = new WorldLogic();

			if( mymod.Config.DebugModeInfo ) {
				LogHelpers.Alert( "World initialized." );
			}
		}

		public override void Load( TagCompound tag ) {
			if( Main.netMode != 1 ) {
				this.Logic.LoadWorldData();
			}
		}

		public override TagCompound Save() {
			if( Main.netMode != 1 ) {
				var mymod = (NihilismMod)this.mod;
				if( !mymod.SuppressAutoSaving ) {
					this.Logic.SaveWorldData();
				}
			}
			return new TagCompound();
		}
	}
}
