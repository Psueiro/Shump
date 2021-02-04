using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMainMenu : IController
{
    IMenu _menu;

    public ControllerMainMenu(IMenu m)
    {
        _menu = m;
    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) _menu.MoveUp();
        if (Input.GetKeyDown(KeyCode.DownArrow)) _menu.MoveDown();
        if (Input.GetKeyDown(KeyCode.Z)) _menu.Select();
    }
}
