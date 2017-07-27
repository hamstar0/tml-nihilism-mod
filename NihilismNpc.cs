using Terraria;
using Terraria.ModLoader;


namespace Nihilism {
	class NihilismNpc : GlobalNPC {
		public override bool PreNPCLoot( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.Data.Enabled ) { return base.PreNPCLoot(npc); }

			if( !mymod.Config.Data.NpcItemDropWhitelist.ContainsKey( npc.TypeName ) ) {
				return false;
			}
			return mymod.Config.Data.NpcItemDropWhitelist[ npc.TypeName ];
		}


		public override bool PreAI( NPC npc ) {
			var mymod = (NihilismMod)this.mod;
			if( !mymod.Config.Data.Enabled ) { return base.PreAI(npc); }

			if( !mymod.Config.Data.NpcWhitelist.ContainsKey( npc.TypeName ) ) {
				npc.active = false;
			} else {
				npc.active = mymod.Config.Data.NpcWhitelist[ npc.TypeName ];
			}

			return npc.active;
		}
	}
}
