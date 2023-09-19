using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Save : MonoBehaviour
{
    public Button_Reset reset;
    private GalleryData _gd;
    private Button button;

    private GameObject current_clay;
    [SerializeField]
    private int last_id = 0;
    [SerializeField]
    private int current_id = 1;

    void Start()
    {
        current_clay = GameObject.FindGameObjectWithTag("Clay");
        button = GetComponent<Button>();
        _gd = GameObject.FindGameObjectWithTag("GalleryData").GetComponent<GalleryData>();
        button.onClick.AddListener(Save);
    }

    void Update()
    {

    }

    public void Save()
    {
        current_clay = GameObject.FindGameObjectWithTag("Clay"); 
        _gd.SaveToCollection(current_clay);        
    }
}
