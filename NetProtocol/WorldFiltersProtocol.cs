using HamstarHelpers.Utilities.Network;
using Nihilism.Data;
using System;


namespace Nihilism.NetProtocol {
	class WorldFiltersProtocol : PacketProtocol {
		public NihilismFilterData Filters;


		////////////////

		private void SetMyDefaults() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			if( myworld.Logic.Data == null ) { throw new Exception( "No filters to send" ); }

			this.Filters = myworld.Logic.Data;
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
			myworld.Logic.OnPostFiltersSyncToMe( mymod );
		}
		protected override void ReceiveWithServer( int from_who ) {
			this.ReceiveOnAny();
		}

		////////////////

		private void ReceiveOnAny() {
			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			
			myworld.Logic.SetData( this.Filters );
		}
	}
}
