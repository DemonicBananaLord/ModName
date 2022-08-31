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
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            if (++Projectile.velocity.Y >= 28)
            {
                Projectile.velocity.Y = 28;

            }
            if (Projectile.velocity.Y == 0)
            {
                Projectile.rotation++;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < Main.rand.Next(4, 9); i++)
            {
                Dust boulderDust = Main.dust[Dust.NewDust(Projectile.Center + new Vector2(Main.rand.Next(0, 3), Main.rand.Next(0, 3)), 0, 0, DustID.Stone, 0, 0)];
                boulderDust.scale = Main.rand.NextFloat(1f, 2.25f);
            }
            SoundEngine.PlaySound(SoundID.Item70, Projectile.Center);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            target.AddBuff(BuffID.Slow, 6 * 60);
            Main.player[Projectile.owner].addDPS(damage);//Fix for Boulder damage not adding up to DPS meter
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity == Vector2.Zero)
            {
                return true;
            }
            return Projectile.ai[0] > 30;
        }
    }
}
