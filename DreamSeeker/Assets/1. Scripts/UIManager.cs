using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public Text text1;
    public Text text2;
    
    void Start()
    {
        text1.DOText("Jae Ho Games #1", 5, true, ScrambleMode.All)
            .OnStepComplete(() =>
            {
                text2.DOText("Unity.", 2, true).SetAutoKill(false);
                text2.DOColor(RandomColor(), 1.5f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Flash);
            });
    }

    Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
}

