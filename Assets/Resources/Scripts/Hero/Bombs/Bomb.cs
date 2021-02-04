using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public delegate void OnBomb();
    public OnBomb BombFX;

    Model _model;
    public IBomb myBomb;
    float bombDuration;

    private void Start()
    {
        _model = transform.GetComponentInParent<Model>();
        new BombView(this);
    }

    private void Update()
    {
        Bombing();
    }

    public void Activate(bool b)
    {
        myBomb.BombModelSetter(this);
        myBomb.Reset();
        gameObject.SetActive(b);
    }

    void Bombing()
    {
        if (_model.bombing)
        {
            EventManager.TriggerEvent("Bombing");
            myBomb.Bomb(_model.transform.position);
            _model.dying = false;
            BombDuration();
        }
    }

    void BombDuration()
    {
        if (bombDuration < _model.bombMaxDuration)
        {
            bombDuration += 1 * Time.deltaTime;
            myBomb.Effect();
        }
        else
        {
            _model.bombing = false;
            Activate(false);
            bombDuration = 0;
        }
    }
}
