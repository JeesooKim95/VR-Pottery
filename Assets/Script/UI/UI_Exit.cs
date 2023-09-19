using UnityEngine;
using UnityEngine.UI;

public class UI_Exit : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Quitgame);
    }

    void Quitgame()
    {
        Application.Quit();
    }
}
