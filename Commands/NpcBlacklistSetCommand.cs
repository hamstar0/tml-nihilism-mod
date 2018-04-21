﻿using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class NpcBlacklistSetCommand : ModCommand {
		public override string Command { get {
			return "nih_npc_blacklist_set";
		} }
		public override CommandType Type { get {
			if( Main.netMode == 0 ) {
				return CommandType.World;
			} else {
				return CommandType.Console;
			}
		} }
		public override string Usage { get {
			return "/"+this.Command+ " ^(Demon Eye)$|^(Zombie)$";
		} }
		public override string Description { get {
			return "Sets the npc blacklist matching pattern. For help with using regexp, visit: https://regexr.com/";
		} }


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {

		}
	}
}
