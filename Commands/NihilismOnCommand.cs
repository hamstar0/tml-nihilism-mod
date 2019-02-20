﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class NihilismOnCommand : ModCommand {
		public override string Command => "nih-on";
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
		public override string Description => "Activates Nihilism mod for the current world. "
			+"Use /help and the arrow keys to see a list of commands to adjust available items, npcs, loot, and recipes.";


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			if( NihilismAPI.NihilateCurrentWorld() ) {
				caller.Reply( "Current world is nihilated. Type /nih-off to revert.", Color.YellowGreen );
			}  else {
				caller.Reply( "Current world is already nihilated.", Color.Yellow );
			}
		}
	}
}
