using HamstarHelpers.Components.Config;
using System.Collections.Generic;


namespace Nihilism.Data {
	class NihilismFilterData : ConfigurationDataBase {
		public bool IsActive = false;

		public ISet<string> ItemBlacklist = new HashSet<string> { };
		public ISet<string> RecipeBlacklist = new HashSet<string> { };
		public ISet<string> NpcBlacklist = new HashSet<string> { };
		public ISet<string> NpcLootBlacklist = new HashSet<string> { };

		public ISet<string> RecipeWhitelist = new HashSet<string> { };
		public ISet<string> ItemWhitelist = new HashSet<string> { };
		public ISet<string> NpcWhitelist = new HashSet<string> { };
		public ISet<string> NpcLootWhitelist = new HashSet<string> { };



		////////////////

		public NihilismFilterData() {
			this.ResetFiltersFromDefaults( NihilismMod.Instance );
		}


		////////////////
		
		public void SetCurrentFiltersAsDefaults( NihilismMod mymod ) {
			mymod.Config.DefaultItemBlacklist = this.ItemBlacklist;
			mymod.Config.DefaultRecipeBlacklist = this.RecipeBlacklist;
			mymod.Config.DefaultNpcBlacklist = this.NpcBlacklist;
			mymod.Config.DefaultNpcLootBlacklist = this.NpcLootBlacklist;

			mymod.Config.DefaultRecipeWhitelist = new HashSet<string>( this.RecipeWhitelist );
			mymod.Config.DefaultItemWhitelist = new HashSet<string>( this.ItemWhitelist );
			mymod.Config.DefaultNpcWhitelist = new HashSet<string>( this.NpcWhitelist );
			mymod.Config.DefaultNpcLootWhitelist = new HashSet<string>( this.NpcLootWhitelist );

			if( !mymod.SuppressAutoSaving ) {
				mymod.ConfigJson.SaveFile();
			}
		}

		public void ResetFiltersFromDefaults( NihilismMod mymod ) {
			this.ItemBlacklist = mymod.Config.DefaultItemBlacklist;
			this.RecipeBlacklist = mymod.Config.DefaultRecipeBlacklist;
			this.NpcBlacklist = mymod.Config.DefaultNpcBlacklist;
			this.NpcLootBlacklist = mymod.Config.DefaultNpcLootBlacklist;

			this.RecipeWhitelist = new HashSet<string>( mymod.Config.DefaultRecipeWhitelist );
			this.ItemWhitelist = new HashSet<string>( mymod.Config.DefaultItemWhitelist );
			this.NpcWhitelist = new HashSet<string>( mymod.Config.DefaultNpcWhitelist );
			this.NpcLootWhitelist = new HashSet<string>( mymod.Config.DefaultNpcLootWhitelist );
		}
	}
}
