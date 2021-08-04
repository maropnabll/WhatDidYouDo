using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WhatDidYouDo.Items
{
	public class Terramere : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Terramere");
			Tooltip.SetDefault("Fires a holographic sword /n Like a Zenith, but not.");
            ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 310;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 9;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 210000;
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("TerramereProjectile");
			item.shootSpeed = 20f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StarWrath, 1);
			recipe.AddIngredient(ItemID.Meowmere, 1);
			recipe.AddIngredient(ItemID.TerraBlade, 1);
			recipe.AddIngredient(ItemID.LunarBar, 7);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}