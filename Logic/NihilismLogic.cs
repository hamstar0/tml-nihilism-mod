using HamstarHelpers.DebugHelpers;
using HamstarHelpers.MiscHelpers;
using HamstarHelpers.Utilities.Network;
using HamstarHelpers.WorldHelpers;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria;


namespace Nihilism.Logic {
	partial class NihilismLogic {
		public NihilismFilterData Data { get; private set; }


		////////////////

		public NihilismLogic() {
			this.Data = null;
		}

		////////////////

		public bool IsCurrentWorldNihilated() {
			return this.Data != null && this.Data.IsActive;
		}


		public void NihilateCurrentWorld() {
			this.Data.IsActive = true;
		}

		public void UnnihilateCurrentWorld() {
			this.Data.IsActive = false;
		}


		////////////////

		private string GetDataFileName() {
			return WorldHelpers.GetUniqueId( true ) + " Filters";
		}

		public void LoadWorldData( NihilismMod mymod ) {
			bool success;
			var filters = DataFileHelpers.LoadJson<NihilismFilterData>( mymod, this.GetDataFileName(), out success );

			if( success ) {
				this.Data = filters;
			}
		}

		public void SaveWorldData( NihilismMod mymod ) {
			if( this.Data == null ) {
				return;
			}

			DataFileHelpers.SaveAsJson<NihilismFilterData>( mymod, this.GetDataFileName(), this.Data );
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
			this.Data = filters;
		}
	}
}
