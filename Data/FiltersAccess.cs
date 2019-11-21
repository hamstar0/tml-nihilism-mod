using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.Misc;
using HamstarHelpers.Helpers.World;
using System.Collections.Generic;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFiltersAccess {
		private readonly object MyLock = new object();



		////////////////

		private NihilismFilters FilterConfig {
			get {
				var mymod = NihilismMod.Instance;

				if( mymod.InstancedFilters ) {
					if( this.FiltersSeparateCopy == null ) {
						this.FiltersSeparateCopy = (NihilismFilters)this.Filters.Clone();
					}
					return this.FiltersSeparateCopy;
				} else {
					return this.Filters;
				}
			}
		}

		private NihilismFilters Filters = new NihilismFilters();
		private NihilismFilters FiltersSeparateCopy = null;



		////////////////

		public NihilismFiltersAccess() { }


		////////////////

		internal void Load() {
			string worldUid = WorldHelpers.GetUniqueIdForCurrentWorld( true );

			var filters = ModCustomDataFileHelpers.LoadJson<NihilismFilters>( NihilismMod.Instance, worldUid );
			this.Filters = filters != null ? filters : this.Filters;
		}

		internal void Save() {
			string worldUid = WorldHelpers.GetUniqueIdForCurrentWorld( true );

			ModCustomDataFileHelpers.SaveAsJson( NihilismMod.Instance, worldUid, true, this.Filters );
		}


		////////////////

		internal void Give( ref NihilismFilters data ) {
			data = this.FilterConfig;
		}

		internal void Take( NihilismFilters data ) {
			this.FilterConfig.CopyFrom( data );
		}


		////////////////

		public void SetCurrentFiltersAsDefaults() {
			this.FilterConfig.SetCurrentFiltersAsDefaults();
		}

		public void ResetFiltersFromDefaults() {
			this.FilterConfig.ResetFiltersFromDefaults();
		}


		////////////////

		public bool IsActive() {
			return this.FilterConfig.IsActive;
		}

		public void Activate() {
			this.FilterConfig.IsActive = true;
		}

		public void Deactivate() {
			this.FilterConfig.IsActive = false;
		}


		////////////////

		public IEnumerable<string> GetFormattedFilterData( string subspace="  " ) {
			return new string[] { "Is nihilated: " + this.FilterConfig.IsActive,
				"Items BL:\n  " + string.Join( ", ", this.FilterConfig.ItemBlacklist ),
				"Item Groups BL:\n  " + string.Join( ", ", this.FilterConfig.ItemGroupBlacklist ),
				"Items WL:\n  " + string.Join( ", ", this.FilterConfig.ItemWhitelist ),
				"Items Groups WL:\n  " + string.Join( ", ", this.FilterConfig.ItemGroupWhitelist ),
				"Recipes BL:\n  " + string.Join( ", ", this.FilterConfig.RecipeBlacklist ),
				"Recipes Groups BL:\n  " + string.Join( ", ", this.FilterConfig.RecipeGroupBlacklist ),
				"Recipes WL:\n  " + string.Join( ", ", this.FilterConfig.RecipeWhitelist ),
				"Recipes Groups WL:\n  " + string.Join( ", ", this.FilterConfig.RecipeGroupWhitelist ),
				"NPCs BL:\n  " + string.Join( ", ", this.FilterConfig.NpcBlacklist ),
				"NPCs Groups BL:\n  " + string.Join( ", ", this.FilterConfig.NpcGroupBlacklist ),
				"Loot WL:\n  " + string.Join( ", ", this.FilterConfig.NpcLootWhitelist ),
				"Loot Groups WL:\n  " + string.Join( ", ", this.FilterConfig.NpcLootGroupWhitelist )
			};
		}
		
		public void OutputFormattedFilterData() {
			Main.NewText( "Is nihilated: " + this.FilterConfig.IsActive );
			Main.NewText( "Items BL: "
				+ this.FilterConfig.ItemBlacklist.Count + "+"
				+ this.FilterConfig.ItemGroupBlacklist.Count + ", WL count: "
				+ this.FilterConfig.ItemWhitelist.Count + "+"
				+ this.FilterConfig.ItemGroupWhitelist.Count );
			Main.NewText( "Recipes BL: "
				+ this.FilterConfig.RecipeBlacklist.Count + "+"
				+ this.FilterConfig.RecipeGroupBlacklist.Count + ", WL count: "
				+ this.FilterConfig.RecipeWhitelist.Count + "+"
				+ this.FilterConfig.RecipeGroupWhitelist.Count );
			Main.NewText( "NPCs BL: "
				+ this.FilterConfig.NpcBlacklist.Count + "+"
				+ this.FilterConfig.NpcGroupBlacklist.Count + ", WL count: "
				+ this.FilterConfig.NpcWhitelist.Count + "+"
				+ this.FilterConfig.NpcGroupWhitelist.Count );
			Main.NewText( "Loot BL: "
				+ this.FilterConfig.NpcLootGroupBlacklist.Count + "+"
				+ this.FilterConfig.NpcLootBlacklist.Count + ", WL count: "
				+ this.FilterConfig.NpcLootGroupWhitelist.Count + "+"
				+ this.FilterConfig.NpcLootWhitelist.Count );

			LogHelpers.Log( string.Join("\n", this.GetFormattedFilterData()) );
		}
	}
}
