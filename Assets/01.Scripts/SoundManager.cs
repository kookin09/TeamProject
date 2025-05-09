using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip bgmClip;
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header(" 볼륨 슬라이더 연결")]
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (bgmSlider != null)
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);

        if (sfxSlider != null)
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        //  BGM 시작
        if (bgmClip != null)
            PlayBGM(bgmClip);
    }

    //  BGM 재생
    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgmSource.isPlaying)
            bgmSource.Stop();

        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.Play();
    }

    //  효과음 재생
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    //  BGM 볼륨 제어
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    //  효과음 볼륨 제어
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
