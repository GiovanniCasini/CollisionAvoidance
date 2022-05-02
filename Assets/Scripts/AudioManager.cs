using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    Sound currentlyPlaying;
    Sound soundPaused;
    bool paused = false;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("menu");

        Play("buildUp");
    }

    public void Pause(string soundToPause, string soundToStart)
    {
        Sound sToPause = Array.Find(sounds, sound => sound.name == soundToPause);
        Sound sToStart = Array.Find(sounds, sound => sound.name == soundToStart);

        if (sToPause == null)
        {
            return;
        }
        if (sToStart == null)
        {
            return;
        }

        sToPause.source.Pause();
        sToStart.source.Play();

        soundPaused = sToPause;
        currentlyPlaying = sToStart;
        paused = true;
    }

    private void Update()
    {
        if (paused)
        {
            if (!currentlyPlaying.source.isPlaying)
            {
                soundPaused.source.Play();
                paused = false;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
}
