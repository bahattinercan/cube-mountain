using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int totalGem;
    private int roundGem;
    private bool isPassedFinishLine;
    private int gemMultiplier;
    private int level;
    private int maxLevel = 5;
    [SerializeField] private int gemPoint;
    public Transform player;

    public event Action<int> OnScoreChanged;

    public int GemPoint { get => gemPoint; }
    public bool IsPassedFinishLine { get => isPassedFinishLine; set => isPassedFinishLine = value; }
    public int GemMultiplier { get => gemMultiplier; set => gemMultiplier = value; }
    public int RoundGem { get => roundGem; set => roundGem = value; }
    public int Level { get => level; set => level = value; }

    private void Awake()
    {
        instance = this;
        SetupPlayerPrefs();
        totalGem = PlayerPrefs.GetInt(EPlayerPrefs.totalGem.ToString());
        level = PlayerPrefs.GetInt(EPlayerPrefs.currentLevel.ToString());
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        RoundGem = 0;
        IsPassedFinishLine = false;
        GemMultiplier = 1;
        GameEvents.Instance.OnGameFinished += Instance_OnGameFinished;
        Application.targetFrameRate = 60;

        OnScoreChanged?.Invoke(totalGem);
    }

    private void SetupPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey(EPlayerPrefs.totalGem.ToString()))
            PlayerPrefs.SetInt(EPlayerPrefs.totalGem.ToString(), 0);

        if (!PlayerPrefs.HasKey(EPlayerPrefs.currentLevel.ToString()))
            PlayerPrefs.SetInt(EPlayerPrefs.currentLevel.ToString(), 1);

        if (!PlayerPrefs.HasKey(EPlayerPrefs.maxLevel.ToString()))
            PlayerPrefs.SetInt(EPlayerPrefs.maxLevel.ToString(), maxLevel);
    }

    private void Instance_OnGameFinished(bool obj)
    {
        if (isPassedFinishLine)
        {
            int thisRoundGem = roundGem * gemMultiplier;
            totalGem += (thisRoundGem - roundGem);
            PlayerPrefs.SetInt(EPlayerPrefs.totalGem.ToString(), totalGem);
        }
    }


    public void AddScore(int value)
    {
        totalGem += value;
        RoundGem += value;
        OnScoreChanged?.Invoke(totalGem);
    }

    public void LoadNextLevel()
    {
        level++;
        if (level >= maxLevel)
            level = 1;
        PlayerPrefs.SetInt(EPlayerPrefs.currentLevel.ToString(), level);
        SceneManager.LoadScene("Level" + level);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}