using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresenceTarget : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    public Renderer nonPhysicalHand;
    public float distanceBetweenPhysicalHand = 0.05f;
    private Collider[] handColliders;
    private bool is_colliding = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandCollision()
    {
        foreach(var coll in handColliders)
        {
            coll.enabled = true;
        }
    }

    public void DelayEnableHandCollision(float delay)
    {
        Invoke("EnableHandCollision", delay);
    }

    public void DisbleHandCollsion()
    {
        foreach (var coll in handColliders)
        {
            coll.enabled = false;
        }
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);

        if(dist > distanceBetweenPhysicalHand)
        {
            nonPhysicalHand.enabled = true;
        }
        else
        {
            nonPhysicalHand.enabled = false;
        }
        
    }

    void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        Quaternion diff = target.rotation * Quaternion.Inverse(transform.rotation);
        diff.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 diffInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (diffInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
     
    }

}
