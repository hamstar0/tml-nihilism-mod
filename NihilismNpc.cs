using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismNpc : GlobalNPC {
		public override bool PreNPCLoot( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			if( !myworld.Logic.AreNpcLootsFiltered( mymod ) ) {
				return base.PreNPCLoot(npc);
			}
			
			return myworld.Logic.Data.IsNpcLootEnabled( npc );
		}


		public override bool PreAI( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();

			if( !myworld.Logic.AreNpcsFiltered( mymod ) ) {
				return base.PreAI(npc);
			}
			
			npc.active = myworld.Logic.Data.IsNpcEnabled( npc );
			if( !npc.active ) {
				Main.npc[npc.whoAmI] = new NPC();
				Main.npc[npc.whoAmI].active = false;
			}
			
			return npc.active;
		}
	}
}
