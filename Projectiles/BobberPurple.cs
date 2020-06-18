using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingOverhaul.Projectiles
{
  public class BobberPurple : ModProjectile
  {
    public override void SetDefaults()
    {
      projectile.CloneDefaults(ProjectileID.BobberGolden);
    }

    public override bool PreDrawExtras(SpriteBatch spriteBatch)      //this draws the fishing line correctly
    {
      Lighting.AddLight(projectile.Center, 0.9f, 0.4f, 0.4f);  //this defines the projectile/bobber light color

      Player player = Main.player[projectile.owner];
      Item selectedItem = player.inventory[player.selectedItem];

      if (projectile.bobber && selectedItem.holdStyle > 0)
      {
        float posX = player.MountedCenter.X;
        float posY = player.MountedCenter.Y;

        posY += player.gfxOffY;

        float gravDir = player.gravDir;

        if (selectedItem.type == mod.ItemType("FishStick"))
        {
          posX += (float)(50 * player.direction);

          if (player.direction < 0)
          {
            posX -= 13f;
          }

          posY -= 30f * gravDir;
        }

        if (gravDir == -1f)
        {
          posY -= 12f;
        }

        Vector2 v = new Vector2(posX, posY);
        v = player.RotatedRelativePoint(v + new Vector2(8f), true) - new Vector2(8f);

        float projPosX = projectile.position.X + (float)projectile.width * 0.5f - v.X;
        float projPosY = projectile.position.Y + (float)projectile.height * 0.5f - v.Y;

        bool flag2 = true;
        if (projPosX == 0f && projPosY == 0f)
        {
          flag2 = false;
        }
        else
        {
          float projPosXY = (float)Math.Sqrt((double)(projPosX * projPosX + projPosY * projPosY));
          projPosXY = 12f / projPosXY;
          projPosX *= projPosXY;
          projPosY *= projPosXY;
          v.X -= projPosX;
          v.Y -= projPosY;
          projPosX = projectile.position.X + (float)projectile.width * 0.5f - v.X;
          projPosY = projectile.position.Y + (float)projectile.height * 0.5f - v.Y;
        }
        while (flag2)
        {
          float num = 12f;
          float num2 = (float)Math.Sqrt((double)(projPosX * projPosX + projPosY * projPosY));
          float num3 = num2;
          if (float.IsNaN(num2) || float.IsNaN(num3))
          {
            break;
          }
          else
          {
            if (num2 < 20f)
            {
              num = num2 - 8f;
              flag2 = false;
            }
            num2 = 12f / num2;
            projPosX *= num2;
            projPosY *= num2;
            v.X += projPosX;
            v.Y += projPosY;
            projPosX = projectile.position.X + (float)projectile.width * 0.5f - v.X;
            projPosY = projectile.position.Y + (float)projectile.height * 0.1f - v.Y;
            if (num3 > 12f)
            {
              float num4 = 0.3f;
              float num5 = Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y);
              if (num5 > 16f)
              {
                num5 = 16f;
              }
              num5 = 1f - num5 / 16f;
              num4 *= num5;
              num5 = num3 / 80f;
              if (num5 > 1f)
              {
                num5 = 1f;
              }
              num4 *= num5;
              if (num4 < 0f)
              {
                num4 = 0f;
              }
              num5 = 1f - projectile.localAI[0] / 100f;
              num4 *= num5;
              if (projPosY > 0f)
              {
                projPosY *= 1f + num4;
                projPosX *= 1f - num4;
              }
              else
              {
                num5 = Math.Abs(projectile.velocity.X) / 3f;
                if (num5 > 1f)
                {
                  num5 = 1f;
                }
                num5 -= 0.5f;
                num4 *= num5;
                if (num4 > 0f)
                {
                  num4 *= 2f;
                }
                projPosY *= 1f + num4;
                projPosX *= 1f - num4;
              }
            }
            float rotation2 = (float)Math.Atan2((double)projPosY, (double)projPosX) - 1.57f;
            Microsoft.Xna.Framework.Color color2 = Lighting.GetColor((int)v.X / 16, (int)(v.Y / 16f), new Microsoft.Xna.Framework.Color(169, 125, 250, 100));    //this is the fishing line color in RGB, 200 is red, 12 is green, 50 blue

            Main.spriteBatch.Draw(Main.fishingLineTexture, new Vector2(v.X - Main.screenPosition.X + (float)Main.fishingLineTexture.Width * 0.5f, v.Y - Main.screenPosition.Y + (float)Main.fishingLineTexture.Height * 0.5f), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.fishingLineTexture.Width, (int)num)), color2, rotation2, new Vector2((float)Main.fishingLineTexture.Width * 0.5f, 0f), 1f, SpriteEffects.None, 0f);
          }
        }
      }
      return false;
    }
  }
}