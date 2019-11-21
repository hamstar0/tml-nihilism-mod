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

		public NihilismFilters() {
			this.ResetFiltersFromDefaults();
		}

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

			this.ItemBlacklist = new HashSet<ItemDefinition>( mymod.Config.DefaultItemBlacklist );  // Was there a reason these weren't cloned?
			this.RecipeBlacklist = new HashSet<ItemDefinition>( mymod.Config.DefaultRecipeBlacklist );//
			this.NpcBlacklist = new HashSet<NPCDefinition>( mymod.Config.DefaultNpcBlacklist );//
			this.NpcLootBlacklist = new HashSet<NPCDefinition>( mymod.Config.DefaultNpcLootBlacklist );//

			this.RecipeWhitelist = new HashSet<ItemDefinition>( mymod.Config.DefaultRecipeWhitelist );
			this.ItemWhitelist = new HashSet<ItemDefinition>( mymod.Config.DefaultItemWhitelist );
			this.NpcWhitelist = new HashSet<NPCDefinition>( mymod.Config.DefaultNpcWhitelist );
			this.NpcLootWhitelist = new HashSet<NPCDefinition>( mymod.Config.DefaultNpcLootWhitelist );

			this.ItemBlacklist2 = new HashSet<ItemDefinition>( mymod.Config.DefaultItemBlacklist2 );
			this.RecipeBlacklist2 = new HashSet<ItemDefinition>( mymod.Config.DefaultRecipeBlacklist2 );
			this.NpcBlacklist2 = new HashSet<NPCDefinition>( mymod.Config.DefaultNpcBlacklist2 );
			this.NpcLootBlacklist2 = new HashSet<NPCDefinition>( mymod.Config.DefaultNpcLootBlacklist2 );


			this.ItemGroupBlacklist = new HashSet<string>( mymod.Config.DefaultItemGroupBlacklist );
			this.RecipeGroupBlacklist = new HashSet<string>( mymod.Config.DefaultRecipeGroupBlacklist );
			this.NpcGroupBlacklist = new HashSet<string>( mymod.Config.DefaultNpcGroupBlacklist );
			this.NpcLootGroupBlacklist = new HashSet<string>( mymod.Config.DefaultNpcLootGroupBlacklist );

			this.RecipeGroupWhitelist = new HashSet<string>( mymod.Config.DefaultRecipeGroupWhitelist );
			this.ItemGroupWhitelist = new HashSet<string>( mymod.Config.DefaultItemGroupWhitelist );
			this.NpcGroupWhitelist = new HashSet<string>( mymod.Config.DefaultNpcGroupWhitelist );
			this.NpcLootGroupWhitelist = new HashSet<string>( mymod.Config.DefaultNpcLootGroupWhitelist );

			this.ItemGroupBlacklist2 = new HashSet<string>( mymod.Config.DefaultItemGroupBlacklist2 );
			this.RecipeGroupBlacklist2 = new HashSet<string>( mymod.Config.DefaultRecipeGroupBlacklist2 );
			this.NpcGroupBlacklist2 = new HashSet<string>( mymod.Config.DefaultNpcGroupBlacklist2 );
			this.NpcLootGroupBlacklist2 = new HashSet<string>( mymod.Config.DefaultNpcLootGroupBlacklist2 );
		}

		public void SetCurrentFiltersAsDefaults() {
			var mymod = NihilismMod.Instance;

			mymod.Config.DefaultItemBlacklist = new HashSet<ItemDefinition>( this.ItemBlacklist );  // Was there a reason these weren't cloned?
			mymod.Config.DefaultRecipeBlacklist = new HashSet<ItemDefinition>( this.RecipeBlacklist );//
			mymod.Config.DefaultNpcBlacklist = new HashSet<NPCDefinition>( this.NpcBlacklist );//
			mymod.Config.DefaultNpcLootBlacklist = new HashSet<NPCDefinition>( this.NpcLootBlacklist );//

			mymod.Config.DefaultRecipeWhitelist = new HashSet<ItemDefinition>( this.RecipeWhitelist );
			mymod.Config.DefaultItemWhitelist = new HashSet<ItemDefinition>( this.ItemWhitelist );
			mymod.Config.DefaultNpcWhitelist = new HashSet<NPCDefinition>( this.NpcWhitelist );
			mymod.Config.DefaultNpcLootWhitelist = new HashSet<NPCDefinition>( this.NpcLootWhitelist );

			mymod.Config.DefaultItemBlacklist2 = new HashSet<ItemDefinition>( this.ItemBlacklist2 );
			mymod.Config.DefaultRecipeBlacklist2 = new HashSet<ItemDefinition>( this.RecipeBlacklist2 );
			mymod.Config.DefaultNpcBlacklist2 = new HashSet<NPCDefinition>( this.NpcBlacklist2 );
			mymod.Config.DefaultNpcLootBlacklist2 = new HashSet<NPCDefinition>( this.NpcLootBlacklist2 );


			mymod.Config.DefaultItemGroupBlacklist = new HashSet<string>( this.ItemGroupBlacklist );
			mymod.Config.DefaultRecipeGroupBlacklist = new HashSet<string>( this.RecipeGroupBlacklist );
			mymod.Config.DefaultNpcGroupBlacklist = new HashSet<string>( this.NpcGroupBlacklist );
			mymod.Config.DefaultNpcLootGroupBlacklist = new HashSet<string>( this.NpcLootGroupBlacklist );

			mymod.Config.DefaultRecipeGroupWhitelist = new HashSet<string>( this.RecipeGroupWhitelist );
			mymod.Config.DefaultItemGroupWhitelist = new HashSet<string>( this.ItemGroupWhitelist );
			mymod.Config.DefaultNpcGroupWhitelist = new HashSet<string>( this.NpcGroupWhitelist );
			mymod.Config.DefaultNpcLootGroupWhitelist = new HashSet<string>( this.NpcLootGroupWhitelist );

			mymod.Config.DefaultItemGroupBlacklist2 = new HashSet<string>( this.ItemGroupBlacklist2 );
			mymod.Config.DefaultRecipeGroupBlacklist2 = new HashSet<string>( this.RecipeGroupBlacklist2 );
			mymod.Config.DefaultNpcGroupBlacklist2 = new HashSet<string>( this.NpcGroupBlacklist2 );
			mymod.Config.DefaultNpcLootGroupBlacklist2 = new HashSet<string>( this.NpcLootGroupBlacklist2 );
		}
	}
}
