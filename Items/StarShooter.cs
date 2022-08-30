using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
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
            Item.DamageType = DamageClass.Magic;//Damage type (Melee, Magic, etc)
            Item.damage = 10;//Damage of item
            Item.knockBack = 2.5f;//knockback of item
            Item.height = 28;//height of item sprite
            Item.width = 28;//widht of item sprite
            Item.useTime = 5;//how fast it can be used in 60 frames (so 60/5 = 12 a second)
            Item.useAnimation = 5;//
            //Item.UseSound = SoundID.Item1;//what sound is used while using this item
            Item.useStyle = ItemUseStyleID.HoldUp;//how the item is used (eating, mowing, swinging, etc)
            Item.shoot = ModContent.ProjectileType<Projectiles.Stone>();//if a projectile is shot, and what type
            Item.autoReuse = true;//allows the item to autoswing
            Item.noMelee = true;//disables the item from dealing damage (like swords)
            Item.shootSpeed = 1;//speed of fired projectile
            Item.value = Item.sellPrice(silver: 50);//value of the item
            Item.rare = 2;//rarity of the item
            Item.mana = 2;//mana cost of the item
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 spawnPos = new(Main.MouseWorld.X + Main.rand.Next(-100, 100), player.position.Y + Main.rand.Next(-800, -600));
            Vector2 mouse = Main.MouseWorld;

            Projectile.NewProjectile(source, spawnPos, velocity, ModContent.ProjectileType<Projectiles.Stone>(), damage, knockback, player.whoAmI);

            return false;//disabled any vanilla excecuted code from being run, but runs code from above
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.StoneBlock, 50)
                .AddIngredient(ItemID.HellstoneBar, 7)
                .AddIngredient(ItemID.FallenStar, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
        public override bool? UseItem(Player player)
        {
            Vector2 dustPos2 = new(player.Center.X + Main.rand.NextFloat(-5, 5), player.Center.Y + Main.rand.NextFloat(-15, 10));
            for (int i = 0; i < 7; i++)
            {
                Dust dust = Main.dust[Dust.NewDust(dustPos2, 0, 0, DustID.GoldFlame, 0, 0)];
                dust.noLight = true;

            }
            return base.UseItem(player);
        }
    }
}
