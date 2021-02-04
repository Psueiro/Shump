using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShotType 
{
    void Shoot();
    IShotType SetModel(Model model);
    void CallBullet(Vector3 pos, int startingNum);
}
