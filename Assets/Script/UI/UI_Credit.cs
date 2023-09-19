using UnityEngine;
using UnityEngine.UI;

public class UI_Credit : MonoBehaviour
{
    public GameObject credit;
    private Button button;
    private bool is_open = false;
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(LoadCredit);
    }

    void LoadCredit()
    {
        if (!is_open)
        {
            credit.SetActive(true);
            is_open = true;
        }
        else
        {
            credit.SetActive(false);
            is_open = false;
        }
    }
}
