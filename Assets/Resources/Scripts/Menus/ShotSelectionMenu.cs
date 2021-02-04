using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShotSelectionMenu : Menu
{
    public bool active;
    Character _retractCurrent;
    protected override void Start()
    {
        base.Start();
        controller = new ControllerShotSelectionMenu(this);
        Time.timeScale = 1;
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Back()
    {
        if (active)
        {
            if (current is Character)
                _retractCurrent = current as Character;
            _retractCurrent.Retract();
            active = false;
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
