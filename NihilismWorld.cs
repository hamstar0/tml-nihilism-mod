using HamstarHelpers.DebugHelpers;
using Nihilism.Logic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


namespace Nihilism {
	class NihilismWorld : ModWorld {
		public NihilismLogic Logic;


		////////////////

		public override void Initialize() {
			var mymod = (NihilismMod)this.mod;

			this.Logic = new NihilismLogic();

			if( mymod.Config.DebugModeInfo ) {
				LogHelpers.Log( "World initialized." );
			}
		}

		public override void Load( TagCompound tag ) {
			this.Logic.LoadWorldData( (NihilismMod)this.mod );
		}

		public override TagCompound Save() {
			this.Logic.SaveWorldData( (NihilismMod)this.mod );
			return new TagCompound();
		}
	}
}
