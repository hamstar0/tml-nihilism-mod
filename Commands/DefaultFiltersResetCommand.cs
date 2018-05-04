using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class DefaultFiltersResetCommand : ModCommand {
		public override string Command {
			get {
				return "nih_defaults_reset";
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
				return "Copies the main config's default set of blacklists and whitelists to override the current world's set.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			NihilismAPI.ResetFiltersFromDefaults();

			caller.Reply( "Current world's filters reset to defaults.", Color.YellowGreen );
		}
	}
}
