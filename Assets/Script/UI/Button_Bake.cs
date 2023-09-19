using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Bake : MonoBehaviour
{
    public GameObject fcb;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //button.onClick.AddListener(Bake);
    }

    public void Bake()
    {

        GameObject clay = GameObject.FindGameObjectWithTag("Clay");

        if(clay != null)
        {
            SkinnedMeshRenderer skinnedMr = clay.GetComponent<SkinnedMeshRenderer>();
            GameObject leftHand = GameObject.FindGameObjectWithTag("LeftHand");
            GameObject righHand = GameObject.FindGameObjectWithTag("RightHand");

            leftHand.GetComponent<LeftHand>().is_molding = false;
            righHand.GetComponent<RightHand>().is_molding = false;
            fcb.SetActive(true);
            clay.GetComponent<Clay>().SetBaked();
        }
    }
}
