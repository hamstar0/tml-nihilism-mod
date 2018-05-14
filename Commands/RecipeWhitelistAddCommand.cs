using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class RecipeWhitelistAddCommand : ModCommand {
		public override string Command {
			get {
				return "nih_recipe_whitelist_add";
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
				return "/" + this.Command + " Excalibur";
			}
		}
		public override string Description {
			get {
				return "Adds a recipe to the whitelist as an exception to the blacklist.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No item name specified.", Color.Yellow );
				return;
			}

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			string ent_name = args[0];

			myworld.Logic.SetRecipeWhitelistEntry( ent_name );
			myworld.Logic.SyncData();

			caller.Reply( "Recipe for item " + ent_name + " added to whitelist.", Color.YellowGreen );
		}
	}
}
