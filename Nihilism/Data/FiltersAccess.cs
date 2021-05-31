using System.Collections.Generic;
using Terraria;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Libraries.Misc;
using ModLibsCore.Libraries.World;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		private readonly object MyLock = new object();



		////////////////

		private NihilismFilters Filters {
			get {
				if( NihilismMod.Instance.InstancedFilters ) {
					if( this.FiltersNoSaveCopy == null ) {
						this.FiltersNoSaveCopy = (NihilismFilters)this.FiltersSaveCopy.Clone();
					}
					return this.FiltersNoSaveCopy;
				}

				return this.FiltersSaveCopy;
			}
		}

		private NihilismFilters FiltersSaveCopy = null;
		private NihilismFilters FiltersNoSaveCopy = null;



		////////////////

		public NihilismFiltersAccess() {
			this.FiltersSaveCopy = new NihilismFilters();
			this.FiltersSaveCopy.ResetFiltersFromDefaults();
		}


		////////////////

		internal void Load() {
			string worldUid = WorldIdentityLibraries.GetUniqueIdForCurrentWorld( true );

			var filters = ModCustomDataFileLibraries.LoadJson<NihilismFilters>( NihilismMod.Instance, worldUid );
			this.FiltersSaveCopy = filters != null
				? filters
				: this.FiltersSaveCopy;
		}

		internal void Save() {
			string worldUid = WorldIdentityLibraries.GetUniqueIdForCurrentWorld( true );

			ModCustomDataFileLibraries.SaveAsJson( NihilismMod.Instance, worldUid, true, this.FiltersSaveCopy );
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

			LogLibraries.Log( string.Join("\n", this.GetFormattedFilterData()) );
		}
	}
}
