using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingOverhaul.Projectiles
{
  public class FishStickBobber : ModProjectile
  {

    public override void SetDefaults()
    {
      projectile.CloneDefaults(ProjectileID.BobberGolden);
    }
  }
}