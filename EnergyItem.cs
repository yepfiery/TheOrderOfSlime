﻿using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace TheOrderOfSlime
{
    // This class handles everything for our custom damage class
    // Any class that we wish to be using our custom damage class will derive from this class, instead of ModItem
    public abstract class EnergyItem : ModItem
    {
        private int duration = 100;

        // Custom items should override this to set their defaults
        public virtual void SafeSetDefaults()
        {
        }

        // By making the override sealed, we prevent derived classes from further overriding the method and enforcing the use of SafeSetDefaults()
        // We do this to ensure that the vanilla damage types are always set to false, which makes the custom damage type work
        public sealed override void SetDefaults()
        {
            SafeSetDefaults();
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }

        // As a modder, you could also opt to make the Get overrides also sealed. Up to the modder
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            // Multiplies the damage by our custom damage multiplier
            damage = (int)(damage * EnergyPlayer.ModPlayer(player).energyDamage + 5E-06f);
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            // Adds knockback bonuses
            knockback = knockback + EnergyPlayer.ModPlayer(player).energyKnockback;
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            // Adds crit bonuses
            crit = crit + EnergyPlayer.ModPlayer(player).energyCrit;
        }

        // Because we want the damage tooltip to show our custom damage, we need to modify it
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Get the vanilla damage tooltip
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                // We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what langauge the player is using)
                // So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                // Change the tooltip text
                tt.text = damageValue + " energy " + damageWord;
            }
        }
    }
}
