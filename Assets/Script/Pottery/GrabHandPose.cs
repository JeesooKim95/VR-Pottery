using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabHandPose : MonoBehaviour
{
    public HandData lefthand_select;

    private Vector3 start_hand_pos;
    private Vector3 final_hand_pos;

    private Quaternion start_hand_rot;
    private Quaternion final_hand_rot;

    private Quaternion[] start_finger_rot;
    private Quaternion[] final_finger_rot;

    void Start()
    {
        Debug.Log("initialzing custom hand grab pose");
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractableTwoAttach>();

        grabInteractable.selectEntered.AddListener(CustomSelectPose);
        grabInteractable.selectExited.AddListener(ResetPose);

        lefthand_select.gameObject.SetActive(false);
    }

    public void CustomSelectPose(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            Debug.Log("Custom Selection Activated");
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            handData.anim.enabled = false;

            SetHandData(handData, lefthand_select);
            SetPose(handData, final_hand_pos, final_hand_rot, final_finger_rot);
        }
    }

    public void ResetPose(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            handData.anim.enabled = true;

            SetPose(handData, start_hand_pos, start_hand_rot, start_finger_rot);
        }
    }

    public void SetHandData(HandData hand1, HandData hand2)
    {
        Debug.Log("Hand Data Set");
        start_hand_pos = new Vector3(hand1.root.localPosition.x / hand1.root.localScale.x, 
            hand1.root.localPosition.y / hand1.root.localScale.y,
            hand1.root.localPosition.z / hand1.root.localScale.z );
        final_hand_pos = new Vector3(hand2.root.localPosition.x / hand2.root.localScale.x,
            hand2.root.localPosition.y / hand2.root.localScale.y,
            hand2.root.localPosition.z / hand2.root.localScale.z);

        start_hand_rot = hand1.root.localRotation;
        final_hand_rot = hand2.root.localRotation;

        int num_start_fingers = hand1.fingerBones.Length;
        start_finger_rot = new Quaternion[num_start_fingers];
        final_finger_rot = new Quaternion[num_start_fingers];

        for (int i = 0; i < num_start_fingers; i++)
        {
            start_finger_rot[i] = hand1.fingerBones[i].localRotation;
            final_finger_rot[i] = hand2.fingerBones[i].localRotation;
        }

    }

    public void SetPose(HandData hand, Vector3 newPos, Quaternion newRot, Quaternion[] newFingerRot)
    {
        hand.root.localPosition = newPos;
        hand.root.localRotation = newRot;

        for (int i = 0; i < newFingerRot.Length; i++)
        {
            hand.fingerBones[i].localRotation = newFingerRot[i];
        }
    }
}
