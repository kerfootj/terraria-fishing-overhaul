using Terraria.ID;
using Terraria.ModLoader;

namespace FishingOverhaul.Items.Tools
{
  public class FishStick : ModItem
  {
    public override void SetStaticDefaults()
    {
      // DisplayName.SetDefault("FishStick"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
      Tooltip.SetDefault("What are you a gay fish?");
    }

    public override void SetDefaults()
    {
      item.CloneDefaults(ItemID.GoldenFishingRod);
      item.fishingPole = 160;
      item.value = 69000;
      item.rare = 9;
      item.shoot = mod.ProjectileType("FishStickBobber");
      item.shootSpeed = 18f;
    }

    public override void AddRecipes()
    {
      ModRecipe recipe = new ModRecipe(mod);
      recipe.AddIngredient(ItemID.DirtBlock, 10);
      recipe.AddTile(TileID.WorkBenches);
      recipe.SetResult(this);
      recipe.AddRecipe();
    }
  }
}