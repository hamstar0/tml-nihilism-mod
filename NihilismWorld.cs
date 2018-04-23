using HamstarHelpers.DebugHelpers;
using Nihilism.Logic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


namespace Nihilism {
	class NihilismWorld : ModWorld {
		public NihilismLogic Logic;


		////////////////

		public override void Initialize() {
			this.Logic = new NihilismLogic();
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
