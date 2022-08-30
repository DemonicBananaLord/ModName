using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

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
            Item.DamageType = DamageClass.Summon;
            Item.damage = 10;
            Item.knockBack = 2.5f;
            Item.height = 28;
            Item.width = 28;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.UseSound = SoundID.Pixie;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.shoot = ModContent.ProjectileType<Projectiles.Stone>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 spawnPos = new(Main.MouseWorld.X, player.position.Y + Main.rand.Next(-600, -400));
            for (int k = 0; k <3; k++)
            {
                int i = Projectile.NewProjectile(player.GetSource_FromThis(), spawnPos, velocity, ModContent.ProjectileType<Projectiles.Stone>(), 50, 2.5f);
            }
            return true;
        }
    }
}
