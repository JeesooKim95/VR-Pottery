using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public Clay clay;
    [SerializeField] private float amount = 0.00001f;

    public void SetNewClay(Clay new_clay)
    {
        clay = new_clay;
    }

    
        //if (right.PushAction.action.IsPressed() && left.PullAction.action.IsPressed()
        //            && left.CenterCutAction.action.IsPressed() && right.CenterCutAction.action.IsPressed())
        //{

        //    if (collision.collider.GetComponent<ClayCollider>() != null && collision.collider.CompareTag("OuterCollider"))
        //    {
        //        Debug.Log("Center CUT");
        //        collision.collider.GetComponent<ClayCollider>().ReduceCenter(amount);
        //        clay.Increase(collision.collider.GetComponent<ClayCollider>().index, amount);
        //    }
        //}
    
}
