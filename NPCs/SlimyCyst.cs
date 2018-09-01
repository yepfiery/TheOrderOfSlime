using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheOrderOfSlime.NPCs
{
    class SlimyCyst : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Cyst");
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 1000;
            npc.aiStyle = -1;
        }
        public override void AI() //this just makes the cyst shake
        {
            int scale = npc.lifeMax - npc.life;
            npc.scale = scale;
            for (int i = 0; i % npc.life == 0; i++) //this gets faster the less health it has
            {
                npc.scale = scale + 1;
            }
        }
        public override void NPCLoot() //this makes stuff happen at the death
        {
            for (int i = 0; i < Main.rand.Next(3, 8); i++) //this makes three to eight slimes spawn, I think
            {
                Vector2 pos = new Vector2(npc.Center.X + Main.rand.NextFloat(-5, 5), npc.Center.Y + Main.rand.NextFloat(5));
                Vector2 direc = pos;
                direc.Normalize(); //normalizing a vector will result in the vector becoming a unit direction. multiply this by a speed
                Dust.NewDust(pos, npc.width, npc.height, 0, direc.X, direc.Y, 0, new Color(18, 204, 52));
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * .2f;
        }
        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            knockback = 0f;
            return base.StrikeNPC(ref damage, defense, ref knockback, hitDirection, ref crit);
        }
    }
}
