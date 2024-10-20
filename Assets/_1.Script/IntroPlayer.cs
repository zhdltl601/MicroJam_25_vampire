using DG.Tweening;
using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroPlayer : MonoBehaviour
{
    [Header("UI_SetUp")]
    [SerializeField] private TextMeshProUGUI _tmSubtitle;
    [SerializeField] private Image _image;
    [SerializeField] private Image _fade;

    [SerializeField] private List<SO_Intro> _introSequence = new();
    private int currentIndex = -1;
    private bool isAvailable = false;
    private void Awake()
    {
        _fade.gameObject.SetActive(true);
        Next();
        Fade(0, 1, callback: () => { isAvailable = true; print("ended"); });
    }
    private void Start()
    {
        AudioManager.Instance.StopSound(1);
    }
    private void Fade(int targetValue, float duration, Action startFunc = null, Action callback = null)
    {
        isAvailable = false;
        
        startFunc?.Invoke();
        
         _fade.DOFade(targetValue, duration).OnComplete(() =>
        {
           callback?.Invoke();
        });
       
    }
    private void Update()
    {
        if (isAvailable)
        {
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.S))
            {
                Next();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                OnEnd();
            }
        }
    }
    private void OnEnd()
    {
        Fade(1, 2, callback: () =>
        {
            SceneManager.LoadScene("GameScene");
        });
    }
    private void Next()
    {
        currentIndex++;
        if (currentIndex >= _introSequence.Count)
        {

            OnEnd();
            return;
        }
        SO_Intro currentIntro = _introSequence[currentIndex];
        SetCurrentIntro(currentIntro);
    }
    private void SetCurrentIntro(SO_Intro currentIntro)
    {
        _image.sprite = currentIntro.GetSprite;
        _tmSubtitle.text = currentIntro.GetText;
    }
}
