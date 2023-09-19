using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerCollider : MonoBehaviour
{
    public int index;
    BoxCollider boxCollider;

    private void Awake()
    {
        index = transform.GetSiblingIndex();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void IncreaseCollider(float amount)
    {
        if (boxCollider.size.x + amount < 0.02f)
        {
            boxCollider.size = new Vector3(boxCollider.size.x + amount, boxCollider.size.y, boxCollider.size.z + amount);
        }
        else
        {
            Destroy(this);
        }
    }
}
