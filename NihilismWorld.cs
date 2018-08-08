using HamstarHelpers.Helpers.DebugHelpers;
using Nihilism.Logic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


namespace Nihilism {
	class NihilismWorld : ModWorld {
		public WorldLogic Logic;


		////////////////

		public override void Initialize() {
			var mymod = (NihilismMod)this.mod;

			this.Logic = new WorldLogic( mymod );

			if( mymod.Config.DebugModeInfo ) {
				LogHelpers.Log( "Nihilism - World initialized." );
			}
		}

		public override void Load( TagCompound tag ) {
			var mymod = (NihilismMod)this.mod;
			this.Logic.LoadWorldData( mymod );
		}

		public override TagCompound Save() {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.SuppressAutoSaving ) {
				this.Logic.SaveWorldData( mymod );
			}
			return new TagCompound();
		}
	}
}
