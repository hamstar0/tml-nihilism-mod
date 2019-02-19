using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class NihilismOffCommand : ModCommand {
		public override string Command => "nih-off";
		public override CommandType Type {
			get {
				if( Main.netMode == 0 && !Main.dedServ ) {
					return CommandType.World;
				} else {
					return CommandType.Console;
				}
			}
		}
		public override string Usage => "/" + this.Command;
		public override string Description => "Deactivates Nihilism mod for the current world.";


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			if( NihilismAPI.UnnihilateCurrentWorld() ) {
				caller.Reply( "Current world is no longer nihilated.", Color.YellowGreen );
			} else {
				caller.Reply( "Current world is already unnihilated.", Color.Yellow );
				return;
			}
		}
	}
}
