using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WhatDidYouDo.Projectiles
{
    public class SupremeAmogusProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Truer Copper Shortsword");

        }

        public override void SetDefaults()
        {
            projectile.width = 88;
            projectile.height = 88;
            projectile.tileCollide = false;
            projectile.hostile = true;
            drawOriginOffsetY = -24;
            drawOffsetX = -25;
        }

        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 170f)
            {
                // Fade out
                projectile.alpha += 25;
                if (projectile.alpha > 255)
                {
                    projectile.alpha = 255;
                }
            }
            else
            {
                // Fade in
                projectile.alpha -= 25;
                if (projectile.alpha < 100)
                {
                    projectile.alpha = 100;
                }
            }
            // Kill this projectile after 1 second
            if (projectile.ai[0] >= 180f)
            {
                projectile.Kill();
            }
            projectile.rotation = projectile.velocity.ToRotation();
            // Slow down`
            projectile.velocity *= 0.98f;

            projectile.ai[1] += 1f; // Use a timer to wait 15 ticks before applying gravity.
            if (projectile.ai[1] >= 15f)
            {
                projectile.ai[1] = 15f;
                projectile.velocity.Y = projectile.velocity.Y + 0.4f;
                projectile.rotation += 0.4f * (float)projectile.direction;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }

            Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);
            Lighting.AddLight(projectile.Center, 0.1f, 0.3f, 0.8f);

            // Loop through the 4 animation frames, spending 5 ticks on each.`
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 3)
                {
                    projectile.frame = 0;
                }
            }

            // Additional hooks/methods here.
        }
    }
}