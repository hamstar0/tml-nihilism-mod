using HamstarHelpers.Components.Config;
using System;
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

		[Obsolete( "Not a useable setting", true )]
		public string _OLD_SETTINGS_BELOW_ = "";

		[Obsolete( "Use NihilismFilterData.ItemBlacklist", true )]
		public string ItemsBlacklistPattern;
		[Obsolete( "Use NihilismFilterData.RecipeBlacklist", true )]
		public string RecipesBlacklistPattern;
		[Obsolete( "Use NihilismFilterData.NpcBlacklist", true )]
		public string NpcBlacklistPattern;
		[Obsolete( "Use NihilismFilterData.NpcLootBlacklist", true )]
		public string NpcLootBlacklistPattern;
		[Obsolete( "Use NihilismFilterData.ItemBlacklist", true )]
		public bool IsRecipeFilterOn;
		[Obsolete( "Use NihilismFilterData.RecipeBlacklist", true )]
		public bool IsItemFilterOn;
		[Obsolete( "Use NihilismFilterData.NpcBlacklist", true )]
		public bool IsNpcFilterOn;
		[Obsolete( "Use NihilismFilterData.NpcLootBlacklist", true )]
		public bool IsNpcLootFilterOn;



		////////////////

		public NihilismFilterData() {
			this.ResetFiltersFromDefaults( NihilismMod.Instance );
		}


		////////////////
		
		public void SetCurrentFiltersAsDefaults( NihilismMod mymod ) {
			mymod.ServerConfig.DefaultItemBlacklist = this.ItemBlacklist;
			mymod.ServerConfig.DefaultRecipeBlacklist = this.RecipeBlacklist;
			mymod.ServerConfig.DefaultNpcBlacklist = this.NpcBlacklist;
			mymod.ServerConfig.DefaultNpcLootBlacklist = this.NpcLootBlacklist;

			mymod.ServerConfig.DefaultRecipeWhitelist = new HashSet<string>( this.RecipeWhitelist );
			mymod.ServerConfig.DefaultItemWhitelist = new HashSet<string>( this.ItemWhitelist );
			mymod.ServerConfig.DefaultNpcWhitelist = new HashSet<string>( this.NpcWhitelist );
			mymod.ServerConfig.DefaultNpcLootWhitelist = new HashSet<string>( this.NpcLootWhitelist );

			if( !mymod.SuppressAutoSaving ) {
				mymod.ConfigJson.SaveFile();
			}
		}

		public void ResetFiltersFromDefaults( NihilismMod mymod ) {
			this.ItemBlacklist = mymod.ServerConfig.DefaultItemBlacklist;
			this.RecipeBlacklist = mymod.ServerConfig.DefaultRecipeBlacklist;
			this.NpcBlacklist = mymod.ServerConfig.DefaultNpcBlacklist;
			this.NpcLootBlacklist = mymod.ServerConfig.DefaultNpcLootBlacklist;

			this.RecipeWhitelist = new HashSet<string>( mymod.ServerConfig.DefaultRecipeWhitelist );
			this.ItemWhitelist = new HashSet<string>( mymod.ServerConfig.DefaultItemWhitelist );
			this.NpcWhitelist = new HashSet<string>( mymod.ServerConfig.DefaultNpcWhitelist );
			this.NpcLootWhitelist = new HashSet<string>( mymod.ServerConfig.DefaultNpcLootWhitelist );
		}
	}
}
