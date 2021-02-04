using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletPatterns 
{
    void BulletPattern();
    IBulletPatterns SetTransform(Transform t);
    IBulletPatterns SetBulletSpawner(BulletSpawner b);
}
