using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class DefaultFiltersSetCommand : ModCommand {
		public override string Command => "nih-defaults-set";
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
		public override string Description => "Set current world's white and blacklists as the (initial) defaults for every world.";


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			NihilismAPI.SetCurrentFiltersAsDefaults(false);

			caller.Reply( "Current world's filters as the new defaults.", Color.YellowGreen );
		}
	}
}
