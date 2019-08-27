using HamstarHelpers.Helpers.Debug;
using System.Collections.Generic;
using Terraria;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		private readonly object MyLock = new object();



		////////////////

		private NihilismFilterConfig FilterConfig {
			get {
				var mymod = NihilismMod.Instance;

				if( mymod.InstancedFilters ) {
					if( this.ConfigCache == null ) {
						this.ConfigCache = (NihilismFilterConfig)mymod.GetConfig<NihilismFilterConfig>().Clone();
					}
					return this.ConfigCache;
				} else {
					return mymod.GetConfig<NihilismFilterConfig>();
				}
			}
		}

		private NihilismFilterConfig ConfigCache = null;



		////////////////

		public NihilismFilterAccess() { }


		////////////////

		internal void Give( ref NihilismFilterConfig data ) {
			data = this.FilterConfig;
		}

		internal void Take( NihilismFilterConfig data ) {
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
				"Items WL:\n  " + string.Join( ", ", this.FilterConfig.ItemWhitelist ),
				"Recipes BL:\n  " + string.Join( ", ", this.FilterConfig.RecipeBlacklist ),
				"Recipes WL:\n  " + string.Join( ", ", this.FilterConfig.RecipeWhitelist ),
				"NPCs BL:\n  " + string.Join( ", ", this.FilterConfig.NpcBlacklist ),
				"Loot WL:\n  " + string.Join( ", ", this.FilterConfig.NpcLootWhitelist )
			};
		}
		
		public void OutputFormattedFilterData() {
			Main.NewText( "Is nihilated: " + this.FilterConfig.IsActive );
			Main.NewText( "Items BL: " + this.FilterConfig.ItemBlacklist.Count + ", WL count: " + this.FilterConfig.ItemWhitelist.Count );
			Main.NewText( "Recipes BL: " + this.FilterConfig.RecipeBlacklist.Count + ", WL count: " + this.FilterConfig.RecipeWhitelist.Count );
			Main.NewText( "NPCs BL: " + this.FilterConfig.NpcBlacklist.Count + ", WL count: " + this.FilterConfig.NpcWhitelist.Count );
			Main.NewText( "Loot BL: " + this.FilterConfig.NpcLootBlacklist.Count + ", WL count: " + this.FilterConfig.NpcLootWhitelist.Count );

			LogHelpers.Log( string.Join("\n", this.GetFormattedFilterData()) );
		}
	}
}
