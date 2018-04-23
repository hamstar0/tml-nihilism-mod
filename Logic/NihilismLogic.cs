using HamstarHelpers.DebugHelpers;
using HamstarHelpers.MiscHelpers;
using HamstarHelpers.Utilities.Network;
using HamstarHelpers.WorldHelpers;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria;


namespace Nihilism.Logic {
	partial class NihilismLogic {
		public NihilismFilterData Filters { get; private set; }


		////////////////

		public NihilismLogic() {
			this.Filters = null;
		}

		////////////////

		public bool IsCurrentWorldNihilated() {
			return this.Filters != null && this.Filters.IsActive;
		}


		////////////////

		private string GetDataFileName() {
			return WorldHelpers.GetUniqueId( true ) + " Filters";
		}

		public void LoadWorldData( NihilismMod mymod ) {
			bool success;
			var filters = DataFileHelpers.LoadJson<NihilismFilterData>( mymod, this.GetDataFileName(), out success );

			if( success ) {
				this.Filters = filters;
			}
		}

		public void SaveWorldData( NihilismMod mymod ) {
			if( this.Filters == null ) {
				return;
			}

			DataFileHelpers.SaveAsJson<NihilismFilterData>( mymod, this.GetDataFileName(), this.Filters );
		}


		////////////////

		public void OnEnterWorldForSingle( NihilismMod mod, Player player ) { }


		public void OnEnterWorldForClient( NihilismMod mod, Player player ) {
			PacketProtocol.QuickRequestFromServer<NihilismModSettingsProtocol>();
			PacketProtocol.QuickRequestFromServer<NihilismWorldFiltersProtocol>();
		}


		public void OnEnterWorldForServer( NihilismMod mod, Player player ) { }


		////////////////

		internal void UpdateFilters( NihilismFilterData filters ) {
			this.Filters = filters;
		}
	}
}
