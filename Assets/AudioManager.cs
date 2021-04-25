using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public const int DIALOG_LAUNCH = 0;
    public const int DIALOG_GOLD = 1;
    public const int DIALOG_DATA = 2;
    public const int DIALOG_ALCHEMIST = 3;
    public const int DIALOG_SCIENTIST = 4;
    public const int DIALOG_WEAPON = 5;

    public static AudioManager Instance { get; private set; }

    [Header("SFX")]
    public Sound[] SFX;

    [Header("Dialog")]
    public SoundGroup dialog;

    [Header("Music")]
    [SerializeField] AudioSource musicAudioSource;

    private bool someoneIsSpeaking = false;
    private float speakingDuration = 0f;

    //private DialogLimiter dialogLimiter;

    private float timeSinceLastReminder = 4f;
    private float reminderInterval = 5f;

    private void Awake()
    {
        //dialogLimiter = GetComponent<DialogLimiter>();
        SingletonPattern();
        CreateAudioSources(ref SFX);

        foreach (DialogCategory dc in dialog.dialogCategories)
        {
            CreateAudioSources(ref dc.dialogsOptions);
        }
    }

    private void SingletonPattern()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (speakingDuration < 0.0f)
        {
            someoneIsSpeaking = false;
        }
        else
        {
            speakingDuration -= Time.deltaTime;
        }

        timeSinceLastReminder += Time.deltaTime;
    }

    private void CreateAudioSources(ref Sound[] sounds)
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.source.Play();
    }

    public void PlaySFXLoop(string name)
    {
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.source.loop = true;
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
    }

    public void StopSFXLoop(string name)
    {
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.source.loop = false;
        s.source.Stop();
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void PlayDialog(int DIALOG_CATEGORY)
    {
        int maxOption = dialog.dialogCategories[DIALOG_CATEGORY].dialogsOptions.Length;
        int selectedOption = UnityEngine.Random.Range(0, maxOption);
        Sound s = dialog.dialogCategories[DIALOG_CATEGORY].dialogsOptions[selectedOption];

        if (someoneIsSpeaking)
        {
            return;
        }
        speakingDuration = s.source.clip.length;
        someoneIsSpeaking = true;

        s.source.Play();
    }

    public bool GetIsSomeoneSpeaking()
    {
        return someoneIsSpeaking;
    }
}

[System.Serializable]
public class SoundGroup
{
    public string name;
    public DialogCategory[] dialogCategories;
}

[System.Serializable]
public class DialogCategory
{
    public string name;
    public Sound[] dialogsOptions;
}
