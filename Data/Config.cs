using HamstarHelpers.Services.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	public class NihilismConfig : StackableModConfig {
		public static NihilismConfig Instance {
			get {
				if( !NihilismMod.Instance.InstancedFilters ) {
					return ModConfigStack.GetMergedConfigs<NihilismConfig>();
				} else {
					return ModConfigStack.GetMergedStackedConfigs<NihilismConfig>();
				}
			}
		}

		////

		public override ConfigScope Mode => ConfigScope.ServerSide;



		////////////////

		[Header( "Chat commands (type /help in-game and scroll chat for more info):\n"+
			"  /nih-on, /nih-off: Enables or disables filters for the current world.\n"+
			"  /nih-defaults-reset: Sets the below \"default\" filters as those for the current world.\n"+
			"  /nih-defaults-set: Sets the current world's active filters to override the below defaults.\n"+
			"  /nih-clear: Clears all filters for the current world. Does not affect defaults below.\n" +
			"  /nih-show-filters: Outputs the current world's active filters to the client.log.\n " +
			"\nSee homepage for info on using the mod's API for more options.\n \n"+
		"Debug settings" )]
		[Label( "Output debug information to log or chat" )]
		public bool DebugModeInfo = false;
		[Label( "Output item debug information (e.g. applicable filters) to log or chat" )]
		public bool DebugModePerItemInfo = false;

		[Header( "Default blacklists" )]
		[Label( "Default blacklist of items" )]
		public HashSet<ItemDefinition> DefaultItemBlacklist = new HashSet<ItemDefinition> { };
		[Label( "Default blacklist of item recipes" )]
		public HashSet<ItemDefinition> DefaultRecipeBlacklist = new HashSet<ItemDefinition> { };
		[Label( "Default blacklist of NPCs" )]
		public HashSet<NPCDefinition> DefaultNpcBlacklist = new HashSet<NPCDefinition> { };
		[Label( "Default blacklist that can drop loot NPCs" )]
		public HashSet<NPCDefinition> DefaultNpcLootBlacklist = new HashSet<NPCDefinition> { };

		[Header( "Default whitelists (subtracts from blacklist)" )]
		[Label( "Default whitelist of items" )]
		public HashSet<ItemDefinition> DefaultItemWhitelist = new HashSet<ItemDefinition> { };
		[Label( "Default whitelist of item recipes" )]
		public HashSet<ItemDefinition> DefaultRecipeWhitelist = new HashSet<ItemDefinition> { };
		[Label( "Default whitelist of NPCs" )]
		public HashSet<NPCDefinition> DefaultNpcWhitelist = new HashSet<NPCDefinition> { };
		[Label( "Default whitelist of loot dropping of NPCs" )]
		public HashSet<NPCDefinition> DefaultNpcLootWhitelist = new HashSet<NPCDefinition> { };

		[Header( "Default secondary blacklists (subtracts from whitelist)" )]
		[Label( "Default secondary blacklist of items" )]
		public HashSet<ItemDefinition> DefaultItemBlacklist2 = new HashSet<ItemDefinition> { };
		[Label( "Default blacklist of item recipes" )]
		public HashSet<ItemDefinition> DefaultRecipeBlacklist2 = new HashSet<ItemDefinition> { };
		[Label( "Default blacklist of NPCs" )]
		public HashSet<NPCDefinition> DefaultNpcBlacklist2 = new HashSet<NPCDefinition> { };
		[Label( "Default blacklist of loot dropping of NPCs" )]
		public HashSet<NPCDefinition> DefaultNpcLootBlacklist2 = new HashSet<NPCDefinition> { };

		[Header( "Default groups blacklists (see Entity Groups via. Mod Helpers)" )]
		[Label( "Default blacklist of item groups" )]
		public HashSet<string> DefaultItemGroupBlacklist = new HashSet<string> { };
		[Label( "Default blacklist of item recipes as item groups" )]
		public HashSet<string> DefaultRecipeGroupBlacklist = new HashSet<string> { };
		[Label( "Default blacklist of NPC groups" )]
		public HashSet<string> DefaultNpcGroupBlacklist = new HashSet<string> { };
		[Label( "Default blacklist of loot dropping of NPCs" )]
		public HashSet<string> DefaultNpcLootGroupBlacklist = new HashSet<string> { };

		[Header( "Default groups whitelists (subtracts from blacklist)" )]
		[Label( "Default whitelist of items" )]
		public HashSet<string> DefaultItemGroupWhitelist = new HashSet<string> { };
		[Label( "Default whitelist of item recipes" )]
		public HashSet<string> DefaultRecipeGroupWhitelist = new HashSet<string> { };
		[Label( "Default whitelist of NPCs" )]
		public HashSet<string> DefaultNpcGroupWhitelist = new HashSet<string> { };
		[Label( "Default whitelist of loot dropping of NPCs" )]
		public HashSet<string> DefaultNpcLootGroupWhitelist = new HashSet<string> { };

		[Header( "Default groups secondary blacklists (subtracts from whitelist)" )]
		[Label( "Default secondary blacklist of items" )]
		public HashSet<string> DefaultItemGroupBlacklist2 = new HashSet<string> { };
		[Label( "Default blacklist of item recipes" )]
		public HashSet<string> DefaultRecipeGroupBlacklist2 = new HashSet<string> { };
		[Label( "Default blacklist of NPCs" )]
		public HashSet<string> DefaultNpcGroupBlacklist2 = new HashSet<string> { };
		[Label( "Default blacklist of loot dropping of NPCs" )]
		public HashSet<string> DefaultNpcLootGroupBlacklist2 = new HashSet<string> { };

		[Header( "Flags for categories of blacklists or whitelists (filters)" )]
		[Label( "Enable item filters" )]
		[DefaultValue(true)]
		public bool EnableItemFilters = true;
		[Label( "Enable item equips filters" )]
		[DefaultValue( true )]
		public bool EnableItemEquipsFilters = true;
		[Label( "Enable item recipes filters" )]
		[DefaultValue( true )]
		public bool EnableRecipeFilters = true;
		[Label( "Enable NPC filters" )]
		[DefaultValue( true )]
		public bool EnableNpcFilters = true;
		[Label( "Enable filters of NPCs' loot dropping" )]
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
