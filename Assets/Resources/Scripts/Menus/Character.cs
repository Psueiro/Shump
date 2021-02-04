using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour, IMenuSelection
{
    Image _img;
    bool _highlighted;
    float speed = 50;
    float _visibility;

    void Start()
    {
        _img = GetComponent<Image>();
    }

    void Update()
    {
        if(_highlighted)
        {
            if(transform.localPosition.x > 150)
            Fade(1);
        }
        else
        {
            if(transform.localPosition.x < 200)
            Fade(-1);
        }
    }

    void Fade(int dir)
    {
        transform.position += transform.right * -dir * speed * Time.deltaTime;
        _visibility += dir * speed / 25 * Time.deltaTime;
        _img.color = new Color(_img.color.r, _img.color.g, _img.color.b, _visibility);
    }

    public void Highlight()
    {
        _highlighted = true;
    }

    public void Unhighlight()
    {
        _highlighted = false;
    }

    public void MenuOption()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }        
    }

    public void Retract()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
