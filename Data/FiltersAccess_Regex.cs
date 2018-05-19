using HamstarHelpers.Utilities.Config;
using System.Text.RegularExpressions;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		private Regex _ItemsBlacklistPattern = null;
		private Regex _RecipesBlacklistPattern = null;
		private Regex _NpcsBlacklistPattern = null;
		private Regex _NpcLootBlacklistPattern = null;

		public Regex GetRecipesBlacklistPattern() {
			if( this._RecipesBlacklistPattern == null ) {
				this._RecipesBlacklistPattern = new Regex( this.RecipesBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return this._RecipesBlacklistPattern;
		}
		public Regex GetItemsBlacklistPattern() {
			if( this._ItemsBlacklistPattern == null ) {
				this._ItemsBlacklistPattern = new Regex( this.ItemsBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return this._ItemsBlacklistPattern;
		}
		public Regex GetNpcsBlacklistPattern() {
			if( this._NpcsBlacklistPattern == null ) {
				this._NpcsBlacklistPattern = new Regex( this.NpcBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return this._NpcsBlacklistPattern;
		}
		public Regex GetNpcLootBlacklistPattern() {
			if( this._NpcLootBlacklistPattern == null ) {
				this._NpcLootBlacklistPattern = new Regex( this.NpcLootBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return this._NpcLootBlacklistPattern;
		}

		public void ResetCachedPatterns() {
			this._RecipesBlacklistPattern = null;
			this._ItemsBlacklistPattern = null;
			this._NpcsBlacklistPattern = null;
			this._NpcLootBlacklistPattern = null;
		}
	}
}
