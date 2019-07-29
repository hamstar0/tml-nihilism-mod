using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader.Config;


namespace Nihilism.Data {
	partial class NihilismFilterConfig : ModConfig {
		[JsonIgnore]
		private IDictionary<string, int> _ItemBlacklistMapping;
		[JsonIgnore]
		private IDictionary<string, int> _RecipeBlacklistMapping;
		[JsonIgnore]
		private IDictionary<string, int> _NpcBlacklistMapping;
		[JsonIgnore]
		private IDictionary<string, int> _NpcLootBlacklistMapping;

		[JsonIgnore]
		private IDictionary<string, int> _RecipeWhitelistMapping;
		[JsonIgnore]
		private IDictionary<string, int> _ItemWhitelistMapping;
		[JsonIgnore]
		private IDictionary<string, int> _NpcWhitelistMapping;
		[JsonIgnore]
		private IDictionary<string, int> _NpcLootWhitelistMapping;

		[JsonIgnore]
		private IDictionary<string, int> _ItemBlacklist2Mapping;
		[JsonIgnore]
		private IDictionary<string, int> _RecipeBlacklist2Mapping;
		[JsonIgnore]
		private IDictionary<string, int> _NpcBlacklist2Mapping;
		[JsonIgnore]
		private IDictionary<string, int> _NpcLootBlacklist2Mapping;

		////////////////

		[JsonIgnore]
		private IDictionary<string, int> _ItemBlacklistIdxs;
		[JsonIgnore]
		private IDictionary<string, int> _RecipeBlacklistIdxs;
		[JsonIgnore]
		private IDictionary<string, int> _NpcBlacklistIdxs;
		[JsonIgnore]
		private IDictionary<string, int> _NpcLootBlacklistIdxs;

		[JsonIgnore]
		private IDictionary<string, int> _RecipeWhitelistIdxs;
		[JsonIgnore]
		private IDictionary<string, int> _ItemWhitelistIdxs;
		[JsonIgnore]
		private IDictionary<string, int> _NpcWhitelistIdxs;
		[JsonIgnore]
		private IDictionary<string, int> _NpcLootWhitelistIdxs;

		[JsonIgnore]
		private IDictionary<string, int> _ItemBlacklist2Idxs;
		[JsonIgnore]
		private IDictionary<string, int> _RecipeBlacklist2Idxs;
		[JsonIgnore]
		private IDictionary<string, int> _NpcBlacklist2Idxs;
		[JsonIgnore]
		private IDictionary<string, int> _NpcLootBlacklist2Idxs;


		////////////////

		[JsonIgnore]
		public IDictionary<string, int> ItemBlacklistMapping {
			get {
				if( this._ItemBlacklistMapping == null || this._ItemBlacklistMapping.Count != this.ItemBlacklist.Count ) {
					this._ItemBlacklistIdxs = new Dictionary<string, int>();

					int i = 0;
					this._ItemBlacklistMapping = this.ItemBlacklist.ToDictionary(
						itemDef => {
							string key = itemDef.ToString();
							this._ItemBlacklistIdxs[ key ] = i++;
							return key;
						},
						itemDef => {
							return itemDef.GetID();
						}
					);
				}
				return this._ItemBlacklistMapping;
			}
		}

		[JsonIgnore]
		public IDictionary<string, int> RecipeBlacklistMapping {
			get {
				if( this._RecipeBlacklistMapping == null || this._RecipeBlacklistMapping.Count != this.ItemBlacklist.Count ) {
					this._RecipeBlacklistIdxs = new Dictionary<string, int>();

					int i = 0;
					this._RecipeBlacklistMapping = this.RecipeBlacklist.ToDictionary(
						itemDef => {
							string key = itemDef.ToString();
							this._RecipeBlacklistIdxs[key] = i++;
							return key;
						},
						itemDef => {
							return itemDef.GetID();
						}
					);
				}
				return this._RecipeBlacklistMapping;
			}
		}

		[JsonIgnore]
		public IDictionary<string, int> NpcBlacklistMapping {
			get {
				if( this._NpcBlacklistMapping == null || this._NpcBlacklistMapping.Count != this.ItemBlacklist.Count ) {
					this._NpcBlacklistIdxs = new Dictionary<string, int>();

					int i = 0;
					this._NpcBlacklistMapping = this.NpcBlacklist.ToDictionary(
						npcDef => {
							string key = npcDef.ToString();
							this._NpcBlacklistIdxs[key] = i++;
							return key;
						},
						npcDef => {
							return npcDef.GetID();
						}
					);
				}
				return this._NpcBlacklistMapping;
			}
		}

		[JsonIgnore]
		public IDictionary<string, int> NpcLootBlacklistMapping {
			get {
				if( this._NpcLootBlacklistMapping == null || this._NpcLootBlacklistMapping.Count != this.ItemBlacklist.Count ) {
					this._NpcLootBlacklistIdxs = new Dictionary<string, int>();

					int i = 0;
					this._NpcLootBlacklistMapping = this.NpcLootBlacklist.ToDictionary(
						npcDef => {
							string key = npcDef.ToString();
							this._NpcLootBlacklistIdxs[key] = i++;
							return key;
						},
						npcDef => {
							return npcDef.GetID();
						}
					);
				}
				return this._NpcLootBlacklistMapping;
			}
		}

		////

		[JsonIgnore]
		public IDictionary<string, int> ItemWhitelistMapping {
			get {
				if( this._ItemWhitelistMapping == null || this._ItemWhitelistMapping.Count != this.ItemBlacklist.Count ) {
					this._ItemWhitelistIdxs = new Dictionary<string, int>();

					int i = 0;
					this._ItemWhitelistMapping = this.ItemWhitelist.ToDictionary(
						itemDef => {
							string key = itemDef.ToString();
							this._ItemWhitelistIdxs[key] = i++;
							return key;
						},
						itemDef => {
							return itemDef.GetID();
						}
					);
				}
				return this._ItemWhitelistMapping;
			}
		}

		[JsonIgnore]
		public IDictionary<string, int> RecipeWhitelistMapping {
			get {
				if( this._RecipeWhitelistMapping == null || this._RecipeWhitelistMapping.Count != this.ItemBlacklist.Count ) {
					this._RecipeWhitelistIdxs = new Dictionary<string, int>();

					int i = 0;
					this._RecipeWhitelistMapping = this.RecipeWhitelist.ToDictionary(
						itemDef => {
							string key = itemDef.ToString();
							this._RecipeWhitelistIdxs[key] = i++;
							return key;
						},
						itemDef => {
							return itemDef.GetID();
						}
					);
				}
				return this._RecipeWhitelistMapping;
			}
		}

		[JsonIgnore]
		public IDictionary<string, int> NpcWhitelistMapping {
			get {
				if( this._NpcWhitelistMapping == null || this._NpcWhitelistMapping.Count != this.ItemBlacklist.Count ) {
					this._NpcWhitelistIdxs = new Dictionary<string, int>();

					int i = 0;
					this._NpcWhitelistMapping = this.NpcWhitelist.ToDictionary(
						npcDef => {
							string key = npcDef.ToString();
							this._NpcWhitelistIdxs[key] = i++;
							return key;
						},
						npcDef => {
							return npcDef.GetID();
						}
					);
				}
				return this._NpcWhitelistMapping;
			}
		}

		[JsonIgnore]
		public IDictionary<string, int> NpcLootWhitelistMapping {
			get {
				if( this._NpcLootWhitelistMapping == null || this._NpcLootWhitelistMapping.Count != this.ItemBlacklist.Count ) {
					this._NpcLootWhitelistIdxs = new Dictionary<string, int>();

					int i = 0;
					this._NpcLootWhitelistMapping = this.NpcLootWhitelist.ToDictionary(
						npcDef => {
							string key = npcDef.ToString();
							this._NpcLootWhitelistIdxs[key] = i++;
							return key;
						},
						npcDef => {
							return npcDef.GetID();
						}
					);
				}
				return this._NpcLootWhitelistMapping;
			}
		}

		////

		[JsonIgnore]
		public IDictionary<string, int> ItemBlacklist2Mapping {
			get {
				if( this._ItemBlacklist2Mapping == null || this._ItemBlacklist2Mapping.Count != this.ItemBlacklist.Count ) {
					this._ItemBlacklist2Idxs = new Dictionary<string, int>();

					int i = 0;
					this._ItemBlacklist2Mapping = this.ItemBlacklist2.ToDictionary(
						itemDef => {
							string key = itemDef.ToString();
							this._ItemBlacklist2Idxs[key] = i++;
							return key;
						},
						itemDef => {
							return itemDef.GetID();
						}
					);
				}
				return this._ItemBlacklist2Mapping;
			}
		}

		[JsonIgnore]
		public IDictionary<string, int> RecipeBlacklist2Mapping {
			get {
				if( this._RecipeBlacklist2Mapping == null || this._RecipeBlacklist2Mapping.Count != this.ItemBlacklist.Count ) {
					this._RecipeBlacklist2Idxs = new Dictionary<string, int>();

					int i = 0;
					this._RecipeBlacklist2Mapping = this.RecipeBlacklist2.ToDictionary(
						itemDef => {
							string key = itemDef.ToString();
							this._RecipeBlacklist2Idxs[key] = i++;
							return key;
						},
						itemDef => {
							return itemDef.GetID();
						}
					);
				}
				return this._RecipeBlacklist2Mapping;
			}
		}

		[JsonIgnore]
		public IDictionary<string, int> NpcBlacklist2Mapping {
			get {
				if( this._NpcBlacklist2Mapping == null || this._NpcBlacklist2Mapping.Count != this.ItemBlacklist.Count ) {
					this._NpcBlacklist2Idxs = new Dictionary<string, int>();

					int i = 0;
					this._NpcBlacklist2Mapping = this.NpcBlacklist2.ToDictionary(
						npcDef => {
							string key = npcDef.ToString();
							this._NpcBlacklist2Idxs[key] = i++;
							return key;
						},
						npcDef => {
							return npcDef.GetID();
						}
					);
				}
				return this._NpcBlacklist2Mapping;
			}
		}

		[JsonIgnore]
		public IDictionary<string, int> NpcLootBlacklist2Mapping {
			get {
				if( this._NpcLootBlacklist2Mapping == null || this._NpcLootBlacklist2Mapping.Count != this.ItemBlacklist.Count ) {
					this._NpcLootBlacklist2Idxs = new Dictionary<string, int>();

					int i = 0;
					this._NpcLootBlacklist2Mapping = this.NpcLootBlacklist2.ToDictionary(
						npcDef => {
							string key = npcDef.ToString();
							this._NpcLootBlacklist2Idxs[key] = i++;
							return key;
						},
						npcDef => {
							return npcDef.GetID();
						}
					);
				}
				return this._NpcLootBlacklist2Mapping;
			}
		}


		////////////////

		public void UnsetItemBlacklistEntry( string itemKey ) {
			this.ItemBlacklist.RemoveAt( this._ItemBlacklistIdxs[itemKey] );
		}

		public void UnsetRecipeBlacklistEntry( string itemKey ) {
			this.RecipeBlacklist.RemoveAt( this._RecipeBlacklistIdxs[itemKey] );
		}

		public void UnsetNpcBlacklistEntry( string npcKey ) {
			this.NpcBlacklist.RemoveAt( this._NpcBlacklistIdxs[npcKey] );
		}

		public void UnsetNpcLootBlacklistEntry( string npcKey ) {
			this.NpcLootBlacklist.RemoveAt( this._NpcLootBlacklistIdxs[npcKey] );
		}

		////

		public void UnsetItemWhitelistEntry( string itemKey ) {
			this.ItemWhitelist.RemoveAt( this._ItemWhitelistIdxs[itemKey] );
		}

		public void UnsetRecipeWhitelistEntry( string itemKey ) {
			this.RecipeWhitelist.RemoveAt( this._RecipeWhitelistIdxs[itemKey] );
		}

		public void UnsetNpcLootWhitelistEntry( string npcKey ) {
			this.NpcLootWhitelist.RemoveAt( this._NpcLootWhitelistIdxs[npcKey] );
		}

		public void UnsetNpcWhitelistEntry( string npcKey ) {
			this.NpcWhitelist.RemoveAt( this._NpcWhitelistIdxs[npcKey] );
		}

		////

		public void UnsetItemBlacklist2Entry( string itemKey ) {
			this.ItemBlacklist2.RemoveAt( this._ItemBlacklist2Idxs[itemKey] );
		}

		public void UnsetRecipeBlacklist2Entry( string itemKey ) {
			this.RecipeBlacklist2.RemoveAt( this._RecipeBlacklist2Idxs[itemKey] );
		}

		public void UnsetNpcLootBlacklist2Entry( string npcKey ) {
			this.NpcLootBlacklist2.RemoveAt( this._NpcLootBlacklist2Idxs[npcKey] );
		}

		public void UnsetNpcBlacklist2Entry( string npcKey ) {
			this.NpcBlacklist2.RemoveAt( this._NpcBlacklist2Idxs[npcKey] );
		}
	}
}
