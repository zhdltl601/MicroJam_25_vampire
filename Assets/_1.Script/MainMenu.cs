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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PopUI();
        }
    }

    private void PopUI()
    {
        if (uiStack.Count > 1)
        {
            var r = uiStack.Pop();
            r.SetActive(false);
        }
    }
    private void AddUIToStack(GameObject gameObject)
    {
        uiStack.Push(gameObject);
        gameObject.SetActive(true);
    }

    public void OnStart()
    {
        SceneManager.LoadScene("IntroScene");
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
