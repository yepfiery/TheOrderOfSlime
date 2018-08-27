using Terraria;
using Terraria.ModLoader;

namespace TheOrderOfSlime.Buffs
{
    class Home : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[mod.BuffType("Home")] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.jumpSpeedBoost += 4.8f;
            player.extraFall += 45;
            player.lifeRegen++;
            player.meleeCrit += 2;
            player.meleeDamage += 0.051f;
            player.meleeSpeed += 0.051f;
            player.statDefense += 3;
            player.moveSpeed += 0.05f;
            player.calmed = true;
        }
    }
    class SpawnRateChange : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (ThePlayerOfSlime.home)
            {
                spawnRate = 1;
                maxSpawns = 20;
            }
        }
    }
}
