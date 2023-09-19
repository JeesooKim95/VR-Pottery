using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Reset : MonoBehaviour
{
    public GameObject base_clay;
    public LeftHand left_hand;
    public RightHand right_hand;
    public Transform spawn_pos;
    public GameObject fcb;

    private GameObject current_clay;
    private int currentID = 0;
    private Button button;
    
    void Start()
    {
        current_clay = GameObject.FindGameObjectWithTag("Clay");
        button = GetComponent<Button>();
    }

    void Update()
    {
        //button.onClick.AddListener(Reset);
    }

    public void Reset()
    {
        Destroy(current_clay);
        GameObject new_base = Instantiate(base_clay, spawn_pos.position, Quaternion.identity);
        Clay new_clay = new_base.GetComponent<Clay>();
        //hand_manager.SetNewClay(new_clay);
        left_hand.SetNewClay(new_clay);
        right_hand.SetNewClay(new_clay);
        current_clay = new_base;
        
        GameObject leftHand = GameObject.FindGameObjectWithTag("LeftHand");
        GameObject righHand = GameObject.FindGameObjectWithTag("RightHand");

        leftHand.GetComponent<LeftHand>().is_molding = true;
        righHand.GetComponent<RightHand>().is_molding = true;

        fcb.SetActive(false);
        current_clay.GetComponent<Clay>().SetMold();
    }

    public void ResetDontDelete()
    {
        GameObject new_base = Instantiate(base_clay, spawn_pos.position, Quaternion.identity);
        Clay new_clay = new_base.GetComponent<Clay>();
        //hand_manager.SetNewClay(new_clay);
        left_hand.SetNewClay(new_clay);
        right_hand.SetNewClay(new_clay);
        current_clay = new_base;

        GameObject leftHand = GameObject.FindGameObjectWithTag("LeftHand");
        GameObject righHand = GameObject.FindGameObjectWithTag("RightHand");

        leftHand.GetComponent<LeftHand>().is_molding = true;
        righHand.GetComponent<RightHand>().is_molding = true;

        fcb.SetActive(false);
        current_clay.GetComponent<Clay>().SetMold();
        currentID++;
    }

    public int GetCurrentID()
    {
        return currentID;
    }
}
