using HamstarHelpers.Services.Configs;
using System.Collections.Generic;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFilters {
		public bool IsActive = false;

		////

		public HashSet<ItemDefinition> ItemBlacklist = new HashSet<ItemDefinition> { };
		public HashSet<ItemDefinition> RecipeBlacklist = new HashSet<ItemDefinition> { };
		public HashSet<NPCDefinition> NpcBlacklist = new HashSet<NPCDefinition> { };
		public HashSet<NPCDefinition> NpcLootBlacklist = new HashSet<NPCDefinition> { };

		public HashSet<ItemDefinition> RecipeWhitelist = new HashSet<ItemDefinition> { };
		public HashSet<ItemDefinition> ItemWhitelist = new HashSet<ItemDefinition> { };
		public HashSet<NPCDefinition> NpcWhitelist = new HashSet<NPCDefinition> { };
		public HashSet<NPCDefinition> NpcLootWhitelist = new HashSet<NPCDefinition> { };

		public HashSet<ItemDefinition> ItemBlacklist2 = new HashSet<ItemDefinition> { };
		public HashSet<ItemDefinition> RecipeBlacklist2 = new HashSet<ItemDefinition> { };
		public HashSet<NPCDefinition> NpcBlacklist2 = new HashSet<NPCDefinition> { };
		public HashSet<NPCDefinition> NpcLootBlacklist2 = new HashSet<NPCDefinition> { };

		public HashSet<string> ItemGroupBlacklist = new HashSet<string> { };
		public HashSet<string> RecipeGroupBlacklist = new HashSet<string> { };
		public HashSet<string> NpcGroupBlacklist = new HashSet<string> { };
		public HashSet<string> NpcLootGroupBlacklist = new HashSet<string> { };

		public HashSet<string> ItemGroupWhitelist = new HashSet<string> { };
		public HashSet<string> RecipeGroupWhitelist = new HashSet<string> { };
		public HashSet<string> NpcGroupWhitelist = new HashSet<string> { };
		public HashSet<string> NpcLootGroupWhitelist = new HashSet<string> { };

		public HashSet<string> ItemGroupBlacklist2 = new HashSet<string> { };
		public HashSet<string> RecipeGroupBlacklist2 = new HashSet<string> { };
		public HashSet<string> NpcGroupBlacklist2 = new HashSet<string> { };
		public HashSet<string> NpcLootGroupBlacklist2 = new HashSet<string> { };



		////////////////

		public NihilismFilters() { }

		public NihilismFilters Clone() {
			var clone = (NihilismFilters)base.MemberwiseClone();

			clone.ItemBlacklist = new HashSet<ItemDefinition>( this.ItemBlacklist );
			clone.RecipeBlacklist = new HashSet<ItemDefinition>( this.RecipeBlacklist );
			clone.NpcBlacklist = new HashSet<NPCDefinition>( this.NpcBlacklist );
			clone.NpcLootBlacklist = new HashSet<NPCDefinition>( this.NpcLootBlacklist );

			clone.RecipeWhitelist = new HashSet<ItemDefinition>( this.RecipeWhitelist );
			clone.ItemWhitelist = new HashSet<ItemDefinition>( this.ItemWhitelist );
			clone.NpcWhitelist = new HashSet<NPCDefinition>( this.NpcWhitelist );
			clone.NpcLootWhitelist = new HashSet<NPCDefinition>( this.NpcLootWhitelist );

			clone.ItemBlacklist2 = new HashSet<ItemDefinition>( this.ItemBlacklist2 );
			clone.RecipeBlacklist2 = new HashSet<ItemDefinition>( this.RecipeBlacklist2 );
			clone.NpcBlacklist2 = new HashSet<NPCDefinition>( this.NpcBlacklist2 );
			clone.NpcLootBlacklist2 = new HashSet<NPCDefinition>( this.NpcLootBlacklist2 );

			clone.ItemGroupBlacklist = new HashSet<string>( this.ItemGroupBlacklist );
			clone.RecipeGroupBlacklist = new HashSet<string>( this.RecipeGroupBlacklist );
			clone.NpcGroupBlacklist = new HashSet<string>( this.NpcGroupBlacklist );
			clone.NpcLootGroupBlacklist = new HashSet<string>( this.NpcLootGroupBlacklist );

			clone.RecipeGroupWhitelist = new HashSet<string>( this.RecipeGroupWhitelist );
			clone.ItemGroupWhitelist = new HashSet<string>( this.ItemGroupWhitelist );
			clone.NpcGroupWhitelist = new HashSet<string>( this.NpcGroupWhitelist );
			clone.NpcLootGroupWhitelist = new HashSet<string>( this.NpcLootGroupWhitelist );

			clone.ItemGroupBlacklist2 = new HashSet<string>( this.ItemGroupBlacklist2 );
			clone.RecipeGroupBlacklist2 = new HashSet<string>( this.RecipeGroupBlacklist2 );
			clone.NpcGroupBlacklist2 = new HashSet<string>( this.NpcGroupBlacklist2 );
			clone.NpcLootGroupBlacklist2 = new HashSet<string>( this.NpcLootGroupBlacklist2 );

			return clone;
		}


		////////////////

		internal void CopyFrom( NihilismFilters copy ) {
			this.IsActive = copy.IsActive;
			this.ItemBlacklist = new HashSet<ItemDefinition>( copy.ItemBlacklist );
			this.RecipeBlacklist = new HashSet<ItemDefinition>( copy.RecipeBlacklist );
			this.NpcBlacklist = new HashSet<NPCDefinition>( copy.NpcBlacklist );
			this.NpcLootBlacklist = new HashSet<NPCDefinition>( copy.NpcLootBlacklist );

			this.RecipeWhitelist = new HashSet<ItemDefinition>( copy.RecipeWhitelist );
			this.ItemWhitelist = new HashSet<ItemDefinition>( copy.ItemWhitelist );
			this.NpcWhitelist = new HashSet<NPCDefinition>( copy.NpcWhitelist );
			this.NpcLootWhitelist = new HashSet<NPCDefinition>( copy.NpcLootWhitelist );

			this.ItemBlacklist2 = new HashSet<ItemDefinition>( copy.ItemBlacklist2 );
			this.RecipeBlacklist2 = new HashSet<ItemDefinition>( copy.RecipeBlacklist2 );
			this.NpcBlacklist2 = new HashSet<NPCDefinition>( copy.NpcBlacklist2 );
			this.NpcLootBlacklist2 = new HashSet<NPCDefinition>( copy.NpcLootBlacklist2 );

			this.ItemGroupBlacklist = new HashSet<string>( copy.ItemGroupBlacklist );
			this.RecipeGroupBlacklist = new HashSet<string>( copy.RecipeGroupBlacklist );
			this.NpcGroupBlacklist = new HashSet<string>( copy.NpcGroupBlacklist );
			this.NpcLootGroupBlacklist = new HashSet<string>( copy.NpcLootGroupBlacklist );

			this.RecipeGroupWhitelist = new HashSet<string>( copy.RecipeGroupWhitelist );
			this.ItemGroupWhitelist = new HashSet<string>( copy.ItemGroupWhitelist );
			this.NpcGroupWhitelist = new HashSet<string>( copy.NpcGroupWhitelist );
			this.NpcLootGroupWhitelist = new HashSet<string>( copy.NpcLootGroupWhitelist );

			this.ItemGroupBlacklist2 = new HashSet<string>( copy.ItemGroupBlacklist2 );
			this.RecipeGroupBlacklist2 = new HashSet<string>( copy.RecipeGroupBlacklist2 );
			this.NpcGroupBlacklist2 = new HashSet<string>( copy.NpcGroupBlacklist2 );
			this.NpcLootGroupBlacklist2 = new HashSet<string>( copy.NpcLootGroupBlacklist2 );
		}

		////////////////

		public void ResetFiltersFromDefaults() {
			var mymod = NihilismMod.Instance;

			this.ItemBlacklist = new HashSet<ItemDefinition>( NihilismConfig.Instance.DefaultItemBlacklist );  // Was there a reason these weren't cloned?
			this.RecipeBlacklist = new HashSet<ItemDefinition>( NihilismConfig.Instance.DefaultRecipeBlacklist );//
			this.NpcBlacklist = new HashSet<NPCDefinition>( NihilismConfig.Instance.DefaultNpcBlacklist );//
			this.NpcLootBlacklist = new HashSet<NPCDefinition>( NihilismConfig.Instance.DefaultNpcLootBlacklist );//

			this.RecipeWhitelist = new HashSet<ItemDefinition>( NihilismConfig.Instance.DefaultRecipeWhitelist );
			this.ItemWhitelist = new HashSet<ItemDefinition>( NihilismConfig.Instance.DefaultItemWhitelist );
			this.NpcWhitelist = new HashSet<NPCDefinition>( NihilismConfig.Instance.DefaultNpcWhitelist );
			this.NpcLootWhitelist = new HashSet<NPCDefinition>( NihilismConfig.Instance.DefaultNpcLootWhitelist );

			this.ItemBlacklist2 = new HashSet<ItemDefinition>( NihilismConfig.Instance.DefaultItemBlacklist2 );
			this.RecipeBlacklist2 = new HashSet<ItemDefinition>( NihilismConfig.Instance.DefaultRecipeBlacklist2 );
			this.NpcBlacklist2 = new HashSet<NPCDefinition>( NihilismConfig.Instance.DefaultNpcBlacklist2 );
			this.NpcLootBlacklist2 = new HashSet<NPCDefinition>( NihilismConfig.Instance.DefaultNpcLootBlacklist2 );


			this.ItemGroupBlacklist = new HashSet<string>( NihilismConfig.Instance.DefaultItemGroupBlacklist );
			this.RecipeGroupBlacklist = new HashSet<string>( NihilismConfig.Instance.DefaultRecipeGroupBlacklist );
			this.NpcGroupBlacklist = new HashSet<string>( NihilismConfig.Instance.DefaultNpcGroupBlacklist );
			this.NpcLootGroupBlacklist = new HashSet<string>( NihilismConfig.Instance.DefaultNpcLootGroupBlacklist );

			this.RecipeGroupWhitelist = new HashSet<string>( NihilismConfig.Instance.DefaultRecipeGroupWhitelist );
			this.ItemGroupWhitelist = new HashSet<string>( NihilismConfig.Instance.DefaultItemGroupWhitelist );
			this.NpcGroupWhitelist = new HashSet<string>( NihilismConfig.Instance.DefaultNpcGroupWhitelist );
			this.NpcLootGroupWhitelist = new HashSet<string>( NihilismConfig.Instance.DefaultNpcLootGroupWhitelist );

			this.ItemGroupBlacklist2 = new HashSet<string>( NihilismConfig.Instance.DefaultItemGroupBlacklist2 );
			this.RecipeGroupBlacklist2 = new HashSet<string>( NihilismConfig.Instance.DefaultRecipeGroupBlacklist2 );
			this.NpcGroupBlacklist2 = new HashSet<string>( NihilismConfig.Instance.DefaultNpcGroupBlacklist2 );
			this.NpcLootGroupBlacklist2 = new HashSet<string>( NihilismConfig.Instance.DefaultNpcLootGroupBlacklist2 );
		}

		public void SetCurrentFiltersAsDefaults() {
			NihilismConfig.Instance.DefaultItemBlacklist = new HashSet<ItemDefinition>( this.ItemBlacklist );  // Was there a reason these weren't cloned?
			NihilismConfig.Instance.DefaultRecipeBlacklist = new HashSet<ItemDefinition>( this.RecipeBlacklist );//
			NihilismConfig.Instance.DefaultNpcBlacklist = new HashSet<NPCDefinition>( this.NpcBlacklist );//
			NihilismConfig.Instance.DefaultNpcLootBlacklist = new HashSet<NPCDefinition>( this.NpcLootBlacklist );//

			NihilismConfig.Instance.DefaultRecipeWhitelist = new HashSet<ItemDefinition>( this.RecipeWhitelist );
			NihilismConfig.Instance.DefaultItemWhitelist = new HashSet<ItemDefinition>( this.ItemWhitelist );
			NihilismConfig.Instance.DefaultNpcWhitelist = new HashSet<NPCDefinition>( this.NpcWhitelist );
			NihilismConfig.Instance.DefaultNpcLootWhitelist = new HashSet<NPCDefinition>( this.NpcLootWhitelist );

			NihilismConfig.Instance.DefaultItemBlacklist2 = new HashSet<ItemDefinition>( this.ItemBlacklist2 );
			NihilismConfig.Instance.DefaultRecipeBlacklist2 = new HashSet<ItemDefinition>( this.RecipeBlacklist2 );
			NihilismConfig.Instance.DefaultNpcBlacklist2 = new HashSet<NPCDefinition>( this.NpcBlacklist2 );
			NihilismConfig.Instance.DefaultNpcLootBlacklist2 = new HashSet<NPCDefinition>( this.NpcLootBlacklist2 );


			NihilismConfig.Instance.DefaultItemGroupBlacklist = new HashSet<string>( this.ItemGroupBlacklist );
			NihilismConfig.Instance.DefaultRecipeGroupBlacklist = new HashSet<string>( this.RecipeGroupBlacklist );
			NihilismConfig.Instance.DefaultNpcGroupBlacklist = new HashSet<string>( this.NpcGroupBlacklist );
			NihilismConfig.Instance.DefaultNpcLootGroupBlacklist = new HashSet<string>( this.NpcLootGroupBlacklist );

			NihilismConfig.Instance.DefaultRecipeGroupWhitelist = new HashSet<string>( this.RecipeGroupWhitelist );
			NihilismConfig.Instance.DefaultItemGroupWhitelist = new HashSet<string>( this.ItemGroupWhitelist );
			NihilismConfig.Instance.DefaultNpcGroupWhitelist = new HashSet<string>( this.NpcGroupWhitelist );
			NihilismConfig.Instance.DefaultNpcLootGroupWhitelist = new HashSet<string>( this.NpcLootGroupWhitelist );

			NihilismConfig.Instance.DefaultItemGroupBlacklist2 = new HashSet<string>( this.ItemGroupBlacklist2 );
			NihilismConfig.Instance.DefaultRecipeGroupBlacklist2 = new HashSet<string>( this.RecipeGroupBlacklist2 );
			NihilismConfig.Instance.DefaultNpcGroupBlacklist2 = new HashSet<string>( this.NpcGroupBlacklist2 );
			NihilismConfig.Instance.DefaultNpcLootGroupBlacklist2 = new HashSet<string>( this.NpcLootGroupBlacklist2 );

			ModConfigStack.Uncache<NihilismConfig>();
		}
	}
}
