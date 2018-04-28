using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class NihilismOffCommand : ModCommand {
		public override string Command {
			get {
				return "unnihilate";
			}
		}
		public override CommandType Type {
			get {
				if( Main.netMode == 0 ) {
					return CommandType.World;
				} else {
					return CommandType.Console;
				}
			}
		}
		public override string Usage {
			get {
				return "/" + this.Command;
			}
		}
		public override string Description {
			get {
				return "Deactivates Nihilism mod for the current world.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			if( !myworld.Logic.Data.IsActive ) {
				caller.Reply( "Current world is already unnihilated.", Color.Yellow );
				return;
			}

			myworld.Logic.UnnihilateCurrentWorld();
			caller.Reply( "Current world is no longer nihilated.", Color.YellowGreen );
		}
	}
}
