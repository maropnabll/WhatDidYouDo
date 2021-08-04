using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WhatDidYouDo.Projectiles
{
    public class TerramereProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holographic Sword");
            Main.projFrames[projectile.type] = 3;

        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
			projectile.friendly = true;
			drawOriginOffsetY = -24;
			drawOffsetX = -25;
        }

        public override void AI()
        {
             // Fade in`
            projectile.alpha -= 25;
            if (projectile.alpha < 100)
            {
                projectile.alpha = 100;
            }
			projectile.rotation = projectile.velocity.ToRotation();
            // Slow down`
            projectile.velocity *= 0.98f;
			
			projectile.velocity.Y = projectile.velocity.Y + 0.1f; // 0.1f for arrow gravity, 0.4f for knife gravity
			if (projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
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