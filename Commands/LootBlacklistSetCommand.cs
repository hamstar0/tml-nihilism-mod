﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class LootBlacklistSetCommand : ModCommand {
		public override string Command {
			get {
				return "nihlootblacklistset";
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
				return "/" + this.Command + " ^(Zombie)$|^(Dungeon Guardian)$";
			}
		}
		public override string Description {
			get {
				return "Sets the loot dropping npc blacklist matching pattern. For regex help, visit: https://regexr.com/";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No npc regex pattern specified.", Color.Yellow );
				return;
			}

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			string pattern = args[0];

			myworld.Logic.Data.SetNpcLootBlacklistPattern( pattern );
			myworld.Logic.SyncData();

			caller.Reply( "Npc loot pattern " + pattern + " set as blacklist.", Color.YellowGreen );
		}
	}
}
