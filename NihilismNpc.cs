using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismNpc : GlobalNPC {
		public override bool PreNPCLoot( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			if( myworld.Logic == null || !myworld.Logic.AreNpcLootsFiltersEnabled( mymod ) ) {
				return base.PreNPCLoot(npc);
			}

			return myworld.Logic.DataAccess.IsNpcLootEnabled( npc );
		}


		public override bool PreAI( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			if( myworld.Logic == null || !myworld.Logic.AreNpcsFiltersEnabled( mymod ) ) {
				return base.PreAI(npc);
			}
			
			bool is_enabled = myworld.Logic.DataAccess.IsNpcEnabled( npc );

			if( !is_enabled ) {
				npc.active = false;
				Main.npc[npc.whoAmI] = new NPC {
					active = false
				};
			}

			return base.PreAI( npc );
		}
	}
}
