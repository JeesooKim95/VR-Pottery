using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Play : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(LoadPlay);
    }

    void LoadPlay()
    {
        SceneManager.LoadScene("Main Level");
    }
}
