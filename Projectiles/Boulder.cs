using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModName.Projectiles
{
    public class Boulder : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{(int)ProjectileID.Boulder}";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Boulder");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Boulder);
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 9;
        }
        public override void AI()
        {
            if (++Projectile.velocity.Y >= 28)
            {
                Projectile.velocity.Y = 28;

            }
            //if (Projectile.velocity.Y == 0)
            {
                Projectile.rotation++;
            }
            
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < Main.rand.Next(4, 9); i++)
            {
                Dust boulderDust = Main.dust[Dust.NewDust(Projectile.Center + new Vector2(Main.rand.Next(0, 3), Main.rand.Next(0, 3)), 0, 0, DustID.Stone, 0, 0)];
                boulderDust.scale = Main.rand.NextFloat(1f, 2.25f);
            }
            SoundEngine.PlaySound(SoundID.Item70, Projectile.Center);
            if (++Projectile.velocity.X > 10)
            {
                Projectile.velocity.X = 10;
            }
            Projectile.velocity = Vector2.Zero;
            return true;//TODO: boulders rolling not giving earrape
        }
    }
}
