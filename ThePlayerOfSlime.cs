using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace TheOrderOfSlime
{
    public class ThePlayerOfSlime : ModPlayer
    {
        public static bool nearClaimFlag = false;
        public static bool dev = false;
        public static bool susceptable = true;
        public static int health = 100;
        public static bool home = false;

        public override void PostUpdateBuffs()
        {
            if (nearClaimFlag)
            {
                player.AddBuff(mod.BuffType("Home"), 1);
                home = true;
                susceptable = false;
            }
        }
    }
    class tfeverPlayer : ModPlayer //every tfever feature happens here
    {
        public static bool cold = false;
        public static bool cold1 = false;
        public static bool fever = false;
        public int minutes; //the lower minutes are, the less dangerous buffs you recieve

        public override void PostUpdateBuffs()
        {
            if (ThePlayerOfSlime.susceptable)
            {
                minutes = 5;
            }
            if (ThePlayerOfSlime.susceptable == false)
            {
                minutes = 3;
            }
            if (Main.rand.Next(1000 * 60 * minutes * 2) == 0)
            {
                player.AddBuff(mod.BuffType("CommonCold"), 60);
                cold = true;
            }
            if (cold && !player.HasBuff(mod.BuffType("CommonCold")))
            {
                if (Main.rand.Next(minutes) == 0)
                {
                    player.AddBuff(mod.BuffType("CommonCold1"), 60);
                    cold1 = true;
                }
                else
                {
                    switch (Main.rand.Next(1))
                    {
                        default:
                            //player.AddBuff(mod.BuffType("Fever"), 60);
                            fever = true;
                            break;
                    }
                }
                cold = false;
            }
        }
    }
    class Conf
    {
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "The Royal Order.json");

        static Preferences Configuration = new Preferences(ConfigPath);

        public static void Load()
        {
            //Reading the config file
            bool success = ReadConfig();

            if (!success)
            {
                ErrorLogger.Log("Creating The Royal Order's config file.");
                CreateConfig();
            }
        }

        //Returns "true" if the config file was found and successfully loaded.
        static bool ReadConfig()
        {
            if (Configuration.Load())
            {
                Configuration.Get("Dev (allows you to use developer items)", ref ThePlayerOfSlime.dev);
                return true;
            }
            return false;
        }

        //Creates a config file. This will only be called if the config file doesn't exist yet or it's invalid. 
        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("Dev (allows you to use developer items)", ThePlayerOfSlime.dev);
            Configuration.Save();
        }

    }
}
