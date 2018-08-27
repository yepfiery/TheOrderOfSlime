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
	}
}
