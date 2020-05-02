using System;
using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public AudioSource myAudio;
	// Use this for initialization
	void Awake () {
		foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            myAudio = s.source;
            s.source.clip = s.clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.Loop;
        }
    }
	
	public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "doesn't exist!");
            return;
        }
        s.source.Play(); 
        
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "doesn't exist!");
            return;
        }
        s.source.Stop();

    }

    public bool PlayOther(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if ( s == null)
        {
            Debug.LogWarning("Sound" + name + "doesn't exist!");
            
        }
        s.source.Play();

        if (!s.source.isPlaying)
        {
            return true;
        }
        else { return false; }
    }

    public void Volume(string name, float vol)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "doesn't exist!");

        }
        s.source.volume = vol;
    }

    public void FadeIn(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "doesn't exist!");

        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(FadeIn(s));
        }
    }

    public void FadeOut(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "doesn't exist!");

        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(FadeOut(s));
        }
    }

    IEnumerator FadeOut(Sound clip)
    {
        while (clip.source.volume >= 0)
        {
            clip.source.volume -= 0.01f;
            yield return new WaitForSeconds(.1f); 
        }

        Stop(clip.name);
    }

    IEnumerator FadeIn(Sound clip)
    {
        float finalVol = clip.source.volume;

        PlayOther(clip.name);
        clip.source.volume = 0;

        while (clip.source.volume >= 0 && clip.source.volume <= finalVol)
        {
            clip.source.volume += 0.01f;
            yield return new WaitForSeconds(.1f);
        }
    }
}
