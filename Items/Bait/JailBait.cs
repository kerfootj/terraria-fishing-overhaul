using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingOverhaul.Items.Bait
{
  public class JailBait : ModItem
  {

    public override void SetStaticDefaults()
    {
      Tooltip.SetDefault("Too good to be true");
    }

    public override void SetDefaults()
    {
      item.maxStack = 999;
      item.value = Item.sellPrice(1, 0, 18, 0);
      item.rare = 6;
      item.bait = 100;
    }

    public override void AddRecipes()
    {
      ModRecipe recipe = new ModRecipe(mod);
      recipe.AddIngredient(ItemID.EnchantedNightcrawler, 6);
      recipe.AddIngredient(ItemID.SoulofLight, 1);
      recipe.AddTile(TileID.Campfire);

      recipe.SetResult(this, 6);
      recipe.AddRecipe();
    }
  }
}