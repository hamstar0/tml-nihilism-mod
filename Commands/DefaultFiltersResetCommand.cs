﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class DefaultFiltersResetCommand : ModCommand {
		public override string Command {
			get {
				return "nihdefaultsreset";
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
				return "Sets config's white and blacklists to override the current world's.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			NihilismAPI.ResetFiltersFromDefaults();

			caller.Reply( "Current world's filters reset to defaults.", Color.YellowGreen );
		}
	}
}
