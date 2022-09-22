using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum AudioTypes
    {
        collectCristal,
        collectCube,
        loseCube,
        loseGameMusic,
        winGameMusic,
        landing,
    }

    public static SoundManager instance;
    [SerializeField] private AudioClip loseGameMusic;
    [SerializeField] private AudioClip winGameMusic;
    [SerializeField] private AudioSource collectCristalAudio;
    [SerializeField] private AudioSource collectCubeAudio;
    [SerializeField] private AudioSource collectCubeAudio2;
    [SerializeField] private AudioSource loseCubeAudio;
    [SerializeField] private AudioSource landingAudio;
    [SerializeField] private AudioSource generalAudioSource;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        GameManager.instance.OnScoreChanged += Ýnstance_OnScoreChanged;
        GameEvents.Instance.OnCollectCube += Instance_OnCollectCube;
        GameEvents.Instance.OnLoseCube += Instance_OnLoseCube;
        GameEvents.Instance.OnGameFinished += Instance_OnGameFinished;
        GameEvents.Instance.OnPlayerLanding += Instance_OnPlayerLanding;
    }

    private void Instance_OnPlayerLanding()
    {
        PlayAudio(AudioTypes.landing);
    }

    private void Instance_OnGameFinished(bool obj)
    {
        if (obj || GameManager.instance.IsPassedFinishLine)
            PlayAudio(AudioTypes.winGameMusic);
        else
            PlayAudio(AudioTypes.loseGameMusic);
    }

    private void Instance_OnLoseCube()
    {
        PlayAudio(AudioTypes.loseCube);
    }

    private void Instance_OnCollectCube()
    {
        PlayAudio(AudioTypes.collectCube);
    }

    private void Ýnstance_OnScoreChanged(int obj)
    {
        PlayAudio(AudioTypes.collectCristal);
    }

    public void PlayAudio(AudioTypes audioType)
    {
        switch (audioType)
        {
            case AudioTypes.collectCristal:
                collectCristalAudio.Play();
                RandomizeSound(collectCristalAudio);
                break;

            case AudioTypes.collectCube:
                if (Random.Range(0, 2) == 1)
                {
                    collectCubeAudio.Play();
                    RandomizeSound(collectCubeAudio);
                }
                else
                {
                    collectCubeAudio2.Play();
                    RandomizeSound(collectCubeAudio2);
                }
                   
                break;

            case AudioTypes.loseCube:
                loseCubeAudio.Play();
                RandomizeSound(loseCubeAudio);
                break;

            case AudioTypes.loseGameMusic:
                generalAudioSource.PlayOneShot(loseGameMusic);
                break;

            case AudioTypes.winGameMusic:
                generalAudioSource.PlayOneShot(winGameMusic);
                break;

            case AudioTypes.landing:
                landingAudio.Play();
                RandomizeSound(landingAudio);
                break;
        }

    }

    private void RandomizeSound(AudioSource audioSource)
    {
        audioSource.pitch = Random.Range(.9f, 1.1f);
        audioSource.volume = Random.Range(.8f, 1f);
    }
}