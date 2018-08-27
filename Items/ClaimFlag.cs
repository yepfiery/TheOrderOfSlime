using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TheOrderOfSlime.Items
{
	public class ClaimFlag : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Claim Flag");
			Tooltip.SetDefault("This flag will represent your territory where you are safe."
                + "\nIf you are within relatively close to the flag, the the local "
                + "\nspawn rate considerably lowers, your physical abilities are increased, "
                + "more damage and critical chances, as well as other bonuses.");
		}
		public override void SetDefaults()
		{
			item.useTime = 20;
			item.useAnimation = 20;
			item.value = 10000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
            item.useStyle = 1;
            item.createTile = mod.TileType("ClaimFlag");
		}
        /*
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        */
    }
    public class ClaimFlagPlayer : ModPlayer
    {
        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("ClaimFlag"));
            item.stack = 1;
            items.Add(item);
        }
    }
}
