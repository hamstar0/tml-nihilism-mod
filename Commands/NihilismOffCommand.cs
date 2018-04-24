using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class NihilismOffCommand : ModCommand {
		public override string Command {
			get {
				return "nih_on";
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
				return "Activates Nihilism mod for the current world. Use /help to see a list of commands to adjust available items, npcs, loot, and recipes.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			if( myworld.Logic.Data.IsActive ) {
				caller.Reply( "Current world is already nihilated.", Color.Yellow );
				return;
			}

			myworld.Logic.UnnihilateCurrentWorld();
			caller.Reply( "Current world nihilation: On", Color.YellowGreen );
		}
	}
}
