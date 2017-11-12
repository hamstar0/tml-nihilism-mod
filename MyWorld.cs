using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Nihilism {
	class MyWorld : ModWorld {
		public NihilismLogic Logic;


		////////////////

		public override void Initialize() {
			this.Logic = new NihilismLogic();
		}

		public override void Load( TagCompound tag ) {
			this.Logic.LoadWorldData( tag );
		}

		public override TagCompound Save() {
			return this.Logic.SaveWorldData();
		}

		public override void NetReceive( BinaryReader reader ) {
			this.Logic.NetReceiveWorldData( reader );
		}

		public override void NetSend( BinaryWriter writer ) {
			this.Logic.NetSendWorldData( writer );
		}
	}
}
