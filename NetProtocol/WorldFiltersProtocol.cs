using HamstarHelpers.Utilities.Network;
using Nihilism.Data;


namespace Nihilism.NetProtocol {
	class NihilismWorldFiltersProtocol : PacketProtocol {
		public NihilismFilterData Filters;


		////////////////

		public override void SetServerDefaults() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			
			this.Filters = myworld.Logic.Data;
		}

		////////////////

		protected override void ReceiveWithClient() {
			this.ReceiveOnAny();
		}
		protected override void ReceiveWithServer( int from_who ) {
			this.ReceiveOnAny();
		}

		////////////////

		private void ReceiveOnAny() {
			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			
			myworld.Logic.UpdateFilters( this.Filters );
		}
	}
}
