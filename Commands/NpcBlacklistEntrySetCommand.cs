using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class NpcBlacklistEntrySetCommand : ModCommand {
		public override string Command => "nih-npc-blacklist-add";
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
		public override string Description => "Adds an npc to the blacklist (checked before whitelist).";


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No npc name specified.", Color.Yellow );
				return;
			}

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			string entName = string.Join( " ", args );

			myworld.Logic.DataAccess.SetNpcBlacklistEntry( entName );
			myworld.Logic.SyncDataChanges();

			caller.Reply( "Npc " + entName + " added to blacklist.", Color.YellowGreen );
		}
	}
}
