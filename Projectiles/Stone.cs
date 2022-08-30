using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace ModName.Projectiles
{
    public class Stone : ModProjectile
    {
        public override string Texture => "ModName/Projectiles/Stone";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Stone");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.RockGolemRock);
            Projectile.damage = 20;
            Projectile.friendly = true;
            Projectile.knockBack = 2f;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.aiStyle = 0;
            Projectile.scale = Main.rand.NextFloat(1f, 2.25f);
            Projectile.rotation = Main.rand.Next(0, 180);
        }
        public override void Kill(int timeLeft)
        {

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            int i = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 0), Main.rand.Next(0, 30) == 0 ? ProjectileID.SolarWhipSwordExplosion : ProjectileID.Flames, 20, 0, Main.player[Projectile.owner].whoAmI);
            SoundEngine.PlaySound(SoundID.DD2_KoboldExplosion);
        }
        public override void AI()
        {
            //Projectile.rotation = 0;

            if (++Projectile.velocity.Y > 20)
            {
                Projectile.velocity.Y = 20;
                Dust flamedust = Main.dust[Dust.NewDust(Projectile.Center, 0, 0, DustID.GoldFlame, 0, 0)];
                flamedust.scale = 1.35f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < Main.rand.Next(1, 8); ++i)
            {
                Dust stonedust = Main.dust[Dust.NewDust(Projectile.Center, 0, 0, DustID.Stone, 0, 0)];
                stonedust.scale = Main.rand.NextFloat(1f, 2.25f);
            }
            SoundEngine.PlaySound(SoundID.Tink, Projectile.Center);
            return base.OnTileCollide(oldVelocity);
        }
    }
}
