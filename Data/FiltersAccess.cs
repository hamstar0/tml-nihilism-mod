using HamstarHelpers.Helpers.DebugHelpers;
using HamstarHelpers.Helpers.MiscHelpers;
using HamstarHelpers.Helpers.WorldHelpers;
using System.Collections.Generic;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		private NihilismFilterData Data;



		////////////////

		public NihilismFilterAccess() {
			this.Data = new NihilismFilterData();
		}


		////////////////

		private string GetDataFileName() {
			return WorldHelpers.GetUniqueIdWithSeed() + " Filters";
		}

		public void Load() {
			var mymod = NihilismMod.Instance;
			bool success;
			var filters = DataFileHelpers.LoadJson<NihilismFilterData>( mymod, this.GetDataFileName(), out success );

			if( success ) {
				this.Data = filters;
			}
		}

		public void Save() {
			var mymod = NihilismMod.Instance;
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

		public IEnumerable<string> GetFormattedFilterData( string subspace="  " ) {
			return new string[] { "Is nihilated: " + this.Data.IsActive,
				"Items BL:\n  " + string.Join( ", ", this.Data.ItemBlacklist ),
				"Items WL:\n  " + string.Join( ", ", this.Data.ItemWhitelist ),
				"Recipes BL:\n  " + string.Join( ", ", this.Data.RecipeBlacklist ),
				"Recipes WL:\n  " + string.Join( ", ", this.Data.RecipeWhitelist ),
				"NPCs BL:\n  " + string.Join( ", ", this.Data.NpcBlacklist ),
				"Loot WL:\n  " + string.Join( ", ", this.Data.NpcLootWhitelist )
			};
		}
		
		public void OutputFormattedFilterData() {
			Main.NewText( "Is nihilated: " + this.Data.IsActive );
			Main.NewText( "Items BL: " + this.Data.ItemBlacklist.Count + ", WL count: " + this.Data.ItemWhitelist.Count );
			Main.NewText( "Recipes BL: " + this.Data.RecipeBlacklist.Count + ", WL count: " + this.Data.RecipeWhitelist.Count );
			Main.NewText( "NPCs BL: " + this.Data.NpcBlacklist.Count + ", WL count: " + this.Data.NpcWhitelist.Count );
			Main.NewText( "Loot BL: " + this.Data.NpcLootBlacklist.Count + ", WL count: " + this.Data.NpcLootWhitelist.Count );

			LogHelpers.Log( string.Join("\n", this.GetFormattedFilterData()) );
		}
	}
}
