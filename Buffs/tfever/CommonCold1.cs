using Terraria;
using Terraria.ModLoader;

namespace TheOrderOfSlime.Buffs.tfever
{
    class CommonCold1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Common Cold");
            Description.SetDefault("May turn to something worse. I might want to get this treated.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }
    }
}
