using System.IO;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ModLoader.IO;


namespace Nihilism {
	class NihilismLogic {
		private static Regex _RecipesBlacklistPattern = null;
		private static Regex _ItemsBlacklistPattern = null;
		private static Regex _NpcsBlacklistPattern = null;
		private static Regex _NpcDropsBlacklistPattern = null;

		public static Regex GetRecipesBlacklistPattern( NihilismMod mymod ) {
			if( NihilismLogic._RecipesBlacklistPattern == null ) {
				NihilismLogic._RecipesBlacklistPattern = new Regex( mymod.Config.Data.RecipesBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._RecipesBlacklistPattern;
		}
		public static Regex GetItemsBlacklistPattern( NihilismMod mymod ) {
			if( NihilismLogic._ItemsBlacklistPattern == null ) {
				NihilismLogic._ItemsBlacklistPattern = new Regex( mymod.Config.Data.RecipesBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._ItemsBlacklistPattern;
		}
		public static Regex GetNpcsBlacklistPattern( NihilismMod mymod ) {
			if( NihilismLogic._NpcsBlacklistPattern == null ) {
				NihilismLogic._NpcsBlacklistPattern = new Regex( mymod.Config.Data.RecipesBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._NpcsBlacklistPattern;
		}
		public static Regex GetNpcItemDropsBlacklistPattern( NihilismMod mymod ) {
			if( NihilismLogic._NpcDropsBlacklistPattern == null ) {
				NihilismLogic._NpcDropsBlacklistPattern = new Regex( mymod.Config.Data.RecipesBlacklistPattern, RegexOptions.IgnoreCase );
			}
			return NihilismLogic._NpcDropsBlacklistPattern;
		}


		////////////////

		public bool IsInitialized { get; private set; }
		public bool IsNihilistic { get; private set; }



		public bool IsCurrentWorldNihilated( NihilismMod mymod ) {
			if( !mymod.Config.Data.Enabled ) { return false; }
			if( !this.IsInitialized ) { return false; }

			return this.IsNihilistic;
		}

		////

		public bool IsItemWhitelisted( NihilismMod mymod, Item item ) {
			if( !mymod.Config.Data.ItemWhitelist.ContainsKey( item.Name ) ) {
				return false;
			}
			return mymod.Config.Data.ItemWhitelist[item.Name];
		}

		public bool IsItemBlacklisted( NihilismMod mymod, Item item ) {
			Match match = NihilismLogic.GetItemsBlacklistPattern( mymod ).Match( item.Name );
			return match.Success;
		}

		public bool IsItemEnabled( NihilismMod mymod, Item item ) {
			if( mymod.Config.Data.ItemsBlacklistChecksFirst ) {
				if( this.IsItemBlacklisted( mymod, item ) ) {
					return false;
				}
				return this.IsItemWhitelisted( mymod, item );
			} else {
				if( this.IsItemWhitelisted( mymod, item ) ) {
					return true;
				}
				return !this.IsItemBlacklisted( mymod, item );
			}
		}

		////

		public bool IsRecipeWhitelisted( NihilismMod mymod, Item item ) {
			if( !mymod.Config.Data.RecipeWhitelist.ContainsKey( item.Name ) ) {
				return false;
			}
			return mymod.Config.Data.RecipeWhitelist[ item.Name ];
		}

		public bool IsRecipeBlacklisted( NihilismMod mymod, Item item ) {
			Match match = NihilismLogic.GetRecipesBlacklistPattern( mymod ).Match( item.Name );
			return match.Success;
		}

		public bool IsRecipeOfItemEnabled( NihilismMod mymod, Item item ) {
			if( mymod.Config.Data.RecipesBlacklistChecksFirst ) {
				if( this.IsRecipeBlacklisted( mymod, item ) ) {
					return false;
				}
				return this.IsRecipeWhitelisted( mymod, item );
			} else {
				if( this.IsRecipeWhitelisted( mymod, item ) ) {
					return true;
				}
				return !this.IsRecipeBlacklisted( mymod, item );
			}
		}

		////

		public bool IsNpcWhitelisted( NihilismMod mymod, NPC npc ) {
			if( !mymod.Config.Data.NpcWhitelist.ContainsKey( npc.TypeName ) ) {
				return false;
			}
			return mymod.Config.Data.NpcWhitelist[npc.TypeName];
		}

		public bool IsNpcBlacklisted( NihilismMod mymod, NPC npc ) {
			Match match = NihilismLogic.GetNpcsBlacklistPattern( mymod ).Match( npc.TypeName );
			return match.Success;
		}

		public bool IsNpcEnabled( NihilismMod mymod, NPC npc ) {
			if( mymod.Config.Data.NpcsBlacklistChecksFirst ) {
				if( this.IsNpcBlacklisted( mymod, npc ) ) {
					return false;
				}
				return this.IsNpcWhitelisted( mymod, npc );
			} else {
				if( this.IsNpcWhitelisted( mymod, npc ) ) {
					return true;
				}
				return !this.IsNpcBlacklisted( mymod, npc );
			}
		}

		////

		public bool IsNpcItemDropWhitelisted( NihilismMod mymod, NPC npc ) {
			if( !mymod.Config.Data.NpcItemDropWhitelist.ContainsKey( npc.TypeName ) ) {
				return false;
			}
			return mymod.Config.Data.NpcItemDropWhitelist[npc.TypeName];
		}

		public bool IsNpcItemDropBlacklisted( NihilismMod mymod, NPC npc ) {
			Match match = NihilismLogic.GetNpcItemDropsBlacklistPattern( mymod ).Match( npc.TypeName );
			return match.Success;
		}

		public bool IsNpcItemDropEnabled( NihilismMod mymod, NPC npc ) {
			if( mymod.Config.Data.NpcItemDropsBlacklistChecksFirst ) {
				if( this.IsNpcItemDropBlacklisted(mymod, npc) ) {
					return false;
				}
				return this.IsNpcItemDropWhitelisted( mymod, npc );
			} else {
				if( this.IsNpcItemDropWhitelisted( mymod, npc ) ) {
					return true;
				}
				return !this.IsNpcItemDropBlacklisted( mymod, npc );
			}
		}
		

		////////////////

		public void NihiliateCurrentWorld( NihilismMod mymod, bool is_nihilated ) {
			if( this.IsInitialized ) { return; }

			this.IsNihilistic = is_nihilated;
			this.IsInitialized = true;

			if( Main.netMode == 1 ) {   // Client
				NihilismNetProtocol.SendInitAndModSettingsFromClient( mymod );
			}
		}


		////////////////

		public void LoadWorldData( TagCompound tag ) {
			this.IsNihilistic = tag.GetBool( "enabled" );
			this.IsInitialized = tag.GetBool( "init" );
		}

		public TagCompound SaveWorldData() {
			return new TagCompound {
				{ "enabled", this.IsNihilistic },
				{ "init", this.IsInitialized }
			};
		}

		public void NetReceiveWorldData( BinaryReader reader ) {
			if( Main.netMode != 1 ) { return; } // Client only
			this.IsNihilistic = reader.ReadBoolean();
			this.IsInitialized = reader.ReadBoolean();
		}

		public void NetSendWorldData( BinaryWriter writer ) {
			if( Main.netMode != 2 ) { return; }	// Server only
			writer.Write( this.IsNihilistic );
			writer.Write( this.IsInitialized );
		}
	}
}
