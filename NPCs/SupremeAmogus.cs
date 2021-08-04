using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using WhatDidYouDo.Projectiles;
using Terraria.ModLoader;

namespace WhatDidYouDo.NPCs
{
	//ported from my tAPI mod because I'm lazy
	public class SupremeAmogus : ModNPC
	{
		private static int hellLayer => Main.maxTilesY - 200;


		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Supreme Amogus");
		}

		public override void SetDefaults() {
			npc.lifeMax = 80000;
			npc.damage = 160;
			npc.boss = true;
			npc.noTileCollide = true;
			npc.scale = 6f;
			music = MusicID.Boss2;
			npc.defense = 90;
			npc.knockBackResist = 0.3f;
			npc.width = 64;
			npc.height = 64;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 15, 0);
		}

		public override void AI() {
			npc.velocity *= 0.92f;
			npc.TargetClosest();
			float speed = 20f;
			float bossSpeed = 2.5f;
			Vector2 shootVelocity = npc.DirectionTo(Main.player[npc.target].Center) * speed;
			Vector2 bossVelocity = npc.DirectionTo(Main.player[npc.target].Center) * bossSpeed;
			npc.velocity = bossVelocity;
			Player player = Main.player[npc.target];
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				if (!player.active || player.dead || player.position.Y < hellLayer * 16)
				{
					npc.velocity = new Vector2(0f, 10f);
					if (npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
					}
					return;
				}
			}
			if (npc.localAI[0] == 16f) {
				for (int k = 0; k < 6; k++)
				{
					int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, ModContent.ProjectileType<SupremeAmogusProjectile>(), npc.damage, 0, Main.myPlayer);
					if (proj == 1000)
					{
						npc.active = false;
						return;
					}
					SupremeAmogusProjectile arm = Main.projectile[proj].modProjectile as SupremeAmogusProjectile;
					arm.projectile.velocity = shootVelocity;
					arm.projectile.scale = 3f;
				}
				npc.localAI[0] = 0f;
			}
			if (npc.localAI[0] == 12f)
			{
				if (npc.life <= npc.lifeMax / 2)
				{
					if (npc.localAI[1] == 0)
                    {
						bossSpeed = 5.5f;
						Main.PlaySound(SoundID.NPCDeath15);
						npc.localAI[1] = 1;
						Main.NewText("sus.");
					}
					for (int k = 0; k < 6; k++)
					{
						int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, ModContent.ProjectileType<SupremeAmogusProjectile>(), npc.damage, 0, Main.myPlayer);
						if (proj == 1000)
						{
							npc.active = false;
							return;
						}
						SupremeAmogusProjectile arm = Main.projectile[proj].modProjectile as SupremeAmogusProjectile;
						arm.projectile.velocity = shootVelocity;
						arm.projectile.scale = 3f;
					}
				}
			}
			npc.localAI[0] += 1;
			base.AI();
		}

		public override void FindFrame(int frameHeight) {
			npc.frame.Y = 0;
			npc.rotation = 0f;
		}

		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0) {
				for (int k = 0; k < 20; k++) {
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AmogusDead"), 6f);
			}
			else {
				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++) {
					Dust.NewDust(npc.position, npc.width, npc.height, 151, (float)hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return 0f;
		}
	}
}