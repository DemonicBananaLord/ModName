using Microsoft.Xna.Framework;
using System.Security.Permissions;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModName.Items
{
    public class BoulderShooter : ModItem
    {
        public override string Texture => $"Terraria/Images/Item_{(int)ItemID.Boulder}";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boulder Shooter");
            Tooltip.SetDefault("Shoots Boulders from the stars" +
                "\nStone Shooter's big brother");
        }
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Magic;//Damage type (Melee, Magic, etc)
            Item.damage = 40;//Damage of item
            Item.knockBack = 5.5f;//knockback of item
            Item.height = 28;//height of item sprite
            Item.width = 28;//widht of item sprite
            Item.useTime = 5;//how fast it can be used in 60 frames (so 60/5 = 12 a second)
            Item.useAnimation = 5;//
            //Item.UseSound = SoundID.Item1;//what sound is used while using this item
            Item.useStyle = ItemUseStyleID.HoldUp;//how the item is used (eating, mowing, swinging, etc)
            Item.shoot = ModContent.ProjectileType<Projectiles.Boulder>();//if a projectile is shot, and what type
            Item.autoReuse = true;//allows the item to autoswing
            Item.noMelee = true;//disables the item from dealing damage (like swords)
            Item.shootSpeed = 1;//speed of fired projectile
            Item.value = Item.sellPrice(gold: 2);//value of the item
            Item.rare = 4;//rarity of the item
            Item.mana = 7;//mana cost of the item
            Item.crit = 4;//+4 default
            Item.scale = 3f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 spawnPos = new(Main.MouseWorld.X + Main.rand.Next(-100, 100), player.position.Y + Main.rand.Next(-800, -600));
            int i = Projectile.NewProjectile(source, spawnPos, velocity, ModContent.ProjectileType<Projectiles.Boulder>(), damage, knockback, player.whoAmI);
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<StarShooter>())
                .AddIngredient(ItemID.MeteoriteBar, 25)
                .AddIngredient(ItemID.Boulder, 3)
                .AddIngredient(ItemID.SoulofLight, 7)
                .AddIngredient(ItemID.SoulofSight, 7)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
