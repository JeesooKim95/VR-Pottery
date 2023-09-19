using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float duration = 2.0f;
    public Color color;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if(fadeOnStart)
        {
            FadeIn();
        }
    }


    public void FadeIn()
    {
        Transition(1, 0);
    }

    public void FadeOut()
    {
        Transition(0, 1);
    }

    public void Transition(float alpha_start, float alpha_end)
    {
        StartCoroutine(TransitionRoutine(alpha_start, alpha_end));
    }

    public IEnumerator TransitionRoutine(float alpha_start, float alpha_end)
    {
        float timer = 0.0f;
        while (timer <= duration)
        {
            Color lerpColor = color;
            lerpColor.a = Mathf.Lerp(alpha_start, alpha_end, timer / duration);

            rend.material.SetColor("_Color", lerpColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color finalColor = color;
        finalColor.a = alpha_end;
        rend.material.SetColor("_Color", finalColor);
    }
}
