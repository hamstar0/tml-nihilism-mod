﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class ItemFilterSetCommand : ModCommand {
		public override string Command {
			get {
				return "nihitemfilter";
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
				return "/" + this.Command + " <true/false>";
			}
		}
		public override string Description {
			get {
				return "Sets items to be filtered or not.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "Missing parameter.", Color.Yellow );
				return;
			}

			bool on;
			if( !bool.TryParse(args[0], out on) ) { caller.Reply( "Invalid parameter." ); }

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.DataAccess.SetItemFilter( on );
			myworld.Logic.SyncData();

			caller.Reply( "Item filter " + on + ".", Color.LimeGreen );
		}
	}
}
