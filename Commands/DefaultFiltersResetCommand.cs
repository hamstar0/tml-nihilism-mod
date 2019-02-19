using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class DefaultFiltersResetCommand : ModCommand {
		public override string Command => "nih-defaults-reset";
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
		public override string Description => "Sets default config's white and blacklists to override the current world's.";


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			NihilismAPI.ResetFiltersFromDefaults();

			caller.Reply( "Current world's filters reset to defaults.", Color.YellowGreen );
		}
	}
}
