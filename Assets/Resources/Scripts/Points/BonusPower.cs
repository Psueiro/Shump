public class BonusPower : IBonus
{
    Shot _mainShotBullet;
    Shot _secondaryShotBullet;
    Shot _focusShotBullet;

    public BonusPower(Shot main, Shot second, Shot focus)
    {
        _mainShotBullet = main;
        _secondaryShotBullet = second;
        _focusShotBullet = focus;
    }

    public void Bonus(Model h)
    {
        h.ShotBulletSetter(_mainShotBullet, 50).SecondaryShotBulletSetter(_secondaryShotBullet).FocusBulletSetter(_focusShotBullet).SetBomb(new Magicannon()).SecondaryShotTypeSetter(new PowerShot(0.2f, 0.5f), new PowerShot(0.2f, 0.35f), new PowerShot(0.2f, 0.2f)).FocusShotTypeSetter(new PowerFocus(0.2f,0.3f), new PowerFocus(0.2f, 0.25f), new PowerFocus(0.2f, 0.2f)).MaxSpeedSetter(8).BombsSetter(3).MainShotCooldownSetter(0.05f).SecondaryCooldownSetter(0.3f).DamageSetter(2).BombDamageSetter(1).HitboxSetter(0.1f).BombDurationSetter(0.7f);
    }
}
