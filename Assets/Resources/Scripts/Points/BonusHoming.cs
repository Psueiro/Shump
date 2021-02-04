public class BonusHoming : IBonus
{
    Shot _mainShotBullet;
    Shot _secondaryShotBullet;
    Shot _focusShotBullet;

    public BonusHoming(Shot main, Shot secondary, Shot focus)
    {
        _mainShotBullet = main;
        _secondaryShotBullet = secondary;
        _focusShotBullet = focus;
    }

    public void Bonus(Model h)
    {
        h.ShotBulletSetter(_mainShotBullet, 50).SecondaryShotBulletSetter(_secondaryShotBullet).FocusBulletSetter(_focusShotBullet).SetBomb(new Seal()).SecondaryShotTypeSetter(new HomingShot(2,30,1.3f), new HomingShot(4,15,1.3f), new HomingShot(6,15,1.3f)).FocusShotTypeSetter(new HomingFocus(2,5,1.3f), new HomingFocus(4, 5, 1.3f), new HomingFocus(6, 5, 1.3f)).MaxSpeedSetter(6).BombsSetter(2).MainShotCooldownSetter(0.1f).SecondaryCooldownSetter(0.7f).FocusCooldownSetter(0.7f).DamageSetter(0.5f).BombDamageSetter(2).HitboxSetter(0.08f).BombDurationSetter(1);
    }
}
