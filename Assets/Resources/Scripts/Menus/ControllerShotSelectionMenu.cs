using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerShotSelectionMenu : IController
{
    ShotSelectionMenu _menu;

    public ControllerShotSelectionMenu(ShotSelectionMenu m)
    {
        _menu = m;
    }

    public void OnUpdate()
    {
        if(!_menu.active)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) _menu.MoveUp();
            if (Input.GetKeyDown(KeyCode.LeftArrow)) _menu.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!_menu.active)
            {
                _menu.active = true;
                _menu.Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.X)) _menu.Back();
    }
}
