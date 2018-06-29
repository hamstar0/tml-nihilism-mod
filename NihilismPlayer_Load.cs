using HamstarHelpers.Components.Network;
using HamstarHelpers.DebugHelpers;
using Nihilism.Data;
using Nihilism.NetProtocol;
using Terraria.ModLoader;


namespace Nihilism {
	partial class NihilismPlayer : ModPlayer {
		internal void OnEnterWorldForSingle() {
			var mymod = (NihilismMod)this.mod;
			var myworld = this.mod.GetModWorld<NihilismWorld>();

			myworld.Logic.PostFiltersLoad( mymod );
			
			this.FinishFiltersSync();
		}

		internal void OnEnterWorldForClient() {
			PacketProtocol.QuickRequestToServer<FiltersProtocol>();
		}

		internal void OnEnterWorldForServer() {
			this.IsFiltersSynced = true;
		}


		////////////////
		
		internal void FinishFiltersSync() {
			this.IsFiltersSynced = true;
		}

		////////////////

		public bool IsSynced() {
			return this.IsFiltersSynced;
		}
	}
}
