using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismNpc : GlobalNPC {
		public override bool PreNPCLoot( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.EnableNpcLootFilters ) { return base.PreNPCLoot( npc ); }

			var myworld = mymod.GetModWorld<NihilismWorld>();
			if( !myworld.Logic.IsCurrentWorldNihilated() ) { return base.PreNPCLoot(npc); }
			
			return myworld.Logic.IsNpcLootEnabled( npc );
		}


		public override bool PreAI( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.EnableNpcFilters ) { return base.PreAI( npc ); }

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
