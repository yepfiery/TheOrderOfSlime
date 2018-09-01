using System;
using Terraria.ModLoader;

namespace TheOrderOfSlime
{
	public class TheOrderOfSlime : Mod
	{
        public static TheOrderOfSlime instance;
        //public static Mod tTodo = ModLoader.GetMod("tTodo");
        //public static Mod tfever = ModLoader.GetMod("tfever");

        public override void Load()
        {
            instance = this;
        }
        public override void Unload()
        {
            instance = null;
        }
        public TheOrderOfSlime()
		{
		}
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBossWithInfo", "Ship of Zephr", 7.3f, (Func<bool>)(() => TheWorldOfSlime.downedZephrShip), "Multiple will spawn during the Zephr Raid event.");
                bossChecklist.Call("AddEvent", "Zephr Raid", 7.2, (Func<bool>)(() => TheWorldOfSlime.downedZephrRaid), "Will spawn randomly during the day after a mechanical boss has been defeated.");
            }
        }
    }
}
