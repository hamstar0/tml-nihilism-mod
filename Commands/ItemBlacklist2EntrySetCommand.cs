using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class ItemBlacklist2EntrySetCommand : ModCommand {
		public override string Command => "nih-item-blacklist2-set";
		public override CommandType Type {
			get {
				if( Main.netMode == 0 && !Main.dedServ ) {
					return CommandType.World;
				} else {
					return CommandType.Console;
				}
			}
		}
		public override string Usage => "/" + this.Command + " Excalibur";
		public override string Description => "Sets an item to be an exception to the whitelist (in turn after the blacklist).";



		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No item name specified.", Color.Yellow );
				return;
			}

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			string entName = string.Join(" ", args);

			myworld.Logic.DataAccess.SetItemBlacklist2Entry( entName );
			myworld.Logic.SyncDataChanges();

			caller.Reply( "Item " + entName + " added to whitelist exceptions (secondary blacklist).", Color.YellowGreen );
		}
	}
}
