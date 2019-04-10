using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class LootBlacklist2EntrySetCommand : ModCommand {
		public override string Command => "nih-loot-blacklist2-set";
		public override CommandType Type {
			get {
				if( Main.netMode == 0 && !Main.dedServ ) {
					return CommandType.World;
				} else {
					return CommandType.Console;
				}
			}
		}
		public override string Usage => "/" + this.Command + " Zombie";
		public override string Description => "Sets a lootable npc to be an exception to the whitelist (in turn after the blacklist).";



		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No npc name specified.", Color.Yellow );
				return;
			}

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			string entName = string.Join( " ", args );
			
			myworld.Logic.DataAccess.SetNpcLootBlacklist2Entry( entName );
			myworld.Logic.SyncDataChanges();

			caller.Reply( "Lootable npc " + entName + " added to whitelist exceptions (secondary blacklist).", Color.YellowGreen );
		}
	}
}
