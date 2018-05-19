using HamstarHelpers.MiscHelpers;
using HamstarHelpers.WorldHelpers;


namespace Nihilism.Data {
	partial class NihilismFilterAccess {
		private NihilismFilterData Data;


		public NihilismFilterAccess( NihilismFilterData data ) {
			this.Data = data;
		}


		////////////////

		private string GetDataFileName() {
			return WorldHelpers.GetUniqueId( true ) + " Filters";
		}

		public void Load( NihilismMod mymod ) {
			bool success;
			var filters = DataFileHelpers.LoadJson<NihilismFilterData>( mymod, this.GetDataFileName(), out success );

			if( success ) {
				this.Data = filters;
			}
		}

		public void Save( NihilismMod mymod ) {
			DataFileHelpers.SaveAsJson<NihilismFilterData>( mymod, this.GetDataFileName(), this.Data );
		}
	}
}
