using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Transform lives;
    public Transform bombs;
    public Image power;
    public Text points;
    public Text powerLevel;
    public Image pause;
    public Image prompt;
    public App app;
    Model _model;
    bool _over;

    void Awake()
    {
        _model = app.model;
        EventManager.SubscribeToEvent("Death", OnDeath);
        EventManager.SubscribeToEvent("Bomb", OnBomb);
        EventManager.SubscribeToEvent("Pause", Pause);
        EventManager.SubscribeToEvent("Win", Win);
    }

    void Update()
    {
        Adder(_model.lives, lives);
        Adder(_model.bombs, bombs);
        power.fillAmount = _model.power / 60;
        powerLevel.text = "Power:" + _model.power;
        points.text = "Points:" + _model.score + " / 100";
    }

    void Adder(int a, Transform t)
    {
        for (int i = 0; i < a; i++)
        {
            t.GetChild(i).gameObject.SetActive(true);
        }        
    }

    void Remover(Transform t, int a)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
        {
            if (t.GetChild(i).gameObject.activeSelf)
            {
                t.GetChild(i).gameObject.SetActive(false);
                break;
            }
        }
    }

    public void Pause()
    {
        if(!_over)
        {
            pause.transform.gameObject.SetActive(!pause.transform.gameObject.activeSelf);
            if (Time.timeScale == 0) Time.timeScale = 1;
            else
                Time.timeScale = 0;
        }        
    }

    public void Win()
    {
        prompt.transform.gameObject.SetActive(true);
        prompt.GetComponentInChildren<Text>().text = "You win!";
        _over = true;
        Time.timeScale = 0;
    }
    public void Lose()
    {
        prompt.transform.gameObject.SetActive(true);
        prompt.GetComponentInChildren<Text>().text = "Game Over";
        _over = true;
        Time.timeScale = 0;
    }

    void OnDeath()
    {
        if (_model.lives > 0)
            Remover(lives, _model.lives);
        else Lose();
    }

    void OnBomb()
    {
        Remover(bombs, _model.bombs);
    }
}
