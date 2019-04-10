using HamstarHelpers.Helpers.DebugHelpers;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class ShowFiltersCommand : ModCommand {
		public override string Command => "nih-show-filters";
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
		public override string Description => "Displays each filter currently active or the world.";


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			var myworld = this.mod.GetModWorld<NihilismWorld>();
			myworld.Logic.DataAccess.OutputFormattedFilterData();
		}
	}
}
