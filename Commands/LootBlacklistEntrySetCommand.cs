using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class LootBlacklistEntrySetCommand : ModCommand {
		public override string Command {
			get {
				return "nihlootblacklistadd";
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
				return "Adds a lootable npc to the blacklist (checked before whitelist).";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No npc name specified.", Color.Yellow );
				return;
			}

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			string ent_name = string.Join( " ", args );

			myworld.Logic.DataAccess.SetNpcLootBlacklistEntry( ent_name );
			myworld.Logic.SyncDataChanges();

			caller.Reply( "Lootable npc " + ent_name + " added to blacklist.", Color.YellowGreen );
		}
	}
}
