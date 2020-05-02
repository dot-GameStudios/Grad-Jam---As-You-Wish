using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent OnStart;
    [SerializeField] private UnityEvent OnUpdate;

    [SerializeField] private AudioManager MAudio;
    [SerializeField] private string AudioClip;
    public bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        MAudio = FindObjectOfType<AudioManager>();
        OnStart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate.Invoke();    
    }

    public void PlaySound(string clipName_) {
        MAudio.Play(clipName_);
    }
}
