public class BonusFast : IBonus
{
    Shot _mainShotBullet;
    Shot _secondaryShotBullet;
    Shot _focusShotBullet;

    public BonusFast(Shot main, Shot secondary, Shot focus)
    {
        _mainShotBullet = main;
        _secondaryShotBullet = secondary;
        _focusShotBullet = focus;
    }

    public void Bonus(Model h)
    {
        h.ShotBulletSetter(_mainShotBullet, 50).SecondaryShotBulletSetter(_secondaryShotBullet).FocusBulletSetter(_focusShotBullet).SetBomb(new Seal()).SecondaryShotTypeSetter(new FastShot(1,0.5f), new FastShot(3, 0.5f), new FastShot(5, 0.5f)).FocusShotTypeSetter(new FastFocus(true, 0.9f,0.2f), new FastFocus(true, 0.9f,0.15f), new FastFocus(true, 0.9f,0.1f)).MaxSpeedSetter(6).BombsSetter(4).MainShotCooldownSetter(0.05f).SecondaryCooldownSetter(0.5f).DamageSetter(2).BombDamageSetter(1).HitboxSetter(0.08f).BombDurationSetter(0.7f);
    }
}
