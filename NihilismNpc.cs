using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismNpc : GlobalNPC {
		public override bool PreNPCLoot( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			var modworld = mymod.GetModWorld<NihilismWorld>();
			if( !modworld.Logic.IsCurrentWorldNihilated() ) { return base.PreNPCLoot(npc); }
			
			return modworld.Logic.IsNpcItemDropEnabled( npc );
		}


		public override bool PreAI( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.IsCurrentWorldNihilated() ) { return base.PreAI(npc); }
			
			npc.active = myworld.Logic.IsNpcEnabled( npc );
			if( !npc.active ) {
				Main.npc[npc.whoAmI] = new NPC();
			}
			
			return npc.active;
		}
	}
}
