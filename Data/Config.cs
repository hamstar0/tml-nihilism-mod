using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	public class NihilismConfig : ModConfig {
		public override ConfigScope Mode => ConfigScope.ServerSide;


		////

		public bool DebugModeInfo = false;
		public bool DebugModePerItemInfo = false;

		public ISet<ItemDefinition> DefaultItemBlacklist = new HashSet<ItemDefinition> { };
		public ISet<ItemDefinition> DefaultRecipeBlacklist = new HashSet<ItemDefinition> { };
		public ISet<ItemDefinition> DefaultNpcBlacklist = new HashSet<ItemDefinition> { };
		public ISet<ItemDefinition> DefaultNpcLootBlacklist = new HashSet<ItemDefinition> { };

		public ISet<ItemDefinition> DefaultItemWhitelist = new HashSet<ItemDefinition> { };
		public ISet<ItemDefinition> DefaultRecipeWhitelist = new HashSet<ItemDefinition> { };
		public ISet<ItemDefinition> DefaultNpcWhitelist = new HashSet<ItemDefinition> { };
		public ISet<ItemDefinition> DefaultNpcLootWhitelist = new HashSet<ItemDefinition> { };

		public ISet<ItemDefinition> DefaultItemBlacklist2 = new HashSet<ItemDefinition> { };
		public ISet<ItemDefinition> DefaultRecipeBlacklist2 = new HashSet<ItemDefinition> { };
		public ISet<ItemDefinition> DefaultNpcBlacklist2 = new HashSet<ItemDefinition> { };
		public ISet<ItemDefinition> DefaultNpcLootBlacklist2 = new HashSet<ItemDefinition> { };

		public ISet<string> DefaultItemGroupBlacklist = new HashSet<string> { };
		public ISet<string> DefaultRecipeGroupBlacklist = new HashSet<string> { };
		public ISet<string> DefaultNpcGroupBlacklist = new HashSet<string> { };
		public ISet<string> DefaultNpcLootGroupBlacklist = new HashSet<string> { };

		public ISet<string> DefaultItemGroupWhitelist = new HashSet<string> { };
		public ISet<string> DefaultRecipeGroupWhitelist = new HashSet<string> { };
		public ISet<string> DefaultNpcGroupWhitelist = new HashSet<string> { };
		public ISet<string> DefaultNpcLootGroupWhitelist = new HashSet<string> { };

		public ISet<string> DefaultItemGroupBlacklist2 = new HashSet<string> { };
		public ISet<string> DefaultRecipeGroupBlacklist2 = new HashSet<string> { };
		public ISet<string> DefaultNpcGroupBlacklist2 = new HashSet<string> { };
		public ISet<string> DefaultNpcLootGroupBlacklist2 = new HashSet<string> { };

		[DefaultValue(true)]
		public bool EnableItemFilters = true;
		[DefaultValue( true )]
		public bool EnableItemEquipsFilters = true;
		[DefaultValue( true )]
		public bool EnableRecipeFilters = true;
		[DefaultValue( true )]
		public bool EnableNpcFilters = true;
		[DefaultValue( true )]
		public bool EnableNpcLootFilters = true;



		////////////////

		[OnDeserialized]
		internal void OnDeserializedMethod( StreamingContext context ) {
			if( this.DefaultItemBlacklist != null ) {
				return;
			}

			this.DefaultItemBlacklist = new HashSet<ItemDefinition>();
			this.DefaultRecipeBlacklist = new HashSet<ItemDefinition>();
			this.DefaultNpcBlacklist = new HashSet<ItemDefinition>();
			this.DefaultNpcLootBlacklist = new HashSet<ItemDefinition>();

			this.DefaultItemWhitelist = new HashSet<ItemDefinition>();
			this.DefaultRecipeWhitelist = new HashSet<ItemDefinition>();
			this.DefaultNpcWhitelist = new HashSet<ItemDefinition>();
			this.DefaultNpcLootWhitelist = new HashSet<ItemDefinition>();

			this.DefaultItemBlacklist2 = new HashSet<ItemDefinition>();
			this.DefaultRecipeBlacklist2 = new HashSet<ItemDefinition>();
			this.DefaultNpcBlacklist2 = new HashSet<ItemDefinition>();
			this.DefaultNpcLootBlacklist2 = new HashSet<ItemDefinition>();

			this.DefaultItemGroupBlacklist = new HashSet<string> { "Any Equipment" };
			this.DefaultRecipeGroupBlacklist = new HashSet<string> { "Any Equipment" };
			this.DefaultNpcGroupBlacklist = new HashSet<string> { "Any Hostile NPC" };
			this.DefaultNpcLootGroupBlacklist = new HashSet<string> { "Any Hostile NPC" };

			this.DefaultItemGroupWhitelist = new HashSet<string> { "Any Copper Or Tin Equipment" };
			this.DefaultRecipeGroupWhitelist = new HashSet<string> { "Any Copper Or Tin Equipment" };
			this.DefaultNpcGroupWhitelist = new HashSet<string> { "Any Slime" };
			this.DefaultNpcLootGroupWhitelist = new HashSet<string> { "Any Slime" };

			this.DefaultItemGroupBlacklist2 = new HashSet<string> { "Copper Shortsword" };
			this.DefaultRecipeGroupBlacklist2 = new HashSet<string> { };
			this.DefaultNpcGroupBlacklist2 = new HashSet<string> { };
			this.DefaultNpcLootGroupBlacklist2 = new HashSet<string> { };
		}
	}
}
