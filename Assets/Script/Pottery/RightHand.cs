using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightHand : MonoBehaviour
{
    public InputActionProperty PushAction;
    public InputActionProperty PullAction;
    public InputActionProperty CenterCutAction;

    private GameObject ClayOBJ;
    public Clay clay;

    public bool is_molding = true;

    [SerializeField] private float amount = 0.00001f;

    private void Awake()
    {
        ClayOBJ = GameObject.FindGameObjectWithTag("Clay");
        clay = ClayOBJ.GetComponent<Clay>();
    }

    public void SetNewClay(Clay new_clay)
    {
        clay = new_clay;
    }

    private void Update()
    {
        if (!ClayOBJ.active)
        {
            ClayOBJ = GameObject.FindGameObjectWithTag("Clay");
            clay = ClayOBJ.GetComponent<Clay>();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (is_molding)
        {
            if (collision.collider.GetComponent<ClayCollider>() != null && collision.collider.CompareTag("OuterCollider"))
            {
                if (PushAction.action.IsPressed())
                {
                    if (CenterCutAction.action.IsPressed())
                    {
                        ClayCollider child_collider = collision.collider.GetComponentInChildren<ClayCollider>();
                        child_collider.ReduceCenterCollider(amount, collision.collider.GetComponent<BoxCollider>().size.x);
                        clay.ReduceCenter(child_collider.index + 42, amount);
                    }
                    else
                    {
                        collision.collider.GetComponent<ClayCollider>().ReduceCollider(amount);
                        clay.Reduce(collision.collider.GetComponent<ClayCollider>().index, amount);
                    }
                }
                else if (PullAction.action.IsPressed())
                {
                    if (CenterCutAction.action.IsPressed())
                    {
                        ClayCollider child_collider = collision.collider.GetComponentInChildren<ClayCollider>();
                        child_collider.IncreaseCenterCollider(amount);
                        clay.IncreaseCenter(child_collider.index + 42, amount);
                    }
                    else
                    {
                        collision.collider.GetComponent<ClayCollider>().IncreaseCollider(amount);
                        clay.Reduce(collision.collider.GetComponent<ClayCollider>().index + 21, amount);
                    }
                }
            }
        }
    }
}
