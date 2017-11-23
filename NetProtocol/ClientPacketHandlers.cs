using HamstarHelpers.DebugHelpers;
using System.IO;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.NetProtocol {
	static class ClientPacketHandlers {
		public static void HandlePacket( NihilismMod mymod, BinaryReader reader ) {
			NihilismProtocolTypes protocol = (NihilismProtocolTypes)reader.ReadByte();

			switch( protocol ) {
			case NihilismProtocolTypes.ModSettings:
				ClientPacketHandlers.ReceiveModSettingsOnClient( mymod, reader );
				break;
			case NihilismProtocolTypes.InitFromServer:
				ClientPacketHandlers.ReceiveInitAndModSettingsOnClient( mymod, reader );
				break;
			default:
				DebugHelpers.Log( "Invalid packet protocol: " + protocol );
				break;
			}
		}



		////////////////
		// Client Senders
		////////////////

		public static void SendModSettingsRequestFromClient( NihilismMod mymod ) {
			// Clients only
			if( Main.netMode != 1 ) { return; }

			ModPacket packet = mymod.GetPacket();

			packet.Write( (byte)NihilismProtocolTypes.RequestModSettings );
			packet.Write( (int)Main.myPlayer );

			packet.Send();
		}

		public static void SendInitAndModSettingsFromClient( NihilismMod mymod ) {
			// Clients only
			if( Main.netMode != 1 ) { return; }

			var modworld = mymod.GetModWorld<NihilismWorld>();
			ModPacket packet = mymod.GetPacket();

			packet.Write( (byte)NihilismProtocolTypes.InitFromClient );
			packet.Write( (bool)modworld.Logic.IsNihilistic );
			packet.Write( (string)mymod.Config.SerializeMe() );

			packet.Send();
		}



		////////////////
		// Client Receivers
		////////////////

		private static void ReceiveModSettingsOnClient( NihilismMod mymod, BinaryReader reader ) {
			// Clients only
			if( Main.netMode != 1 ) { return; }

			mymod.Config.DeserializeMe( reader.ReadString() );
		}

		private static void ReceiveInitAndModSettingsOnClient( NihilismMod mymod, BinaryReader reader ) {
			// Clients only
			if( Main.netMode != 1 ) { return; }

			var modworld = mymod.GetModWorld<NihilismWorld>();

			modworld.Logic.NihiliateCurrentWorld( mymod, reader.ReadBoolean() );
			mymod.Config.DeserializeMe( reader.ReadString() );
		}
	}
}
