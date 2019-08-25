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

		public HashSet<ItemDefinition> DefaultItemBlacklist = new HashSet<ItemDefinition> { };
		public HashSet<ItemDefinition> DefaultRecipeBlacklist = new HashSet<ItemDefinition> { };
		public HashSet<NPCDefinition> DefaultNpcBlacklist = new HashSet<NPCDefinition> { };
		public HashSet<NPCDefinition> DefaultNpcLootBlacklist = new HashSet<NPCDefinition> { };

		public HashSet<ItemDefinition> DefaultItemWhitelist = new HashSet<ItemDefinition> { };
		public HashSet<ItemDefinition> DefaultRecipeWhitelist = new HashSet<ItemDefinition> { };
		public HashSet<NPCDefinition> DefaultNpcWhitelist = new HashSet<NPCDefinition> { };
		public HashSet<NPCDefinition> DefaultNpcLootWhitelist = new HashSet<NPCDefinition> { };

		public HashSet<ItemDefinition> DefaultItemBlacklist2 = new HashSet<ItemDefinition> { };
		public HashSet<ItemDefinition> DefaultRecipeBlacklist2 = new HashSet<ItemDefinition> { };
		public HashSet<NPCDefinition> DefaultNpcBlacklist2 = new HashSet<NPCDefinition> { };
		public HashSet<NPCDefinition> DefaultNpcLootBlacklist2 = new HashSet<NPCDefinition> { };

		public HashSet<string> DefaultItemGroupBlacklist = new HashSet<string> { };
		public HashSet<string> DefaultRecipeGroupBlacklist = new HashSet<string> { };
		public HashSet<string> DefaultNpcGroupBlacklist = new HashSet<string> { };
		public HashSet<string> DefaultNpcLootGroupBlacklist = new HashSet<string> { };

		public HashSet<string> DefaultItemGroupWhitelist = new HashSet<string> { };
		public HashSet<string> DefaultRecipeGroupWhitelist = new HashSet<string> { };
		public HashSet<string> DefaultNpcGroupWhitelist = new HashSet<string> { };
		public HashSet<string> DefaultNpcLootGroupWhitelist = new HashSet<string> { };

		public HashSet<string> DefaultItemGroupBlacklist2 = new HashSet<string> { };
		public HashSet<string> DefaultRecipeGroupBlacklist2 = new HashSet<string> { };
		public HashSet<string> DefaultNpcGroupBlacklist2 = new HashSet<string> { };
		public HashSet<string> DefaultNpcLootGroupBlacklist2 = new HashSet<string> { };

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
			this.DefaultNpcBlacklist = new HashSet<NPCDefinition>();
			this.DefaultNpcLootBlacklist = new HashSet<NPCDefinition>();

			this.DefaultItemWhitelist = new HashSet<ItemDefinition>();
			this.DefaultRecipeWhitelist = new HashSet<ItemDefinition>();
			this.DefaultNpcWhitelist = new HashSet<NPCDefinition>();
			this.DefaultNpcLootWhitelist = new HashSet<NPCDefinition>();

			this.DefaultItemBlacklist2 = new HashSet<ItemDefinition>();
			this.DefaultRecipeBlacklist2 = new HashSet<ItemDefinition>();
			this.DefaultNpcBlacklist2 = new HashSet<NPCDefinition>();
			this.DefaultNpcLootBlacklist2 = new HashSet<NPCDefinition>();

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
