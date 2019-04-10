﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class RecipeBlacklistSetCommand : ModCommand {
		public override string Command => "nih-recipe-blacklist-set";
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
		public override string Description => "Adds a recipe to the blacklist (checked before whitelist).";



		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			if( args.Length == 0 ) {
				caller.Reply( "No item name specified.", Color.Yellow );
				return;
			}

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			string entName = string.Join( " ", args );

			myworld.Logic.DataAccess.SetRecipeBlacklistEntry( entName );
			myworld.Logic.SyncDataChanges();

			caller.Reply( "Recipe for item " + entName + " added to blacklist.", Color.YellowGreen );
		}
	}
}