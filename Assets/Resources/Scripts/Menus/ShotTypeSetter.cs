using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShotTypeSetter : MonoBehaviour
{
    List<IShotType> _mainShot;
    List<IShotType> _secondaryShot;
    List<IShotType> _focusShot;

    float _mainShotCD;
    float _secShotCD;
    float _focShotCD;
    float _speed;
    float _damage;
    float _bombDuration;
    float _hitboxSize;
    float _bombDamage;

    int _lives;
    int _bombs;

    Shot _mainShotBullet;
    Shot _secondaryShotBullet;
    Shot _focusShotBullet;

    IBomb myBomb;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        ShotSetter();
    }

    void ShotSetter()
    {
        if(SceneManager.GetActiveScene().name == "Level")
        {
            Model _hero = FindObjectOfType<App>().model;
            _hero.ShotBulletSetter(_mainShotBullet, 50).SecondaryShotBulletSetter(_secondaryShotBullet).FocusBulletSetter(_focusShotBullet).ShotTypeSetter(_mainShot[0], _mainShot[1], _mainShot[2]).SecondaryShotTypeSetter(_secondaryShot[0], _secondaryShot[1], _secondaryShot[2]).FocusShotTypeSetter(_focusShot[0],_focusShot[1],_focusShot[2]).MaxSpeedSetter(_speed).LivesSetter(_lives).BombsSetter(_bombs).MainShotCooldownSetter(_mainShotCD).SecondaryCooldownSetter(_secShotCD).FocusCooldownSetter(_focShotCD).DamageSetter(_damage).BombDamageSetter(_bombDamage).HitboxSetter(_hitboxSize).BombDurationSetter(_bombDuration).SetBomb(myBomb); 
            Destroy(gameObject);
        }
    }

    public ShotTypeSetter MainShotSetter(IShotType one, IShotType two, IShotType three)
    {
        //ShotLoad
        _mainShot = new List<IShotType>();
        _mainShot.Add(one);
        _mainShot.Add(two);
        _mainShot.Add(three);
        return this;
    }

    public ShotTypeSetter SecondaryShotSetter(IShotType one, IShotType two, IShotType three)
    {
        //ShotLoad
        _secondaryShot = new List<IShotType>();
        _secondaryShot.Add(one);
        _secondaryShot.Add(two);
        _secondaryShot.Add(three);
        return this;
    }

    public ShotTypeSetter FocusShotSetter(IShotType one, IShotType two, IShotType three)
    {
        //ShotLoad
        _focusShot = new List<IShotType>();
        _focusShot.Add(one);
        _focusShot.Add(two);
        _focusShot.Add(three);
        return this;
    }

    public ShotTypeSetter SetBomb(IBomb b)
    {
        myBomb = b;
        return this;
    }

    public ShotTypeSetter SpeedSetter(float spe)
    {
        _speed = spe;
        return this;
    }

    public ShotTypeSetter LivesSetter(int liv)
    {
        _lives = liv;
        return this;
    }

    public ShotTypeSetter BombsSetter(int bom)
    {
        _bombs = bom;
        return this;
    }

    public ShotTypeSetter MainShotCooldownSetter(float maxCD)
    {
        _mainShotCD = maxCD;
        return this;
    }

    public ShotTypeSetter SecondaryCooldownSetter(float maxSecCD)
    {
        _secShotCD = maxSecCD;
        return this;
    }

    public ShotTypeSetter FocusCooldownSetter(float maxFocCD)
    {
        _focShotCD = maxFocCD;
        return this;
    }

    public ShotTypeSetter DamageSetter(float dmg)
    {
        _damage = dmg;
        return this;
    }

    public ShotTypeSetter BombDamageSetter(float bombdmg)
    {
        _bombDamage = bombdmg;
        return this;
    }

    public ShotTypeSetter BombDurationSetter(float bombdur)
    {
        _bombDuration = bombdur;
        return this;
    }

    public ShotTypeSetter HitboxSetter(float i)
    {
        _hitboxSize = i;   
        return this;
    }

    public ShotTypeSetter MainShotBulletSetter(Shot s)
    {
        _mainShotBullet = s;
        return this;
    }
    public ShotTypeSetter SecondaryShotBulletSetter(Shot s)
    {
        _secondaryShotBullet = s;
        return this;
    }

    public ShotTypeSetter FocusShotBulletSetter(Shot s)
    {
        _focusShotBullet = s;
        return this;
    }
}
