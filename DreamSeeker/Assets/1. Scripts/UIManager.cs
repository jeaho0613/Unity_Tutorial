using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class UIManager : MonoBehaviour
{
    // Ani 효과 텍스트
    public Text text1;
    public Text text2;

    // Fade 효과 변수
    public SpriteRenderer fade;

    // sound 
    public AudioSource typing;

    void Start()
    {
        StartCoroutine(Text1());
        Invoke("Text2", 5);
    }
    
    IEnumerator Text1()
    {
        typing.PlayDelayed(0.5f);
        text1.DOText("[ jae ho games ]", 4, true, ScrambleMode.All);
        yield return new WaitForSeconds(3f);
        typing.Stop();
    }

    void Text2()
    {
        text2.DOText("#1", 1, true).SetEase(Ease.Linear);
        text2.DOColor(RandomColor(), 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear)
            .OnStepComplete(() =>
            {
                fade.DOFade(1, 5);
            });
    }

    Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
}

