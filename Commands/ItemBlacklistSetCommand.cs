using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class ItemBlacklistSetCommand : ModCommand {
		public override string Command {
			get {
				return "nihitem_blacklistset";
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
				return "/" + this.Command + " ^(Wood)$|^(Excalibur)$";
			}
		}
		public override string Description {
			get {
				return "Sets the item blacklist matching pattern. For regex help, visit: https://regexr.com/";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No item regex pattern specified.", Color.Yellow );
				return;
			}

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			string pattern = args[0];

			myworld.Logic.Data.SetItemsBlacklistPattern( pattern );
			myworld.Logic.SyncData();

			caller.Reply( "Item pattern " + pattern + " set as blacklist.", Color.YellowGreen );
		}
	}
}
