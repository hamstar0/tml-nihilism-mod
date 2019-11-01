using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class DefaultFiltersClearCommand : ModCommand {
		public override string Command => "nih-clear";
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
		public override string Description => "Empties the current world's white and blacklists.";



		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			NihilismAPI.ClearFiltersForCurrentWorld( false );

			caller.Reply( "Cleared all blacklists and whitelists.", Color.YellowGreen );
		}
	}
}
