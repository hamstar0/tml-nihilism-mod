using System.Collections.Generic;
using System.Runtime.Serialization;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFilterConfig : ModConfig {
		public override ConfigScope Mode => ConfigScope.ServerSide;


		////

		public bool IsActive = false;

		public IList<ItemDefinition> ItemBlacklist = new List<ItemDefinition> { };
		public IList<ItemDefinition> RecipeBlacklist = new List<ItemDefinition> { };
		public IList<ItemDefinition> NpcBlacklist = new List<ItemDefinition> { };
		public IList<ItemDefinition> NpcLootBlacklist = new List<ItemDefinition> { };

		public IList<ItemDefinition> RecipeWhitelist = new List<ItemDefinition> { };
		public IList<ItemDefinition> ItemWhitelist = new List<ItemDefinition> { };
		public IList<ItemDefinition> NpcWhitelist = new List<ItemDefinition> { };
		public IList<ItemDefinition> NpcLootWhitelist = new List<ItemDefinition> { };

		public IList<ItemDefinition> ItemBlacklist2 = new List<ItemDefinition> { };
		public IList<ItemDefinition> RecipeBlacklist2 = new List<ItemDefinition> { };
		public IList<ItemDefinition> NpcBlacklist2 = new List<ItemDefinition> { };
		public IList<ItemDefinition> NpcLootBlacklist2 = new List<ItemDefinition> { };

		public ISet<string> ItemGroupBlacklist = new HashSet<string> { };
		public ISet<string> RecipeGroupBlacklist = new HashSet<string> { };
		public ISet<string> NpcGroupBlacklist = new HashSet<string> { };
		public ISet<string> NpcLootGroupBlacklist = new HashSet<string> { };

		public ISet<string> ItemGroupWhitelist = new HashSet<string> { };
		public ISet<string> RecipeGroupWhitelist = new HashSet<string> { };
		public ISet<string> NpcGroupWhitelist = new HashSet<string> { };
		public ISet<string> NpcLootGroupWhitelist = new HashSet<string> { };

		public ISet<string> ItemGroupBlacklist2 = new HashSet<string> { };
		public ISet<string> RecipeGroupBlacklist2 = new HashSet<string> { };
		public ISet<string> NpcGroupBlacklist2 = new HashSet<string> { };
		public ISet<string> NpcLootGroupBlacklist2 = new HashSet<string> { };



		////////////////

		[OnDeserialized]
		internal void OnDeserializedMethod( StreamingContext context ) {
			if( this.ItemBlacklist != null ) {
				return;
			}

			this.ResetFiltersFromDefaults();
		}


		////////////////

		internal void CopyFrom( NihilismFilterConfig copy ) {
			this.IsActive = copy.IsActive;
			this.ItemBlacklist = new List<ItemDefinition>( copy.ItemBlacklist );
			this.RecipeBlacklist = new List<ItemDefinition>( copy.RecipeBlacklist );
			this.NpcBlacklist = new List<ItemDefinition>( copy.NpcBlacklist );
			this.NpcLootBlacklist = new List<ItemDefinition>( copy.NpcLootBlacklist );
			this.RecipeWhitelist = new List<ItemDefinition>( copy.RecipeWhitelist );
			this.ItemWhitelist = new List<ItemDefinition>( copy.ItemWhitelist );
			this.NpcWhitelist = new List<ItemDefinition>( copy.NpcWhitelist );
			this.NpcLootWhitelist = new List<ItemDefinition>( copy.NpcLootWhitelist );
			this.ItemBlacklist2 = new List<ItemDefinition>( copy.ItemBlacklist2 );
			this.RecipeBlacklist2 = new List<ItemDefinition>( copy.RecipeBlacklist2 );
			this.NpcBlacklist2 = new List<ItemDefinition>( copy.NpcBlacklist2 );
			this.NpcLootBlacklist2 = new List<ItemDefinition>( copy.NpcLootBlacklist2 );

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

			this.ItemBlacklist = new List<ItemDefinition>( mymod.Config.DefaultItemBlacklist );  // Was there a reason these weren't cloned?
			this.RecipeBlacklist = new List<ItemDefinition>( mymod.Config.DefaultRecipeBlacklist );//
			this.NpcBlacklist = new List<ItemDefinition>( mymod.Config.DefaultNpcBlacklist );//
			this.NpcLootBlacklist = new List<ItemDefinition>( mymod.Config.DefaultNpcLootBlacklist );//

			this.RecipeWhitelist = new List<ItemDefinition>( mymod.Config.DefaultRecipeWhitelist );
			this.ItemWhitelist = new List<ItemDefinition>( mymod.Config.DefaultItemWhitelist );
			this.NpcWhitelist = new List<ItemDefinition>( mymod.Config.DefaultNpcWhitelist );
			this.NpcLootWhitelist = new List<ItemDefinition>( mymod.Config.DefaultNpcLootWhitelist );

			this.ItemBlacklist2 = new List<ItemDefinition>( mymod.Config.DefaultItemBlacklist2 );
			this.RecipeBlacklist2 = new List<ItemDefinition>( mymod.Config.DefaultRecipeBlacklist2 );
			this.NpcBlacklist2 = new List<ItemDefinition>( mymod.Config.DefaultNpcBlacklist2 );
			this.NpcLootBlacklist2 = new List<ItemDefinition>( mymod.Config.DefaultNpcLootBlacklist2 );


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
			mymod.Config.DefaultNpcBlacklist = new HashSet<ItemDefinition>( this.NpcBlacklist );//
			mymod.Config.DefaultNpcLootBlacklist = new HashSet<ItemDefinition>( this.NpcLootBlacklist );//

			mymod.Config.DefaultRecipeWhitelist = new HashSet<ItemDefinition>( this.RecipeWhitelist );
			mymod.Config.DefaultItemWhitelist = new HashSet<ItemDefinition>( this.ItemWhitelist );
			mymod.Config.DefaultNpcWhitelist = new HashSet<ItemDefinition>( this.NpcWhitelist );
			mymod.Config.DefaultNpcLootWhitelist = new HashSet<ItemDefinition>( this.NpcLootWhitelist );

			mymod.Config.DefaultItemBlacklist2 = new HashSet<ItemDefinition>( this.ItemBlacklist2 );
			mymod.Config.DefaultRecipeBlacklist2 = new HashSet<ItemDefinition>( this.RecipeBlacklist2 );
			mymod.Config.DefaultNpcBlacklist2 = new HashSet<ItemDefinition>( this.NpcBlacklist2 );
			mymod.Config.DefaultNpcLootBlacklist2 = new HashSet<ItemDefinition>( this.NpcLootBlacklist2 );


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
