using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismNpc : GlobalNPC {
		public override bool PreNPCLoot( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			var modworld = mymod.GetModWorld<NihilismWorld>();
			if( !modworld.Logic.IsCurrentWorldNihilated( mymod ) ) { return base.PreNPCLoot(npc); }
			
			return modworld.Logic.IsNpcItemDropEnabled( mymod, npc );
		}


		public override bool PreAI( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			var modworld = mymod.GetModWorld<NihilismWorld>();
			if( !modworld.Logic.IsCurrentWorldNihilated( mymod ) ) { return base.PreAI(npc); }
			
			npc.active = modworld.Logic.IsNpcEnabled( mymod, npc );
			
			return npc.active;
		}
	}
}
