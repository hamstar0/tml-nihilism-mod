using HamstarHelpers.Components.Errors;
using HamstarHelpers.Components.Network;
using HamstarHelpers.Helpers.TmlHelpers;
using Nihilism.Data;
using Terraria;


namespace Nihilism.NetProtocol {
	class FiltersProtocol : PacketProtocolSentToEither {
		public NihilismFilterData Filters;


		////////////////

		private FiltersProtocol() { }
		
		////////////////

		private void SetMyDefaults() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			if( myworld.Logic.DataAccess == null ) { throw new HamstarException( "No filters to send" ); }

			myworld.Logic.DataAccess.Give( ref this.Filters );
		}

		protected override void SetClientDefaults() {
			this.SetMyDefaults();
		}
		protected override void SetServerDefaults( int toWho ) {
			this.SetMyDefaults();
		}


		////////////////

		private void ReceiveOnAny() {
			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.DataAccess.Take( this.Filters );
		}

		////////////////

		protected override void ReceiveOnServer( int from_who ) {
			this.ReceiveOnAny();
		}

		protected override void ReceiveOnClient() {
			this.ReceiveOnAny();

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			var myplayer = (NihilismPlayer)TmlHelpers.SafelyGetModPlayer( Main.LocalPlayer, mymod, "NihilismPlayer" );

			myworld.Logic.PostFiltersLoad();

			myplayer.FinishFiltersSync();
		}
	}
}
