using Terraria;
using Terraria.ModLoader;

namespace TheOrderOfSlime
{
    // This class stores necessary player info for our custom damage class, such as damage multipliers and additions to knockback and crit.
    public class EnergyPlayer : ModPlayer
    {
        public static EnergyPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<EnergyPlayer>();
        }

        // Vanilla only really has damage multipliers in code
        // And crit and knockback is usually just added to
        // As a modder, you could make separate variables for multipliers and simple addition bonuses
        public float energyDamage = 1f;
        public float energyKnockback = 0f;
        public int energyCrit = 0;

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            energyDamage = 1f;
            energyKnockback = 0f;
            energyCrit = 0;
        }
    }
}
