using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLaser : IBonus
{
    Shot _mainShotBullet;
    Shot _secondaryShotBullet;
    Shot _focusShotBullet;

    public BonusLaser(Shot main, Shot secondary, Shot focus)
    {
        _mainShotBullet = main;
        _secondaryShotBullet = secondary;
        _focusShotBullet = focus;
    }

    public void Bonus(Model h)
    {
        h.ShotBulletSetter(_mainShotBullet, 50).SecondaryShotBulletSetter(_secondaryShotBullet).FocusBulletSetter(_focusShotBullet).SetBomb(new Magicannon()).SecondaryShotTypeSetter(new LaserShot(2, 2.5f, 2, 1.3f, 0.6f), new LaserShot(2, 2.3f, 4, 1.7f, 0.6f), new LaserShot(2, 2.1f, 6, 2, 0.6f)).FocusShotTypeSetter(new LaserFocus(2, 2.3f, 4, 1.7f, 0.6f), new LaserFocus(1, 2.1f, 10, 2f, 0), new LaserFocus(1, 2f, 12, 1.95f, 0)).MaxSpeedSetter(8).BombsSetter(4).MainShotCooldownSetter(0.05f).SecondaryCooldownSetter(3f).FocusCooldownSetter(3).DamageSetter(2).BombDamageSetter(3).HitboxSetter(0.1f).BombDurationSetter(2);
    }
}
