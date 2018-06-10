using HamstarHelpers.Utilities.Network;
using Nihilism.Data;
using System;


namespace Nihilism.NetProtocol {
	class WorldFiltersProtocol : PacketProtocol {
		public NihilismFilterData Filters;


		////////////////

		private void SetMyDefaults() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			if( myworld.Logic.DataAccess == null ) { throw new Exception( "No filters to send" ); }

			myworld.Logic.DataAccess.Give( ref this.Filters );
		}

		public override void SetClientDefaults() {
			this.SetMyDefaults();
		}
		public override void SetServerDefaults() {
			this.SetMyDefaults();
		}

		////////////////

		protected override void ReceiveWithClient() {
			this.ReceiveOnAny();

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			myworld.Logic.OnFiltersLoad( mymod );
		}
		protected override void ReceiveWithServer( int from_who ) {
			this.ReceiveOnAny();
		}

		////////////////

		private void ReceiveOnAny() {
			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			
			myworld.Logic.DataAccess.Take( this.Filters );
		}
	}
}
