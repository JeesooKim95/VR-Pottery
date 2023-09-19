using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryData : MonoBehaviour
{
    public GameObject[] _collection;
    [SerializeField]
    private int index = 0;

    public static GalleryData instance;
    public Button_Reset reset;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SaveToCollection(GameObject _go)
    {
        if(reset == null)
        {
            Transform game_menu = GameObject.Find("GameMenu").transform;
            Transform canvas = game_menu.Find("Canvas").transform;
            Transform option = canvas.Find("Option").transform;
            reset = option.Find("Reset Button").gameObject.GetComponent<Button_Reset>();
            //reset = GameObject.FindGameObjectWithTag("Reset").GetComponent<Button_Reset>();
        }
        if(index == 0)
        {
            DontDestroyOnLoad(_go);
            _collection[index] = _go;
            _go.SetActive(false);
            reset.ResetDontDelete();
            index++;
        }
        else if(_collection[index - 1] != _go)
        {
            DontDestroyOnLoad(_go);
            _collection[index] = _go;
            _go.SetActive(false);
            reset.ResetDontDelete();
            index++;
        }
    }
}
