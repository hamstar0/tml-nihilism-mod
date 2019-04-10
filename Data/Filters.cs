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

		public ISet<string> ItemBlacklist2 = new HashSet<string> { };
		public ISet<string> RecipeBlacklist2 = new HashSet<string> { };
		public ISet<string> NpcBlacklist2 = new HashSet<string> { };
		public ISet<string> NpcLootBlacklist2 = new HashSet<string> { };



		////////////////

		public NihilismFilterData() {
			this.ResetFiltersFromDefaults();
		}


		////////////////
		
		public void SetCurrentFiltersAsDefaults() {
			var mymod = NihilismMod.Instance;
			mymod.Config.DefaultItemBlacklist = new HashSet<string>( this.ItemBlacklist );	// Was there a reason these weren't cloned?
			mymod.Config.DefaultRecipeBlacklist = new HashSet<string>( this.RecipeBlacklist );//
			mymod.Config.DefaultNpcBlacklist = new HashSet<string>( this.NpcBlacklist );//
			mymod.Config.DefaultNpcLootBlacklist = new HashSet<string>( this.NpcLootBlacklist );//

			mymod.Config.DefaultRecipeWhitelist = new HashSet<string>( this.RecipeWhitelist );
			mymod.Config.DefaultItemWhitelist = new HashSet<string>( this.ItemWhitelist );
			mymod.Config.DefaultNpcWhitelist = new HashSet<string>( this.NpcWhitelist );
			mymod.Config.DefaultNpcLootWhitelist = new HashSet<string>( this.NpcLootWhitelist );

			mymod.Config.DefaultItemBlacklist2 = new HashSet<string>( this.ItemBlacklist2 );
			mymod.Config.DefaultRecipeBlacklist2 = new HashSet<string>( this.RecipeBlacklist2 );
			mymod.Config.DefaultNpcBlacklist2 = new HashSet<string>( this.NpcBlacklist2 );
			mymod.Config.DefaultNpcLootBlacklist2 = new HashSet<string>( this.NpcLootBlacklist2 );

			if( !mymod.SuppressAutoSaving ) {
				mymod.ConfigJson.SaveFile();
			}
		}

		public void ResetFiltersFromDefaults() {
			var mymod = NihilismMod.Instance;
			this.ItemBlacklist = new HashSet<string>( mymod.Config.DefaultItemBlacklist );  // Was there a reason these weren't cloned?
			this.RecipeBlacklist = new HashSet<string>( mymod.Config.DefaultRecipeBlacklist );//
			this.NpcBlacklist = new HashSet<string>( mymod.Config.DefaultNpcBlacklist );//
			this.NpcLootBlacklist = new HashSet<string>( mymod.Config.DefaultNpcLootBlacklist );//

			this.RecipeWhitelist = new HashSet<string>( mymod.Config.DefaultRecipeWhitelist );
			this.ItemWhitelist = new HashSet<string>( mymod.Config.DefaultItemWhitelist );
			this.NpcWhitelist = new HashSet<string>( mymod.Config.DefaultNpcWhitelist );
			this.NpcLootWhitelist = new HashSet<string>( mymod.Config.DefaultNpcLootWhitelist );

			this.ItemBlacklist2 = new HashSet<string>( mymod.Config.DefaultItemBlacklist2 );
			this.RecipeBlacklist2 = new HashSet<string>( mymod.Config.DefaultRecipeBlacklist2 );
			this.NpcBlacklist2 = new HashSet<string>( mymod.Config.DefaultNpcBlacklist2 );
			this.NpcLootBlacklist2 = new HashSet<string>( mymod.Config.DefaultNpcLootBlacklist2 );
		}
	}
}
