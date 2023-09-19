using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayRotation : MonoBehaviour
{
    public float speed;
    private Transform clayTransform;

    void Start()
    {
        clayTransform = gameObject.transform;
    }

    void Update()
    {
        clayTransform.Rotate(new Vector3(0, 1, 0)* Time.deltaTime * speed);
    }
}
