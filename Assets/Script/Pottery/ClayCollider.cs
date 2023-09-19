using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClayCollider : MonoBehaviour
{
    public int index;
    BoxCollider c_collider;

    // Start is called before the first frame update
    private void Awake()
    {
        //index = transform.GetSiblingIndex();
        c_collider = GetComponent<BoxCollider>();
    }

    public void ReduceCollider(float amount)
    {
        if (c_collider.size.x - amount >= 0.002f)
        {
            c_collider.size = new Vector3(c_collider.size.x - amount, c_collider.size.y, c_collider.size.z - amount);
        }
    }

    public void IncreaseCollider(float amount)
    {
        if (c_collider.size.x + amount <= 0.037f)
        {
            c_collider.size = new Vector3(c_collider.size.x + amount, c_collider.size.y, c_collider.size.z + amount);
        }
    }

    public void ReduceCenterCollider(float amount, float parent_size)
    {
        if (c_collider.size.x + amount < parent_size)
        {
            c_collider.size = new Vector3(c_collider.size.x + amount, c_collider.size.y, c_collider.size.z + amount);
        }
    }

    public void IncreaseCenterCollider(float amount)
    {
        if (c_collider.size.x - amount >= 0.001f)
        {
            c_collider.size = new Vector3(c_collider.size.x - amount, c_collider.size.y, c_collider.size.z - amount);
        }
    }
}
