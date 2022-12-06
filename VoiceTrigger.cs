using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger : MonoBehaviour {

    private VoiceActing voiceActingScript;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip recording;

    public bool isVoice;

    public enum VoiceType
    {
        Voice,
        VoiceRetro
    }

    public VoiceType voiceType;

    void Start()
    {
        voiceActingScript = GameObject.Find("Player").GetComponent<VoiceActing>();
    }
	
    void OnTriggerEnter(Collider other)
    {
        if(isVoice == false)
        {
            if (other.gameObject.CompareTag("Player") && voiceType == VoiceType.Voice)
            {
                voiceActingScript.PlayVoice(audioSource, recording);
                isVoice = true;
            }
            else if(other.gameObject.CompareTag("Player") && voiceType == VoiceType.VoiceRetro)
            {
                voiceActingScript.PlayRetrospection(recording);
                isVoice = true;
            }
        }

       
    }

}
