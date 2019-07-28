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

		public ISet<string> DefaultItemBlacklist = new HashSet<string> { };
		public ISet<string> DefaultRecipeBlacklist = new HashSet<string> { };
		public ISet<string> DefaultNpcBlacklist = new HashSet<string> { };
		public ISet<string> DefaultNpcLootBlacklist = new HashSet<string> { };

		public ISet<string> DefaultItemWhitelist = new HashSet<string> { };
		public ISet<string> DefaultRecipeWhitelist = new HashSet<string> { };
		public ISet<string> DefaultNpcWhitelist = new HashSet<string> { };
		public ISet<string> DefaultNpcLootWhitelist = new HashSet<string> { };

		public ISet<string> DefaultItemBlacklist2 = new HashSet<string> { };
		public ISet<string> DefaultRecipeBlacklist2 = new HashSet<string> { };
		public ISet<string> DefaultNpcBlacklist2 = new HashSet<string> { };
		public ISet<string> DefaultNpcLootBlacklist2 = new HashSet<string> { };

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

			this.DefaultItemBlacklist = new HashSet<string> { "Any Equipment" };
			this.DefaultRecipeBlacklist = new HashSet<string> { "Any Equipment" };
			this.DefaultNpcBlacklist = new HashSet<string> { "Any Hostile NPC" };
			this.DefaultNpcLootBlacklist = new HashSet<string> { "Any Hostile NPC" };

			this.DefaultItemWhitelist = new HashSet<string> { "Any Copper Or Tin Equipment" };
			this.DefaultRecipeWhitelist = new HashSet<string> { "Any Copper Or Tin Equipment" };
			this.DefaultNpcWhitelist = new HashSet<string> { "Any Slime" };
			this.DefaultNpcLootWhitelist = new HashSet<string> { "Any Slime" };

			this.DefaultItemBlacklist2 = new HashSet<string> { "Copper Shortsword" };
			this.DefaultRecipeBlacklist2 = new HashSet<string> { };
			this.DefaultNpcBlacklist2 = new HashSet<string> { };
			this.DefaultNpcLootBlacklist2 = new HashSet<string> { };
		}
	}
}
