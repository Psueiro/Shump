using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour, IMenuSelection
{
    public void Highlight()
    {
        transform.GetComponent<Text>().color = Color.white;
    }

    public void MenuOption()
    {
        Application.Quit();
    }

    public void Unhighlight()
    {
        transform.GetComponent<Text>().color = Color.black;
    }
}
