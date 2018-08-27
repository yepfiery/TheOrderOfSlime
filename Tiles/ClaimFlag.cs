using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace TheOrderOfSlime.Tiles
{
    public class ClaimFlag : ModTile
    {
        public override void SetDefaults() //this is just from example bed
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            //TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 }; //this is the pixels for each tile
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("ClaimFlag");
            AddMapEntry(new Color(200, 200, 200), name);
            dustType = DustID.Confetti;
            disableSmartCursor = true;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 64, 32, mod.ItemType("ClaimFlag"));
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                ThePlayerOfSlime.nearClaimFlag = true;
            }
        }
    }
}
