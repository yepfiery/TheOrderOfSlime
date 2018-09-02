using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOrderOfSlime.NPCs.ZephrRaid
{
    class PlankBuilder : ModNPC
    {
        int time = 0;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 3;
            DisplayName.SetDefault("Plank Builder");
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 200;
            npc.dontTakeDamage = true;
            npc.noGravity = true;
            npc.velocity = new Vector2(0, 0);
        }
        public override void AI()
        {
            for (int i = 0; i < 1000 * 20; i++)
            {
                WorldGen.PlaceTile((int)npc.Center.X, (int)npc.Bottom.Y + 1, TileID.Platforms);
                npc.velocity = new Vector2(1, 0);
            }
            MoveDown();
            for (int i = 0; i < 1000 * 20; i++)
            {
                WorldGen.PlaceTile((int)npc.Center.X, (int)npc.Bottom.Y + 1, TileID.Platforms);
                npc.velocity = new Vector2(-1, 0);
            }
            for (int i = 0; i < 1000 * 20; i++)
            {
                WorldGen.PlaceTile((int)npc.Center.X, (int)npc.Bottom.Y + 1, TileID.Platforms);
                npc.velocity = new Vector2(1, 0);
            }
            MoveDown();
            for (int i = 0; i < 1000 * 20; i++)
            {
                WorldGen.PlaceTile((int)npc.Center.X, (int)npc.Bottom.Y + 1, TileID.WoodBlock);
                npc.velocity = new Vector2(-1, 0);
            }
            npc.active = false;
        }
        void MoveDown()
        {
            for (int i = 0; i < 500; i++)
            {
                npc.velocity = new Vector2(0, 3);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            const int Arm_Raised = 0;
            const int Arm_Falling = 1;
            const int Arm_Down = 2;

            if (time < 1000)
            {
                npc.frame.Y = npc.frame.Y = Arm_Raised * frameHeight;
                time++;
            }
            else
            {
                if (time < 1200)
                {
                    npc.frame.Y = npc.frame.Y = Arm_Falling * frameHeight;
                    time++;
                }
                else
                {
                    npc.frame.Y = npc.frame.Y = Arm_Down * frameHeight;
                    time = 0;
                }
            }
        }
    }
}
