using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clay : MonoBehaviour
{
    public Material baked_mat;
    private FlexibleColorPicker fcb;
    private SkinnedMeshRenderer skinnedMR;
    private bool is_baked = false;
    private bool is_molding = true;

    private void Awake()
    {
        skinnedMR = gameObject.GetComponent<SkinnedMeshRenderer>();
    }

    public void Update()
    {
        if(is_baked && fcb != null)
        {
            skinnedMR.material.color = fcb.color;
        }
    }

    public void SetMold()
    {
        is_molding = true;
        is_baked = false;
    }

    public void SetBaked()
    {
        is_baked = true;
        is_molding = false;
        skinnedMR.material = baked_mat;
        fcb = GameObject.FindGameObjectWithTag("ColorPicker").GetComponent<FlexibleColorPicker>();
    }

    public void Reduce(int keyIndex, float amount)
    {
        float newValue = skinnedMR.GetBlendShapeWeight(keyIndex) + amount * (5.0f / 0.001f);
        if(newValue <= 100)
        {
            skinnedMR.SetBlendShapeWeight(keyIndex, newValue);
        }        
    }

    public void ReduceCenter(int keyIndex, float amount)
    {
        
        float newValue = skinnedMR.GetBlendShapeWeight(keyIndex) + amount * (5.0f / 0.001f);
        if (newValue <= 100)
        {
            skinnedMR.SetBlendShapeWeight(keyIndex, newValue);
            //if (keyIndex == 43)
            //{
            //    skinnedMR.SetBlendShapeWeight(keyIndex, newValue);
            //}
            //else
            //{
            //    int upperKey = keyIndex - 1;
            //    if (skinnedMR.GetBlendShapeWeight(upperKey) >= newValue)
            //    {
            //        skinnedMR.SetBlendShapeWeight(keyIndex, newValue);
            //    }                
            //}
        }
    }

    public void Increase(int keyIndex, float amount)
    {
        float newValue = skinnedMR.GetBlendShapeWeight(keyIndex) - amount * (5.0f / 0.001f);
        if(newValue >= 0)
        {
            skinnedMR.SetBlendShapeWeight(keyIndex, newValue);
        }
    }

    public void IncreaseCenter(int keyIndex, float amount)
    {

        float newValue = skinnedMR.GetBlendShapeWeight(keyIndex) - amount * (5.0f / 0.001f);
        if (newValue >= 0)
        {
            skinnedMR.SetBlendShapeWeight(keyIndex, newValue);
            //if (keyIndex == 43)
            //{
            //    skinnedMR.SetBlendShapeWeight(keyIndex, newValue);
            //}
            //else
            //{
            //    int upperKey = keyIndex - 1;
            //    if (skinnedMR.GetBlendShapeWeight(upperKey) >= newValue)
            //    {
            //        skinnedMR.SetBlendShapeWeight(keyIndex, newValue);
            //    }
            //}
        }
    }
}
