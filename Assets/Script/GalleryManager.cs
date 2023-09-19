using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryManager : MonoBehaviour
{
    public Transform[] pos;
    private int index = 0;
    [SerializeField]
    private GalleryData _gd;
    public static GalleryManager instance;

    void Start()
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
        _gd = GameObject.FindGameObjectWithTag("GalleryData").GetComponent<GalleryData>();
    }    

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Main Level")
        {
            for (int i = 0; i < _gd._collection.Length; i++)
            {
                if (_gd._collection[i] != null)
                {
                    _gd._collection[i].SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < _gd._collection.Length; i++)
            {
                if (_gd._collection[i] != null)
                {
                    _gd._collection[i].SetActive(true);
                    _gd._collection[i].transform.position = pos[i].transform.position;
                }
            }
        }        
    }
}
