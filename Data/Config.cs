using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		public NihilismConfig() {
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

		public override ModConfig Clone() {
			var clone = (NihilismConfig)base.Clone();

			clone.DefaultItemBlacklist = new HashSet<ItemDefinition>( this.DefaultItemBlacklist );
			clone.DefaultRecipeBlacklist = new HashSet<ItemDefinition>( this.DefaultRecipeBlacklist );
			clone.DefaultNpcBlacklist = new HashSet<NPCDefinition>( this.DefaultNpcBlacklist );
			clone.DefaultNpcLootBlacklist = new HashSet<NPCDefinition>( this.DefaultNpcLootBlacklist );

			clone.DefaultItemWhitelist = new HashSet<ItemDefinition>( this.DefaultItemWhitelist );
			clone.DefaultRecipeWhitelist = new HashSet<ItemDefinition>( this.DefaultRecipeWhitelist );
			clone.DefaultNpcWhitelist = new HashSet<NPCDefinition>( this.DefaultNpcWhitelist );
			clone.DefaultNpcLootWhitelist = new HashSet<NPCDefinition>( this.DefaultNpcLootWhitelist );

			clone.DefaultItemBlacklist2 = new HashSet<ItemDefinition>( this.DefaultItemBlacklist2 );
			clone.DefaultRecipeBlacklist2 = new HashSet<ItemDefinition>( this.DefaultRecipeBlacklist2 );
			clone.DefaultNpcBlacklist2 = new HashSet<NPCDefinition>( this.DefaultNpcBlacklist2 );
			clone.DefaultNpcLootBlacklist2 = new HashSet<NPCDefinition>( this.DefaultNpcLootBlacklist2 );

			clone.DefaultItemGroupBlacklist = new HashSet<string>( this.DefaultItemGroupBlacklist );
			clone.DefaultRecipeGroupBlacklist = new HashSet<string>( this.DefaultRecipeGroupBlacklist );
			clone.DefaultNpcGroupBlacklist = new HashSet<string>( this.DefaultNpcGroupBlacklist );
			clone.DefaultNpcLootGroupBlacklist = new HashSet<string>( this.DefaultNpcLootGroupBlacklist );

			clone.DefaultItemGroupWhitelist = new HashSet<string>( this.DefaultItemGroupWhitelist );
			clone.DefaultRecipeGroupWhitelist = new HashSet<string>( this.DefaultRecipeGroupWhitelist );
			clone.DefaultNpcGroupWhitelist = new HashSet<string>( this.DefaultNpcGroupWhitelist );
			clone.DefaultNpcLootGroupWhitelist = new HashSet<string>( this.DefaultNpcLootGroupWhitelist );

			clone.DefaultItemGroupBlacklist2 = new HashSet<string>( this.DefaultItemGroupBlacklist2 );
			clone.DefaultRecipeGroupBlacklist2 = new HashSet<string>( this.DefaultRecipeGroupBlacklist2 );
			clone.DefaultNpcGroupBlacklist2 = new HashSet<string>( this.DefaultNpcGroupBlacklist2 );
			clone.DefaultNpcLootGroupBlacklist2 = new HashSet<string>( this.DefaultNpcLootGroupBlacklist2 );

			return clone;
		}
	}
}
