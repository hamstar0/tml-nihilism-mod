﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class RecipeBlacklistSetCommand : ModCommand {
		public override string Command {
			get {
				return "nih_recipe_blacklist_set";
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
				return "/" + this.Command + " ^(Torch)$|^(Wood Sword)$";
			}
		}
		public override string Description {
			get {
				return "Sets the recipe blacklist matching pattern. For help with using regexp, visit: https://regexr.com/";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No recipe regex pattern specified.", Color.Yellow );
				return;
			}

			string pattern = args[0];

			NihilismAPI.RecipeBlacklistSet( pattern );
			caller.Reply( "Recipe pattern " + pattern + " set as blacklist.", Color.YellowGreen );
		}
	}
}
