using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool isSfxOn {get;private set;}
    public bool isMusicOn {get;private set;}
    void Awake()
    {
        instance = this;
        SettingManager.onMusicChanged += MusicChangedCallback;
        SettingManager.onSfxChanged += SFXChangedCallback;
    }

    private void SFXChangedCallback(bool obj)
    {
        isSfxOn = obj;
    }

    private void MusicChangedCallback(bool obj)
    {
        isMusicOn = obj;
    }

    void OnDestroy()
    {
        SettingManager.onMusicChanged -= MusicChangedCallback;
        SettingManager.onSfxChanged -= SFXChangedCallback;
    }
}
