using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheOrderOfSlime
{
    class TheWorldOfSlime : ModWorld
    {
        /*
        public static bool raid = false;
        public static bool raided = false;
        public override void PostUpdate()
        {
            if (Main.rand.Next(1000 * 180 * 10) == 0)
            {
                raided = true;
            }
            if (raided)
            {
                Talk("Oh no, you're being raided!");
                raid = true;
                raided = false;
            }
        }
        private void Talk(string message)
        {
            if (Main.netMode != 2)
            {
                Main.NewText(message, 150, 250, 150);
            }
            else
            {
                NetworkText text = NetworkText.FromLiteral(message);
                NetMessage.BroadcastChatMessage(text, new Color(150, 250, 150));
            }
        }
        */
    }
}
