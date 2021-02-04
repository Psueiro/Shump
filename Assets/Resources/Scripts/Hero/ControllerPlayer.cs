using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer :IController
{
    Model _model;

    public ControllerPlayer(Model m)
    {
        _model = m;
    }

    public void OnUpdate()
    {
        if (Input.GetKey(KeyCode.Z)) _model.Shoot();
        if (Input.GetKeyDown(KeyCode.X)) { _model.CallBomb();}
        if (Input.GetKey(KeyCode.UpArrow) && _model.transform.position.y < 6f) { _model.Move(Vector3.up);}
        if (Input.GetKey(KeyCode.DownArrow) && _model.transform.position.y > -4.25f) _model.Move(-Vector3.up);
        if (Input.GetKey(KeyCode.LeftArrow) && _model.transform.position.x > -10f) _model.Move(-Vector3.right);
        if (Input.GetKey(KeyCode.RightArrow) && _model.transform.position.x < 4.65f) _model.Move(Vector3.right);
        if (Input.GetKeyDown(KeyCode.Escape)) _model.Pause();
        if (Input.GetKeyDown(KeyCode.LeftShift)) _model.FocusMode();
        if (Input.GetKeyUp(KeyCode.LeftShift)) _model.SpreadMode();
    }
}
