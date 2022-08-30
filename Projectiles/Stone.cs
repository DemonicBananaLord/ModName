using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ModName.Projectiles
{
    public class Stone : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Stone");
        }
        public override void SetDefaults()
        {
            Projectile.damage = 1000;
            Projectile.friendly = true;
            Projectile.knockBack = 2f;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.DamageType = DamageClass.Summon;
        }
        public override void Kill(int timeLeft)
        {
            int i = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 0), ProjectileID.SolarWhipSwordExplosion, 500, 2f);
        }
    }
}
