using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShotSelection : MonoBehaviour, IMenuSelection
{
    public void Highlight()
    {
        transform.GetComponent<Text>().color = Color.white;
    }

    public void MenuOption()
    {
        SceneManager.LoadScene("ShotSelection");
    }

    public void Unhighlight()
    {
        transform.GetComponent<Text>().color = Color.black;
    }
}
