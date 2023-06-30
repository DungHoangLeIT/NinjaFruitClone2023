using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Boolean fadeIn = false;
    [SerializeField] private Boolean fadeOut = false;
    public void BombEnable()
    {
        fadeIn = true;
    }
    public void BombDisable()
    {
        fadeOut = true;
    }
    private void Update()
    {
        if (fadeIn)
        {
            if(canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
                if(canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
                if (canvasGroup.alpha == 1)
                {
                    fadeOut = false;
                }
            }
        }   
    }
}
