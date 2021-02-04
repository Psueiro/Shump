using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour, IMenuSelection
{
    public ShotTypeSetter shotTypeSetter;
    public App app;
    public void Highlight()
    {
        transform.GetComponent<Text>().color = Color.white;
    }

    public void MenuOption()
    {
        shotTypeSetter = Instantiate(shotTypeSetter);
        Model _hero = app.model;
        shotTypeSetter.MainShotBulletSetter(_hero.myShot).SecondaryShotBulletSetter(_hero.mySecondaryShot).FocusShotBulletSetter(_hero.myFocusShot).SetBomb(_hero.bomb.myBomb).MainShotSetter(_hero.allMainShots[0], _hero.allMainShots[1], _hero.allMainShots[2]).SecondaryShotSetter(_hero.allSecondaryShots[0], _hero.allSecondaryShots[1], _hero.allSecondaryShots[2]).FocusShotSetter(_hero.allFocusShots[0], _hero.allFocusShots[1], _hero.allFocusShots[2]).SpeedSetter(_hero.maxSpeed).LivesSetter(_hero.maxLives).BombsSetter(_hero.maxBombs).MainShotCooldownSetter(_hero.maxCooldown).SecondaryCooldownSetter(_hero.secMaxCooldown).FocusCooldownSetter(_hero.focMaxCooldown).DamageSetter(_hero.damage).BombDamageSetter(_hero.bombDamage).HitboxSetter(_hero.boxC.bounds.size.x).BombDurationSetter(_hero.bombMaxDuration);
        EventManager.ClearAllEvents();
        SceneManager.LoadScene("Level");
        _hero.score = 0;
        Time.timeScale = 1;
    }

    public void Unhighlight()
    {
        transform.GetComponent<Text>().color = Color.black;
    }
}
