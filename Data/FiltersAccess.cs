using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.Misc;
using HamstarHelpers.Helpers.World;
using System.Collections.Generic;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		private readonly object MyLock = new object();



		////////////////

		private NihilismFilters Filters {
			get {
				var mymod = NihilismMod.Instance;

				if( mymod.InstancedFilters ) {
					if( this.FiltersSeparateCopy == null ) {
						this.FiltersSeparateCopy = (NihilismFilters)this.FiltersInternalCopy.Clone();
					}
					return this.FiltersSeparateCopy;
				} else {
					return this.FiltersInternalCopy;
				}
			}
		}

		private NihilismFilters FiltersInternalCopy = new NihilismFilters();
		private NihilismFilters FiltersSeparateCopy = null;



		////////////////

		public NihilismFiltersAccess() { }


		////////////////

		internal void Load() {
			string worldUid = WorldHelpers.GetUniqueIdForCurrentWorld( true );

			var filters = ModCustomDataFileHelpers.LoadJson<NihilismFilters>( NihilismMod.Instance, worldUid );
			this.FiltersInternalCopy = filters != null ? filters : this.FiltersInternalCopy;
		}

		internal void Save() {
			string worldUid = WorldHelpers.GetUniqueIdForCurrentWorld( true );

			ModCustomDataFileHelpers.SaveAsJson( NihilismMod.Instance, worldUid, true, this.FiltersInternalCopy );
		}


		////////////////

		internal void Give( ref NihilismFilters data ) {
			data = this.Filters;
		}

		internal void Take( NihilismFilters data ) {
			this.Filters.CopyFrom( data );
		}


		////////////////

		public void SetCurrentFiltersAsDefaults() {
			this.Filters.SetCurrentFiltersAsDefaults();
		}

		public void ResetFiltersFromDefaults() {
			this.Filters.ResetFiltersFromDefaults();
		}


		////////////////

		public bool IsActive() {
			return this.Filters.IsActive;
		}

		public void Activate() {
			this.Filters.IsActive = true;
		}

		public void Deactivate() {
			this.Filters.IsActive = false;
		}


		////////////////

		public IEnumerable<string> GetFormattedFilterData( string subspace="  " ) {
			return new string[] { "Is nihilated: " + this.Filters.IsActive,
				"Items BL:\n  " + string.Join( ", ", this.Filters.ItemBlacklist ),
				"Item Groups BL:\n  " + string.Join( ", ", this.Filters.ItemGroupBlacklist ),
				"Items WL:\n  " + string.Join( ", ", this.Filters.ItemWhitelist ),
				"Items Groups WL:\n  " + string.Join( ", ", this.Filters.ItemGroupWhitelist ),
				"Recipes BL:\n  " + string.Join( ", ", this.Filters.RecipeBlacklist ),
				"Recipes Groups BL:\n  " + string.Join( ", ", this.Filters.RecipeGroupBlacklist ),
				"Recipes WL:\n  " + string.Join( ", ", this.Filters.RecipeWhitelist ),
				"Recipes Groups WL:\n  " + string.Join( ", ", this.Filters.RecipeGroupWhitelist ),
				"NPCs BL:\n  " + string.Join( ", ", this.Filters.NpcBlacklist ),
				"NPCs Groups BL:\n  " + string.Join( ", ", this.Filters.NpcGroupBlacklist ),
				"Loot WL:\n  " + string.Join( ", ", this.Filters.NpcLootWhitelist ),
				"Loot Groups WL:\n  " + string.Join( ", ", this.Filters.NpcLootGroupWhitelist )
			};
		}
		
		public void OutputFormattedFilterData() {
			Main.NewText( "Is nihilated: " + this.Filters.IsActive );
			Main.NewText( "Items BL: "
				+ this.Filters.ItemBlacklist.Count + "+"
				+ this.Filters.ItemGroupBlacklist.Count + ", WL count: "
				+ this.Filters.ItemWhitelist.Count + "+"
				+ this.Filters.ItemGroupWhitelist.Count );
			Main.NewText( "Recipes BL: "
				+ this.Filters.RecipeBlacklist.Count + "+"
				+ this.Filters.RecipeGroupBlacklist.Count + ", WL count: "
				+ this.Filters.RecipeWhitelist.Count + "+"
				+ this.Filters.RecipeGroupWhitelist.Count );
			Main.NewText( "NPCs BL: "
				+ this.Filters.NpcBlacklist.Count + "+"
				+ this.Filters.NpcGroupBlacklist.Count + ", WL count: "
				+ this.Filters.NpcWhitelist.Count + "+"
				+ this.Filters.NpcGroupWhitelist.Count );
			Main.NewText( "Loot BL: "
				+ this.Filters.NpcLootGroupBlacklist.Count + "+"
				+ this.Filters.NpcLootBlacklist.Count + ", WL count: "
				+ this.Filters.NpcLootGroupWhitelist.Count + "+"
				+ this.Filters.NpcLootWhitelist.Count );

			LogHelpers.Log( string.Join("\n", this.GetFormattedFilterData()) );
		}
	}
}
