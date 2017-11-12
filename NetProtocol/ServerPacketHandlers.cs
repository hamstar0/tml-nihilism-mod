using HamstarHelpers.DebugHelpers;
using System.IO;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.NetProtocol {
	static class ServerPacketHandlers {
		public static void HandlePacket( NihilismMod mymod, BinaryReader reader, int player_who ) {
			NihilismProtocolTypes protocol = (NihilismProtocolTypes)reader.ReadByte();

			switch( protocol ) {
			case NihilismProtocolTypes.RequestModSettings:
				ServerPacketHandlers.ReceiveModSettingsRequestOnServer( mymod, reader, player_who );
				break;
			case NihilismProtocolTypes.InitFromClient:
				ServerPacketHandlers.ReceiveInitAndModSettingsOnServer( mymod, reader, player_who );
				break;
			default:
				DebugHelpers.Log( "Invalid packet protocol: " + protocol );
				break;
			}
		}


		
		////////////////
		// Server Senders
		////////////////

		public static void SendModSettingsFromServer( NihilismMod mymod, Player player ) {
			// Server only
			if( Main.netMode != 2 ) { return; }

			ModPacket packet = mymod.GetPacket();

			packet.Write( (byte)NihilismProtocolTypes.ModSettings );
			packet.Write( (string)mymod.Config.SerializeMe() );

			packet.Send( (int)player.whoAmI );
		}

		public static void SendInitAndModSettingsFromServer( NihilismMod mymod, Player player ) {
			// Server only
			if( Main.netMode != 2 ) { return; }

			var modworld = mymod.GetModWorld<MyWorld>();
			ModPacket packet = mymod.GetPacket();

			packet.Write( (byte)NihilismProtocolTypes.InitFromServer );
			packet.Write( (bool)modworld.Logic.IsNihilistic );
			packet.Write( (string)mymod.Config.SerializeMe() );

			packet.Send( (int)player.whoAmI );
		}



		////////////////
		// Server Receivers
		////////////////

		private static void ReceiveModSettingsRequestOnServer( NihilismMod mymod, BinaryReader reader, int player_who ) {
			// Server only
			if( Main.netMode != 2 ) { return; }

			ServerPacketHandlers.SendModSettingsFromServer( mymod, Main.player[player_who] );
		}

		private static void ReceiveInitAndModSettingsOnServer( NihilismMod mymod, BinaryReader reader, int player_who ) {
			// Server only
			if( Main.netMode != 2 ) { return; }
			var modworld = mymod.GetModWorld<MyWorld>();

			modworld.Logic.NihiliateCurrentWorld( mymod, reader.ReadBoolean() );
			mymod.Config.DeserializeMe( reader.ReadString() );

			// Rebroadcast settings
			for( int i = 0; i < Main.player.Length; i++ ) {
				Player player = Main.player[i];
				if( player == null || !player.active ) { continue; }

				ServerPacketHandlers.SendInitAndModSettingsFromServer( mymod, player );
			}
		}
	}
}
