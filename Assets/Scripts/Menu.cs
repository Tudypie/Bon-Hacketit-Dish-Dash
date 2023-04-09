using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    bool gameIsStarted = false;

    [SerializeField] private UnityEvent onMenuActive;
    [SerializeField] private UnityEvent onStartGame;

    void Start()
    {
        onMenuActive?.Invoke();
    }

    void Update()
    {
        if(gameIsStarted)
            return;

        if(!Input.anyKey)
            return;

        gameIsStarted = true;

        onStartGame?.Invoke();

    }
}
