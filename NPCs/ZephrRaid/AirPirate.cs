using Terraria;
using Terraria.ModLoader;

namespace TheOrderOfSlime.NPCs.ZephrRaid
{
    class AirPirate : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Air Pirate");
            Main.npcFrameCount[npc.type] = 7;
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
        }
    }
}
