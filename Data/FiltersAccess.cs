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
			Main.NewText( "Items BL: " + this.Data.ItemBlacklist.Count + ", WL count: " + this.Data.ItemWhitelist.Count );
			Main.NewText( "Recipes BL: " + this.Data.RecipeBlacklist.Count + ", WL count: " + this.Data.RecipeWhitelist.Count );
			Main.NewText( "NPCs BL: " + this.Data.NpcBlacklist.Count + ", WL count: " + this.Data.NpcWhitelist.Count );
			Main.NewText( "Loot BL: " + this.Data.NpcLootBlacklist.Count + ", WL count: " + this.Data.NpcLootWhitelist.Count );

			LogHelpers.Log( "Is nihilated: " + this.Data.IsActive );
			LogHelpers.Log( "Items BL: " + string.Join( ", ", this.Data.ItemBlacklist ) + ", WL count: " + string.Join( ", ", this.Data.ItemWhitelist ) );
			LogHelpers.Log( "Recipes BL: " + string.Join( ", ", this.Data.RecipeBlacklist ) + ", WL count: " + string.Join( ", ", this.Data.RecipeWhitelist ) );
			LogHelpers.Log( "NPCs BL: " + string.Join( ", ", this.Data.NpcBlacklist ) + ", WL count: " + string.Join( ", ", this.Data.NpcWhitelist ) );
			LogHelpers.Log( "Loot BL: " + string.Join( ", ", this.Data.NpcLootBlacklist ) + ", WL count: " + string.Join( ", ", this.Data.NpcLootWhitelist ) );
		}
	}
}
