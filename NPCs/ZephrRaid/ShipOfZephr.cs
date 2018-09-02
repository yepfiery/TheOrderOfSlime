using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOrderOfSlime.NPCs.ZephrRaid
{
    class ShipOfZephr : ModNPC
    {
        public const float maxSpeed = 6f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ship of Zephr");
            Main.npcFrameCount[npc.type] = 10;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 95000;
            npc.defense = 40;
            npc.noGravity = true;
            npc.noTileCollide = false;
            npc.aiStyle = -1;
            for (int i = 0; i < npc.buffImmune.Length; i++) //im not sure if this will change every buffimune
            {
                npc.buffImmune[i] = true;
            }
            npc.buffImmune[BuffID.OnFire] = false;
            npc.knockBackResist = 5f;
        }
        public override void AI()
        {
            if (M.SpeedCalc(npc.velocity) < maxSpeed)
            {
                npc.velocity = M.Velocity(npc.Center, Main.player[Main.myPlayer].Center, 6f);
            }
            if (!ZephrRaid.planks)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Plank Builder"));
                ZephrRaid.planks = true;
            }
            npc.velocity = M.Velocity(npc.Center, Main.player[Main.myPlayer].Center, 6f);

            //put cannon and pirate code here
        }
    }
}
