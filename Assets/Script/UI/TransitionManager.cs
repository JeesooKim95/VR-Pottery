using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public ScreenTransition transitionScreen;

    public void ChangeScene(int index)
    {
        StartCoroutine(ChangeSceneRoutine(index));
    }

    IEnumerator ChangeSceneRoutine(int index)
    {
        transitionScreen.FadeOut();
        yield return new WaitForSeconds(transitionScreen.duration);

        SceneManager.LoadScene(index);
        ///////////using async method
        //AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        //operation.allowSceneActivation = false;

        //float timer = 0;
        //while(timer <= transitionScreen.duration && !operation.isDone)
        //{
        //    timer += Time.deltaTime;
        //    yield return null;
        //}
        //operation.allowSceneActivation = true;
        ////////////////////////////////////////
    }
}
