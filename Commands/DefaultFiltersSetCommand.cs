using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class DefaultFiltersSetCommand : ModCommand {
		public override string Command {
			get {
				return "nihdefaultsset";
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
				return "Set current white and blacklists as defaults for each new world.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			NihilismAPI.SetCurrentFiltersAsDefaults();

			caller.Reply( "Current world's filters as the new defaults.", Color.YellowGreen );
		}
	}
}
