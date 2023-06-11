using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxAudio;
    [SerializeField] private AudioSource musicAudio;
    [SerializeField] private Sound[] sounds;
    private static AudioManager instance = null;
    public static AudioManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        PlaySound(SoundType.MenuMusic);
        SetMusicVolume(0.2f);
        SetSfxVolume(0.5f);
    }
    public void PlaySound(SoundType soundType)
    {
        Sound sound = Array.Find(sounds, item => item.soundType == soundType);
        if (soundType == SoundType.BGMusic || soundType == SoundType.GameOver || soundType == SoundType.LevelComplete || soundType == SoundType.MenuMusic)
        {
            musicAudio.clip = sound.audioClip;
            musicAudio.Play();
        }
        else
        {
            sfxAudio.PlayOneShot(sound.audioClip);
        }
    }
    public float GetSfxVolume()
    {
        return sfxAudio.volume;
    }
    public void SetSfxVolume(float _volume)
    {
        sfxAudio.volume = _volume;
    }
    public float GetMusicVolume()
    {
        return musicAudio.volume;
    }
    public void SetMusicVolume(float _volume)
    {
        musicAudio.volume = _volume;
    }
    public void PauseMusic()
    {
        musicAudio.Pause();
    }
    public void ResumeMusic()
    {
        musicAudio.UnPause();
    }
}
public enum SoundType
{
    ButtonClick, PaddleBump, BrickBump, BrickBreak, LevelComplete, GameOver, BGMusic, MenuMusic, PickPowerUp
}
[Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip audioClip;
}
