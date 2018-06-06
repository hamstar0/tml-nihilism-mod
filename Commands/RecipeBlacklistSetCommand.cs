﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class RecipeBlacklistSetCommand : ModCommand {
		public override string Command {
			get {
				return "nihrecipeblacklistset";
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
				return "Sets the recipe blacklist matching pattern. For regex help, visit: https://regexr.com/";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No recipe regex pattern specified.", Color.Yellow );
				return;
			}

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			string pattern = args[0];

			myworld.Logic.Data.SetRecipesBlacklistPattern( pattern );
			myworld.Logic.SyncData();

			caller.Reply( "Recipe pattern " + pattern + " set as blacklist.", Color.YellowGreen );
		}
	}
}
