using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WhatDidYouDo.Items
{
	public class ComicallyLargeFirstFractal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Comically Large First Fractal");
			Tooltip.SetDefault("hahahaha look its so big hahawhfhdhbgdnbsdfsdf");
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 66600;
			item.melee = true;
			item.width = 500;
			item.height = 500;
			item.useTime = 1;
			item.useAnimation = 20;
			item.useStyle = 3;
			item.knockBack = 20;
			item.value = 210000;
			item.rare = ItemRarityID.Gray;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LargeFirstFractalBeam");
			item.shootSpeed = 20f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StarWrath, 100);
			recipe.AddIngredient(ItemID.Meowmere, 100);
			recipe.AddIngredient(ItemID.TerraBlade, 100);
			recipe.AddIngredient(ItemID.LunarBar, 10000);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}