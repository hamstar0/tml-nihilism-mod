using HamstarHelpers.Components.Network;
using HamstarHelpers.Components.Network.Data;
using Nihilism.Data;
using System;
using Terraria;


namespace Nihilism.NetProtocol {
	class FiltersProtocol : PacketProtocolSentToEither {
		public NihilismFilterData Filters;


		////////////////

		protected FiltersProtocol( PacketProtocolDataConstructorLock ctor_lock ) : base( ctor_lock ) { }
		
		////////////////

		private void SetMyDefaults() {
			var myworld = NihilismMod.Instance.GetModWorld<NihilismWorld>();
			if( myworld.Logic.DataAccess == null ) { throw new Exception( "No filters to send" ); }

			myworld.Logic.DataAccess.Give( ref this.Filters );
		}

		protected override void SetClientDefaults() {
			this.SetMyDefaults();
		}
		protected override void SetServerDefaults( int to_who ) {
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
			var myplayer = Main.LocalPlayer.GetModPlayer<NihilismPlayer>();

			myworld.Logic.PostFiltersLoad( mymod );

			myplayer.FinishFiltersSync();
		}
	}
}
