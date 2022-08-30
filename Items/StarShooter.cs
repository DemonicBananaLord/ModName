using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace ModName.Items
{
    public class StarShooter : ModItem
    {
        public override string Texture => $"Terraria/Images/Item_{(int)ItemID.DirtRod}";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Shooter");
            Tooltip.SetDefault("Shoots stones from the stars");
        }
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Magic;
            Item.damage = 10;
            Item.knockBack = 2.5f;
            Item.height = 28;
            Item.width = 28;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.shoot = ModContent.ProjectileType<Projectiles.Stone>();
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shootSpeed = 1;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = 2;
            Item.mana = 2;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 spawnPos = new(Main.MouseWorld.X + Main.rand.Next(-100, 100), player.position.Y + Main.rand.Next(-800, -600));
            Vector2 mouse = Main.MouseWorld;

            Projectile.NewProjectile(source, spawnPos, velocity, ModContent.ProjectileType<Projectiles.Stone>(), damage, knockback, player.whoAmI);

            return false;
        }
    }
}
