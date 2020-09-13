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
			var config = NihilismConfig.Instance;
			var mymod = NihilismMod.Instance;

			this.ItemBlacklist = new HashSet<ItemDefinition>(  // Was there a reason these weren't cloned?
				config.Get<HashSet<ItemDefinition>>( nameof(NihilismConfig.DefaultItemBlacklist) )
			);
			this.RecipeBlacklist = new HashSet<ItemDefinition>(//
				config.Get<HashSet<ItemDefinition>>( nameof(NihilismConfig.DefaultRecipeBlacklist) )
			);
			this.NpcBlacklist = new HashSet<NPCDefinition>(//
				config.Get<HashSet<NPCDefinition>>( nameof(NihilismConfig.DefaultNpcBlacklist) )
			);
			this.NpcLootBlacklist = new HashSet<NPCDefinition>(//
				config.Get<HashSet<NPCDefinition>>( nameof(NihilismConfig.DefaultNpcLootBlacklist) )
			);

			this.ItemWhitelist = new HashSet<ItemDefinition>(
				config.Get<HashSet<ItemDefinition>>( nameof(NihilismConfig.DefaultItemWhitelist) )
			);
			this.RecipeWhitelist = new HashSet<ItemDefinition>(
				config.Get<HashSet<ItemDefinition>>( nameof(NihilismConfig.DefaultRecipeWhitelist) )
			);
			this.NpcWhitelist = new HashSet<NPCDefinition>(
				config.Get<HashSet<NPCDefinition>>( nameof(NihilismConfig.DefaultNpcWhitelist) )
			);
			this.NpcLootWhitelist = new HashSet<NPCDefinition>(
				config.Get<HashSet<NPCDefinition>>( nameof(NihilismConfig.DefaultNpcLootWhitelist) )
			);

			this.ItemBlacklist2 = new HashSet<ItemDefinition>(
				config.Get<HashSet<ItemDefinition>>( nameof(NihilismConfig.DefaultItemBlacklist2) )
			);
			this.RecipeBlacklist2 = new HashSet<ItemDefinition>(
				config.Get<HashSet<ItemDefinition>>( nameof(NihilismConfig.DefaultRecipeBlacklist2) )
			);
			this.NpcBlacklist2 = new HashSet<NPCDefinition>(
				config.Get<HashSet<NPCDefinition>>( nameof(NihilismConfig.DefaultNpcBlacklist2) )
			);
			this.NpcLootBlacklist2 = new HashSet<NPCDefinition>(
				config.Get<HashSet<NPCDefinition>>( nameof(NihilismConfig.DefaultNpcLootBlacklist2) )
			);


			this.ItemGroupBlacklist = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultItemGroupBlacklist) )
			);
			this.RecipeGroupBlacklist = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultRecipeGroupBlacklist) )
			);
			this.NpcGroupBlacklist = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultNpcGroupBlacklist) )
			);
			this.NpcLootGroupBlacklist = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultNpcLootGroupBlacklist) )
			);

			this.RecipeGroupWhitelist = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultRecipeGroupWhitelist) )
			);
			this.ItemGroupWhitelist = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultItemGroupWhitelist) )
			);
			this.NpcGroupWhitelist = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultNpcGroupWhitelist) )
			);
			this.NpcLootGroupWhitelist = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultNpcLootGroupWhitelist) )
			);

			this.ItemGroupBlacklist2 = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultItemGroupBlacklist2 ) )
			);
			this.RecipeGroupBlacklist2 = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultRecipeGroupBlacklist2 ) )
			);
			this.NpcGroupBlacklist2 = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultNpcGroupBlacklist2) )
			);
			this.NpcLootGroupBlacklist2 = new HashSet<string>(
				config.Get<HashSet<string>>( nameof(NihilismConfig.DefaultNpcLootGroupBlacklist2) )
			);
		}

		public void SetCurrentFiltersAsDefaults() {
			var config = NihilismConfig.Instance;

			config.SetOverride(
				nameof( NihilismConfig.DefaultItemBlacklist ),
				new HashSet<ItemDefinition>( this.ItemBlacklist )
			);  // Was there a reason these weren't cloned?
			config.SetOverride(
				nameof( NihilismConfig.DefaultRecipeBlacklist ),
				new HashSet<ItemDefinition>( this.RecipeBlacklist )
			);//
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcBlacklist ),
				new HashSet<NPCDefinition>( this.NpcBlacklist )
			);//
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcLootBlacklist ),
				new HashSet<NPCDefinition>( this.NpcLootBlacklist )
			);//

			config.SetOverride(
				nameof( NihilismConfig.DefaultRecipeWhitelist ),
				new HashSet<ItemDefinition>( this.RecipeWhitelist )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultItemWhitelist ),
				new HashSet<ItemDefinition>( this.ItemWhitelist )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcWhitelist ),
				new HashSet<NPCDefinition>( this.NpcWhitelist )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcLootWhitelist ),
				new HashSet<NPCDefinition>( this.NpcLootWhitelist )
			);

			config.SetOverride(
				nameof( NihilismConfig.DefaultItemBlacklist2 ),
				new HashSet<ItemDefinition>( this.ItemBlacklist2 )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultRecipeBlacklist2 ),
				new HashSet<ItemDefinition>( this.RecipeBlacklist2 )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcBlacklist2 ),
				new HashSet<NPCDefinition>( this.NpcBlacklist2 )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcLootBlacklist2 ),
				new HashSet<NPCDefinition>( this.NpcLootBlacklist2 )
			);


			config.SetOverride(
				nameof( NihilismConfig.DefaultItemGroupBlacklist ),
				new HashSet<string>( this.ItemGroupBlacklist )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultRecipeGroupBlacklist ),
				new HashSet<string>( this.RecipeGroupBlacklist )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcGroupBlacklist ),
				new HashSet<string>( this.NpcGroupBlacklist )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcLootGroupBlacklist ),
				new HashSet<string>( this.NpcLootGroupBlacklist )
			);

			config.SetOverride(
				nameof( NihilismConfig.DefaultRecipeGroupWhitelist ),
				new HashSet<string>( this.RecipeGroupWhitelist )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultItemGroupWhitelist ),
				new HashSet<string>( this.ItemGroupWhitelist )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcGroupWhitelist ),
				new HashSet<string>( this.NpcGroupWhitelist )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcLootGroupWhitelist ),
				new HashSet<string>( this.NpcLootGroupWhitelist )
			);

			config.SetOverride(
				nameof( NihilismConfig.DefaultItemGroupBlacklist2 ),
				new HashSet<string>( this.ItemGroupBlacklist2 )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultRecipeGroupBlacklist2 ),
				new HashSet<string>( this.RecipeGroupBlacklist2 )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultRecipeGroupBlacklist2 ),
				new HashSet<string>( this.RecipeGroupBlacklist2 )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcGroupBlacklist2 ),
				new HashSet<string>( this.NpcGroupBlacklist2 )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcGroupBlacklist2 ),
				new HashSet<string>( this.NpcGroupBlacklist2 )
			);
			config.SetOverride(
				nameof( NihilismConfig.DefaultNpcLootGroupBlacklist2 ),
				new HashSet<string>( this.NpcLootGroupBlacklist2 )
			);
		}
	}
}
