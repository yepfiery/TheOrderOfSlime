using Terraria;
using Terraria.ModLoader;

namespace TheOrderOfSlime.Buffs.tfever
{
    class CommonCold : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Common Cold");
            Description.SetDefault("May turn to something worse.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }
    }
}
