using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneCode : MonoBehaviour
{
    [SerializeField]
    string nextScene;

    public GameObject panel;

    void Start()
    {
        StartCoroutine(GoToNextScene());
    }

    IEnumerator GoToNextScene()
    {
        yield return new WaitForSeconds(28f);
        panel.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(nextScene);
    }
}
