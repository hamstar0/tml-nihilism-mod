using HamstarHelpers.DebugHelpers;
using HamstarHelpers.MiscHelpers;
using HamstarHelpers.WorldHelpers;
using Terraria;

namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		private NihilismFilterData Data;


		public NihilismFilterAccess( NihilismFilterData data ) {
			this.Data = data;
		}


		////////////////

		private string GetDataFileName() {
			return WorldHelpers.GetUniqueId( true ) + " Filters";
		}

		public void Load( NihilismMod mymod ) {
			bool success;
			var filters = DataFileHelpers.LoadJson<NihilismFilterData>( mymod, this.GetDataFileName(), out success );

			if( success ) {
				this.Data = filters;
			}
		}

		public void Save( NihilismMod mymod ) {
			DataFileHelpers.SaveAsJson<NihilismFilterData>( mymod, this.GetDataFileName(), this.Data );
		}


		////////////////

		internal void Give( ref NihilismFilterData data ) {
			data = this.Data;
		}

		internal void Take( NihilismFilterData data ) {
			this.Data = data;
		}


		////////////////

		public void OutputFilters() {
			Main.NewText( "Is nihilated: " + this.Data.IsActive );
			Main.NewText( "Items BL: " + this.Data.ItemsBlacklistPattern + ", WL count: " + this.Data.ItemWhitelist.Count );
			Main.NewText( "Recipes BL: " + this.Data.RecipesBlacklistPattern + ", WL count: " + this.Data.RecipeWhitelist.Count );
			Main.NewText( "NPCs BL: " + this.Data.NpcBlacklistPattern + ", WL count: " + this.Data.NpcWhitelist.Count );
			Main.NewText( "Loot BL: " + this.Data.NpcLootBlacklistPattern + ", WL count: " + this.Data.NpcLootWhitelist.Count );

			LogHelpers.Log( "Is nihilated: " + this.Data.IsActive );
			LogHelpers.Log( "Items BL: " + this.Data.ItemsBlacklistPattern + ", WL count: " + string.Join( ", ", this.Data.ItemWhitelist.Keys ) );
			LogHelpers.Log( "Recipes BL: " + this.Data.RecipesBlacklistPattern + ", WL count: " + string.Join( ", ", this.Data.RecipeWhitelist.Keys ) );
			LogHelpers.Log( "NPCs BL: " + this.Data.NpcBlacklistPattern + ", WL count: " + string.Join( ", ", this.Data.NpcWhitelist.Keys ) );
			LogHelpers.Log( "Loot BL: " + this.Data.NpcLootBlacklistPattern + ", WL count: " + string.Join( ", ", this.Data.NpcLootWhitelist.Keys ) );
		}
	}
}
