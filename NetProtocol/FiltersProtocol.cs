﻿using HamstarHelpers.Components.Network;
using Nihilism.Data;
using System;
using Terraria;


namespace Nihilism.NetProtocol {
	class FiltersProtocol : PacketProtocol {
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

		private void ReceiveOnAny() {
			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			myworld.Logic.DataAccess.Take( this.Filters );
		}

		////////////////

		protected override void ReceiveWithServer( int from_who ) {
			this.ReceiveOnAny();
		}

		protected override void ReceiveWithClient() {
			this.ReceiveOnAny();

			var mymod = NihilismMod.Instance;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			var myplayer = Main.LocalPlayer.GetModPlayer<NihilismPlayer>();

			myworld.Logic.PostFiltersLoad( mymod );

			myplayer.FinishFiltersSync();
		}
	}
}
