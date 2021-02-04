using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShotSelector : MonoBehaviour, IMenuSelection
{
    public ShotTypeSetter shotTypeSetter;
    public Shot[] shotBullets = new Shot[3];
    public float speed;
    public int lives;
    public int bombs;
    public float cooldown;
    public float secCooldown;
    public float focCooldown;
    public float damage;
    public float bombDamage;
    public float hitboxSize;
    public float bombDuration;

    public ShotSetter shotSetter;

    public void Highlight()
    {
        transform.GetComponent<Text>().color = Color.white;
    }

    public void MenuOption()
    {
        if (gameObject.activeSelf)
        {
            shotTypeSetter = Instantiate(shotTypeSetter);
            shotSetter.SetShots();
            shotTypeSetter.MainShotSetter(new NormalShot(1, 5), new NormalShot(3, 5), new NormalShot(5, 5)).SetBomb(shotSetter.bomb).SecondaryShotSetter(shotSetter.allshots[0], shotSetter.allshots[1], shotSetter.allshots[2]).FocusShotSetter(shotSetter.allshots[3], shotSetter.allshots[4], shotSetter.allshots[5]).SpeedSetter(speed).LivesSetter(lives).BombsSetter(bombs).MainShotCooldownSetter(cooldown).SecondaryCooldownSetter(secCooldown).FocusCooldownSetter(focCooldown).DamageSetter(damage).BombDamageSetter(bombDamage).HitboxSetter(hitboxSize).BombDurationSetter(bombDuration).MainShotBulletSetter(shotBullets[0]).SecondaryShotBulletSetter(shotBullets[1]).FocusShotBulletSetter(shotBullets[2]);
            EventManager.ClearAllEvents();
            SceneManager.LoadScene("Level");
        }
    }

    public void Unhighlight()
    {
        transform.GetComponent<Text>().color = Color.grey;
    }
}
