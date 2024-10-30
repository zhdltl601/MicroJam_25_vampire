using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private readonly Stack<GameObject> uiStack = new();
    [SerializeField] private GameObject op;
    [SerializeField] private GameObject cr;
    [SerializeField] private AudioClip maniMenuBGM;
    private void Awake()
    {
        op.SetActive(false);
        cr.SetActive(false);
    }
    private void Start()
    {
        AudioManager.Instance.PlayOneShot(maniMenuBGM);
        //AudioManager.Instance.Play(maniMenuBGM);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PopUI();
        }
    }

    public void PopUI()
    {
        if (uiStack.Count >= 1)
        {
            var r = uiStack.Pop();
            r.SetActive(false);
        }
    }
    private void AddUIToStack(GameObject _gameObject)
    {
        uiStack.Push(_gameObject);
        _gameObject.SetActive(true);
    }

    public void OnStart()
    {
        SceneManager.LoadScene("Jung 2");
    }
    public void OnOption()
    {
        AddUIToStack(op);
    }
    public void OnCredit()
    {
        AddUIToStack(cr);
    }
}
