using System.Collections.Generic;


namespace Nihilism.Data {
	public class NihilismFilterData {
		public bool IsActive = false;

		public bool RecipesBlacklistChecksFirst = false;
		public bool ItemsBlacklistChecksFirst = false;
		public bool NpcsBlacklistChecksFirst = false;
		public bool NpcLootBlacklistChecksFirst = false;

		public string RecipesBlacklistPattern = "(.*?)";
		public string ItemsBlacklistPattern = "(.*?)";
		public string NpcBlacklistPattern = "(.*?)";
		public string NpcLootBlacklistPattern = "(.*?)";

		public IDictionary<string, bool> RecipeWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> ItemWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> NpcWhitelist = new Dictionary<string, bool> { };
		public IDictionary<string, bool> NpcLootWhitelist = new Dictionary<string, bool> { };



		////////////////

		public void SetDefaults() {
			this.RecipeWhitelist["Copper Pickaxe"] = true;
			this.ItemWhitelist["Copper Pickaxe"] = true;
			this.NpcWhitelist["Green Slime"] = true;
			this.NpcLootWhitelist["Green Slime"] = true;
		}
	}
}
