using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		private IDictionary<string, Regex> Regexes = new Dictionary<string, Regex>();


		public Regex GetRegex( string pattern ) {
			if( !this.Regexes.ContainsKey(pattern) ) {
				this.Regexes[ pattern ] = new Regex( pattern, RegexOptions.IgnoreCase );
			}
			return this.Regexes[pattern];
		}
	}
}
