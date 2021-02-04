using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour, IMenu
{
    int _selectedOption;
    public IMenuSelection current;
    protected IController controller;

    protected virtual void Start()
    {
        controller = new ControllerMainMenu(this);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<IMenuSelection>();
        }
        current = transform.GetChild(_selectedOption).GetComponent<IMenuSelection>();
        current.Highlight();
    }

    protected virtual void Update()
    {
        controller.OnUpdate();
    }

    public void MoveUp()
    {
        if (transform.GetChild(_selectedOption).gameObject.activeSelf)
        {
            if (_selectedOption == 0)
                _selectedOption = transform.childCount - 1;
            else _selectedOption--;
            Highlighting();
        }
    }

    public void MoveDown()
    {
        if (transform.GetChild(_selectedOption).gameObject.activeSelf)
        {
            if (_selectedOption == transform.childCount - 1)
            _selectedOption = 0;
            else _selectedOption++;
            Highlighting();
        }
    }

    void Highlighting()
    {
        if (transform.GetChild(_selectedOption).gameObject.activeSelf)
        {
            current = transform.GetChild(_selectedOption).GetComponent<IMenuSelection>();

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<IMenuSelection>().Unhighlight();
            }
            current.Highlight();
        }
    }

    public void Select()
    {
        current.MenuOption();
    }
}
