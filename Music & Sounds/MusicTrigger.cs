using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour {

    private Music musicScript;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip music;
    [SerializeField] private float musicVolume;
    [SerializeField] private bool musicLoopState;

    public enum TriggerType
    {
        TriggerEnter,
        TriggerExit
    }

    public TriggerType triggerType;

    public bool isPlay;

    void Start()
    {
        musicScript = GameObject.Find("Player").GetComponent<Music>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggerType == TriggerType.TriggerEnter)
        {
            if (other.gameObject.CompareTag("Player") && isPlay == false)
            {
                musicScript.PlayMusic(audioSource, music, musicVolume, musicLoopState);
                isPlay = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (triggerType == TriggerType.TriggerExit)
        {
            if (other.gameObject.CompareTag("Player") && isPlay == false)
            {
                musicScript.PlayMusic(audioSource, music, musicVolume, musicLoopState);
                isPlay = true;
            }
        }
    }
}
