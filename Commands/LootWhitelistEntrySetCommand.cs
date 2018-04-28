using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class LootWhitelistEntrySetCommand : ModCommand {
		public override string Command {
			get {
				return "nih_loot_whitelist_add";
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
				return "/" + this.Command + " Zombie";
			}
		}
		public override string Description {
			get {
				return "Adds a lootable npc to the whitelist as an exception to the blacklist.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No npc name specified.", Color.Yellow );
				return;
			}

			string ent_name = args[0];

			NihilismAPI.SetNpcLootWhitelistEntry( ent_name );
			caller.Reply( "Lootable npc " + ent_name + " added to whitelist.", Color.YellowGreen );
		}
	}
}
