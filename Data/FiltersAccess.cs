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
			return WorldHelpers.GetUniqueIdWithSeed() + " Filters";
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
			Main.NewText( "Items BL: " + this.Data.IsItemFilterOn + ", WL count: " + this.Data.ItemWhitelist.Count );
			Main.NewText( "Recipes BL: " + this.Data.IsRecipeFilterOn + ", WL count: " + this.Data.RecipeWhitelist.Count );
			Main.NewText( "NPCs BL: " + this.Data.IsNpcFilterOn + ", WL count: " + this.Data.NpcWhitelist.Count );
			Main.NewText( "Loot BL: " + this.Data.IsNpcLootFilterOn + ", WL count: " + this.Data.NpcLootWhitelist.Count );

			LogHelpers.Log( "Is nihilated: " + this.Data.IsActive );
			LogHelpers.Log( "Items BL: " + this.Data.IsItemFilterOn + ", WL count: " + string.Join( ", ", this.Data.ItemWhitelist ) );
			LogHelpers.Log( "Recipes BL: " + this.Data.IsRecipeFilterOn + ", WL count: " + string.Join( ", ", this.Data.RecipeWhitelist ) );
			LogHelpers.Log( "NPCs BL: " + this.Data.IsNpcFilterOn + ", WL count: " + string.Join( ", ", this.Data.NpcWhitelist ) );
			LogHelpers.Log( "Loot BL: " + this.Data.IsNpcLootFilterOn + ", WL count: " + string.Join( ", ", this.Data.NpcLootWhitelist ) );
		}
	}
}
