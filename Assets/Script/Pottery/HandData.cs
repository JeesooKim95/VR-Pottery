using System.Collections.Generic;
using UnityEngine;

public class HandData : MonoBehaviour
{
    public enum HandType { Right, Left};

    public HandType type;
    public Transform root;
    public Animator anim;
    public Transform[] fingerBones;
}
