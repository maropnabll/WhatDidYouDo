using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WhatDidYouDo.Items
{
    public class FractalSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The soul of the Fractal.");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 9999;
            item.value = 200;
            item.rare = ItemRarityID.Purple;
            // Set other item.X values here
        }

        public override void AddRecipes()
        {
            // Recipes here. See Basic Recipe Guide
        }
    }
}