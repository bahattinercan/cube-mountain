using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    public event Action OnCollectCube;

    public event Action OnLoseCube;

    public event Action<bool> OnGameFinished;

    public event Action OnPlayerLanding;

    private void Awake()
    {
        Instance = this;
    }

    public void OnCollectCube_Invoke()
    {
        OnCollectCube?.Invoke();
    }

    public void OnLoseCube_Invoke()
    {
        OnLoseCube?.Invoke();
    }

    public void OnGameFinished_Invoke(bool isWin)
    {
        OnGameFinished?.Invoke(isWin);
        //Time.timeScale = 0;
    }

    public void OnPlayerLanding_Invoke()
    {
        OnPlayerLanding?.Invoke();
    }
}