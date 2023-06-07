using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Load_Scene(1, 2));
    }

    IEnumerator Load_Scene(int SceneIndex, float Duration)
    {
        yield return new WaitForSeconds(Duration);
        SceneManager.LoadScene(SceneIndex);
    }
}
