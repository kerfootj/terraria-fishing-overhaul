using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingOverhaul.Items.Bait
{
  public class SuperBait : ModItem
  {
    public override void SetStaticDefaults()
    {
      Tooltip.SetDefault("The best bait");
    }

    public override void SetDefaults()
    {
      item.maxStack = 999;
      item.value = Item.buyPrice(0, 0, 5, 0);
      item.rare = 5;
      item.bait = 20;
    }

    public override void AddRecipes()
    {
      ModRecipe recipe = new ModRecipe(mod);
      recipe.AddIngredient(ItemID.Wood, 2);
      recipe.AddTile(TileID.WorkBenches);
      recipe.SetResult(this, 10);
      recipe.AddRecipe();
    }
  }
}