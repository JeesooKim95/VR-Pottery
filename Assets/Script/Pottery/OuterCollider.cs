using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterCollider : MonoBehaviour
{
    public int index;
    BoxCollider boxCollider;

    private void Awake()
    {
        index = transform.GetSiblingIndex();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void ReduceCollider(float amount)
    {
        if(boxCollider.size.x - amount > 0.0f)
        {
            boxCollider.size = new Vector3(boxCollider.size.x - amount, boxCollider.size.y, boxCollider.size.z - amount);
        }
        else
        {
            Destroy(this);
        }
    }
}
