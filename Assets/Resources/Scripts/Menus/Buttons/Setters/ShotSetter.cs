using UnityEngine;

public abstract class ShotSetter : ScriptableObject
{
        public IShotType[] allshots = new IShotType[6];
        public IBomb bomb;
        public abstract void SetShots();
}
