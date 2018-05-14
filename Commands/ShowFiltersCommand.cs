using HamstarHelpers.DebugHelpers;
using Terraria;
using Terraria.ModLoader;


namespace Nihilism.Commands {
	class ShowFiltersCommand : ModCommand {
		public override string Command {
			get {
				return "nih_showfilters";
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
				return "/" + this.Command;
			}
		}
		public override string Description {
			get {
				return "Displays each filter currently active or the world.";
			}
		}


		////////////////

		public override void Action( CommandCaller caller, string input, string[] args ) {
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			Main.NewText( "Is nihilated: " + myworld.Logic.IsCurrentWorldNihilated() );
			Main.NewText( "Items BL: " + myworld.Logic.Data.ItemsBlacklistPattern+", WL count: "+myworld.Logic.Data.ItemWhitelist.Count );
			Main.NewText( "Recipes BL: " + myworld.Logic.Data.RecipesBlacklistPattern + ", WL count: " + myworld.Logic.Data.RecipeWhitelist.Count );
			Main.NewText( "NPCs BL: " + myworld.Logic.Data.NpcBlacklistPattern + ", WL count: " + myworld.Logic.Data.NpcWhitelist.Count );
			Main.NewText( "Loot BL: " + myworld.Logic.Data.NpcLootBlacklistPattern + ", WL count: " + myworld.Logic.Data.NpcLootWhitelist.Count );

			LogHelpers.Log( "Is nihilated: " + myworld.Logic.IsCurrentWorldNihilated() );
			LogHelpers.Log( "Items BL: " + myworld.Logic.Data.ItemsBlacklistPattern + ", WL count: " + string.Join(", ", myworld.Logic.Data.ItemWhitelist.Keys) );
			LogHelpers.Log( "Recipes BL: " + myworld.Logic.Data.RecipesBlacklistPattern + ", WL count: " + string.Join( ", ", myworld.Logic.Data.RecipeWhitelist.Keys ) );
			LogHelpers.Log( "NPCs BL: " + myworld.Logic.Data.NpcBlacklistPattern + ", WL count: " + string.Join( ", ", myworld.Logic.Data.NpcWhitelist.Keys ) );
			LogHelpers.Log( "Loot BL: " + myworld.Logic.Data.NpcLootBlacklistPattern + ", WL count: " + string.Join( ", ", myworld.Logic.Data.NpcLootWhitelist.Keys ) );
		}
	}
}
