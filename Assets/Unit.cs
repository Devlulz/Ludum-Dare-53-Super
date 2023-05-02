using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unit : MonoBehaviour
{
    [SerializeField]
    int HP;

    [SerializeField]
    int maxHP = 10;

    [SerializeField]
    Material flash;

    [SerializeField]
    Material OGMat;
    [SerializeField]
    float duration;

    [SerializeField]
    SpriteRenderer sprite;

    private void Start()
    {
        HP = maxHP;
        Healthbar.Instance.slider.maxValue = maxHP;
        Healthbar.Instance.slider.value = HP;
    }

    public void TakeDMG(int DMG)
    {
        HP -= DMG;
        Healthbar.Instance.slider.value = HP;
        StartCoroutine(FlashEffect());
        CheckDeath();
    }

    void CheckDeath()
    {
        if(HP <= 0)
        {
            FuckingDie();
        }
    }

    void FuckingDie()
    {
        SceneManager.LoadScene("Dead");

    }

    IEnumerator FlashEffect()
    {
        sprite.material = flash;
        yield return new WaitForSeconds(duration);
        sprite.material = OGMat;
    }
}
