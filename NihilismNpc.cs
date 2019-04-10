using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismNpc : GlobalNPC {
		public override bool PreNPCLoot( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			if( myworld.Logic == null || !myworld.Logic.AreNpcLootsFiltersEnabled() ) {
				return base.PreNPCLoot(npc);
			}

			bool _;
			return myworld.Logic.DataAccess.IsNpcLootEnabled( npc, out _, out _ );
		}


		public override bool PreAI( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			if( myworld.Logic == null || !myworld.Logic.AreNpcsFiltersEnabled() ) {
				return base.PreAI(npc);
			}

			bool _;
			bool isEnabled = myworld.Logic.DataAccess.IsNpcEnabled( npc, out _, out _ );

			if( !isEnabled ) {
				npc.active = false;
				Main.npc[npc.whoAmI] = new NPC {
					active = false
				};
			}

			return base.PreAI( npc );
		}
	}
}
