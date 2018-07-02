using HamstarHelpers.Components.Config;
using System;
using System.Collections.Generic;


namespace Nihilism.Data {
	public class NihilismConfigData : ConfigurationDataBase {
		public readonly static Version ConfigVersion = new Version( 2, 1, 2, 1 );
		public readonly static string ConfigFileName = "Nihilism Config.json";


		////////////////

		public string VersionSinceUpdate = NihilismConfigData.ConfigVersion.ToString();

		public bool DebugModeInfo = false;

		public ISet<string> DefaultItemBlacklist = new HashSet<string> { };
		public ISet<string> DefaultRecipeBlacklist = new HashSet<string> { };
		public ISet<string> DefaultNpcBlacklist = new HashSet<string> { };
		public ISet<string> DefaultNpcLootBlacklist = new HashSet<string> { };

		public ISet<string> DefaultItemWhitelist = new HashSet<string> { };
		public ISet<string> DefaultRecipeWhitelist = new HashSet<string> { };
		public ISet<string> DefaultNpcWhitelist = new HashSet<string> { };
		public ISet<string> DefaultNpcLootWhitelist = new HashSet<string> { };

		public bool EnableItemFilters = true;
		public bool EnableItemEquipsFilters = true;
		public bool EnableRecipeFilters = true;
		public bool EnableNpcFilters = true;
		public bool EnableNpcLootFilters = true;


		////////

		[Obsolete( "Not a useable setting", true )]
		public string _OLD_SETTINGS_BELOW_ = "";

		[Obsolete( "Use NihilismConfigData.DefaultRecipesBlacklisted", true )]
		public string DefaultRecipesBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultItemsBlacklisted", true )]
		public string DefaultItemsBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultNpcBlacklisted", true )]
		public string DefaultNpcBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultNpcLootBlacklisted", true )]
		public string DefaultNpcLootBlacklistPattern = "(.*?)";

		[Obsolete( "Use NihilismFilterData.RecipesBlacklistChecksFirst", true )]
		public bool RecipesBlacklistChecksFirst = false;
		[Obsolete( "Use NihilismFilterData.ItemsBlacklistChecksFirst", true )]
		public bool ItemsBlacklistChecksFirst = false;
		[Obsolete( "Use NihilismFilterData.NpcsBlacklistChecksFirst", true )]
		public bool NpcsBlacklistChecksFirst = false;
		[Obsolete( "Use NihilismFilterData.NpcItemDropsBlacklistChecksFirst", true )]
		public bool NpcItemDropsBlacklistChecksFirst = false;

		[Obsolete( "Use NihilismConfigData.DefaultItemWhitelist or NihilismFilterData.DefaultItemBlacklist", true )]
		public string ItemsBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultRecipeWhitelist or NihilismFilterData.DefaultRecipeBlacklist", true )]
		public string RecipesBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultNpcWhitelist or NihilismFilterData.DefaultNpcBlacklist", true )]
		public string NpcsBlacklistPattern = "(.*?)";
		[Obsolete( "Use NihilismConfigData.DefaultNpcLootWhitelist or NihilismFilterData.DefaultNpcLootBlacklist", true )]
		public string NpcItemDropsBlacklistPattern = "(.*?)";
		
		[Obsolete( "Use NihilismConfigData.DefaultRecipeWhitelist or NihilismFilterData.DefaultItemBlacklist", true )]
		public bool DefaultItemsBlacklisted = true;
		[Obsolete( "Use NihilismConfigData.DefaultRecipeWhitelist or NihilismFilterData.DefaultRecipeBlacklist", true )]
		public bool DefaultRecipesBlacklisted = true;
		[Obsolete( "Use NihilismConfigData.DefaultRecipeWhitelist or NihilismFilterData.DefaultNpcBlacklist", true )]
		public bool DefaultNpcBlacklisted = true;
		[Obsolete( "Use NihilismConfigData.DefaultRecipeWhitelist or NihilismFilterData.DefaultNpcLootBlacklist", true )]
		public bool DefaultNpcLootBlacklisted = true;

		[Obsolete( "Use NihilismConfigData.DefaultRecipeWhitelist or NihilismFilterData.RecipeWhitelist", true )]
		public IDictionary<string, bool> RecipeWhitelist = new Dictionary<string, bool> { };
		[Obsolete( "Use NihilismConfigData.DefaultItemWhitelist or NihilismFilterData.ItemWhitelist", true )]
		public IDictionary<string, bool> ItemWhitelist = new Dictionary<string, bool> { };
		[Obsolete( "Use NihilismConfigData.DefaultNpcWhitelist or NihilismFilterData.NpcWhitelist", true )]
		public IDictionary<string, bool> NpcWhitelist = new Dictionary<string, bool> { };
		[Obsolete( "Use NihilismConfigData.DefaultNpcItemDropWhitelist or NihilismFilterData.NpcItemDropWhitelist", true )]
		public IDictionary<string, bool> NpcItemDropWhitelist = new Dictionary<string, bool> { };


		////////////////

		public override void OnLoad( bool success ) {
			if( !success ) {
				this.SetDefaults();
			}
		}

		
		public void SetDefaults() {
			this.DefaultItemBlacklist.Add( "Any Equipment" );
			this.DefaultRecipeBlacklist.Add( "Any Equipment" );
			this.DefaultNpcBlacklist.Add( "Any Hostile NPC" );
			this.DefaultNpcLootBlacklist.Add( "Any Hostile NPC" );

			this.DefaultItemWhitelist.Add( "Any Copper Or Tin Equipment" );
			this.DefaultRecipeWhitelist.Add( "Any Copper Or Tin Equipment" );
			this.DefaultNpcWhitelist.Add( "Any Slime" );
			this.DefaultNpcLootWhitelist.Add( "Blue Slime" );
		}


		public bool UpdateToLatestVersion() {
			var new_config = new NihilismConfigData();
			var vers_since = this.VersionSinceUpdate != "" ?
				new Version( this.VersionSinceUpdate ) :
				new Version();

			if( vers_since >= NihilismConfigData.ConfigVersion ) {
				return false;
			}
			
			if( vers_since < new Version(2, 1, 2, 2) ) {
				if( this.DefaultItemBlacklist.Count == 1 &&
						this.DefaultRecipeBlacklist.Count == 1 &&
						this.DefaultNpcBlacklist.Count == 1 &&
						this.DefaultNpcLootBlacklist.Count == 1 &&
						this.DefaultItemWhitelist.Count == 1 &&
						this.DefaultRecipeWhitelist.Count == 1 &&
						this.DefaultNpcWhitelist.Count == 1 &&
						this.DefaultNpcLootWhitelist.Count == 1 ) {
					this.DefaultItemBlacklist.Clear();
					this.DefaultRecipeBlacklist.Clear();
					this.DefaultNpcBlacklist.Clear();
					this.DefaultNpcLootBlacklist.Clear();

					this.DefaultItemWhitelist.Clear();
					this.DefaultRecipeWhitelist.Clear();
					this.DefaultNpcWhitelist.Clear();
					this.DefaultNpcLootWhitelist.Clear();

					this.SetDefaults();
				}
			}

			this.VersionSinceUpdate = NihilismConfigData.ConfigVersion.ToString();

			return true;
		}
	}
}
