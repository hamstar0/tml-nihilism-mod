using HamstarHelpers.MiscHelpers;
using System.IO;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	public enum NihilismProtocolTypes : byte {
		RequestModSettings,
		ModSettings
	}


	public static class NihilismNetProtocol {
		public static void RouteReceivedPackets( NihilismMod mymod, BinaryReader reader ) {
			NihilismProtocolTypes protocol = (NihilismProtocolTypes)reader.ReadByte();

			switch( protocol ) {
			case NihilismProtocolTypes.RequestModSettings:
				NihilismNetProtocol.ReceiveModSettingsRequestOnServer( mymod, reader );
				break;
			case NihilismProtocolTypes.ModSettings:
				NihilismNetProtocol.ReceiveModSettingsOnClient( mymod, reader );
				break;
			default:
				DebugHelpers.Log( "Invalid packet protocol: " + protocol );
				break;
			}
		}



		////////////////
		// Client Senders
		////////////////
		
		public static void SendModSettingsRequestFromClient( Mod mod ) {
			// Clients only
			if( Main.netMode != 1 ) { return; }

			ModPacket packet = mod.GetPacket();

			packet.Write( (byte)NihilismProtocolTypes.RequestModSettings );
			packet.Write( (int)Main.myPlayer );

			packet.Send();
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



		////////////////
		// Client Receivers
		////////////////

		private static void ReceiveModSettingsOnClient( NihilismMod mymod, BinaryReader reader ) {
			// Clients only
			if( Main.netMode != 1 ) { return; }
			
			mymod.Config.DeserializeMe( reader.ReadString() );
		}
		


		////////////////
		// Server Receivers
		////////////////

		private static void ReceiveModSettingsRequestOnServer( NihilismMod mymod, BinaryReader reader ) {
			// Server only
			if( Main.netMode != 2 ) { return; }

			int player_who = reader.ReadInt32();

			if( player_who < 0 || player_who >= Main.player.Length || Main.player[player_who] == null ) {
				DebugHelpers.Log( "ReceiveRequestModSettingsOnServer - Invalid player id " + player_who );
				return;
			}

			NihilismNetProtocol.SendModSettingsFromServer( mymod, Main.player[player_who] );
		}
	}
}
