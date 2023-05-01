using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneCode : MonoBehaviour
{
    [SerializeField]
    string nextScene;

    void Start()
    {
        StartCoroutine(GoToNextScene());
    }

    IEnumerator GoToNextScene()
    {
        yield return new WaitForSeconds(28f);
        SceneManager.LoadScene(nextScene);
    }
}
