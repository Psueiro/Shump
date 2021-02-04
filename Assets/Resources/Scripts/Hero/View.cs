using UnityEngine;

public class View 
{
    Model _model;
    BoxCollider2D _boxC;
    SpriteRenderer _sp;

    public View(Model m)
    {
        _model = m;
        _boxC = m.boxC;
        _sp = m.GetComponent<SpriteRenderer>();
        m.effects += Deactivate;
    }

    void Deactivate(bool b)
    {
        _boxC.enabled = b;
        _sp.enabled = b;

        if (!b) _model.StartCoroutine(_model.Respawning());
    }
}
