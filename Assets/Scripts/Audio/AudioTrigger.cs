using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioManager MAudio;

    // Start is called before the first frame update
    void Start()
    {
        MAudio = FindObjectOfType<AudioManager>();
    }

    public void PlayClip(string clip_)
    {
        if (MAudio)
        {
            MAudio.Play(clip_);
        }
    }

    public void FadeOut(string clip_)
    {
        if (MAudio){ MAudio.FadeOut(clip_); }
    }

    public void FadeIn(string clip_)
    {
        if (MAudio) { MAudio.FadeIn(clip_); }
    }
}
