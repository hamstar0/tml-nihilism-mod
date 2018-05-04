using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class DefaultFiltersSetCommand : ModCommand {
		public override string Command {
			get {
				return "nih_defaults_set";
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
				return "Copies the current set of blacklists and whitelists to be the defaults that new worlds will generate with.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			NihilismAPI.SetCurrentFiltersAsDefaults();

			caller.Reply( "Current world's filters as the new defaults.", Color.YellowGreen );
		}
	}
}
