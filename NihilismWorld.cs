using Nihilism.Logic;
using System;
using System.IO;
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
			this.Logic.LoadWorldData( tag );
		}

		public override TagCompound Save() {
			return this.Logic.SaveWorldData();
		}

		public override void NetReceive( BinaryReader reader ) {
			try {
				this.Logic.NetReceiveWorldData( reader );
			} catch( Exception e ) {
				ErrorLogger.Log( e.ToString() );
			}
		}

		public override void NetSend( BinaryWriter writer ) {
			try {
				this.Logic.NetSendWorldData( writer );
			} catch(Exception e ) {
				ErrorLogger.Log(e.ToString() );
			}
		}
	}
}
