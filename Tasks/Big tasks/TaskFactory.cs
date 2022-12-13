using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFactory : MonoBehaviour {

    public bool isPlaySound = false;

    private Transform player;
    private Notifications notificationScript;

    [Header("Objects")]
    [SerializeField] private Transform lever;
    [SerializeField] private Light energyLight;
    [SerializeField] private Animator grillesAnimator;
    [SerializeField] private Transform grilles;

    [Header("Audio")]
    [SerializeField] private AudioSource leverAudioSource;
    [SerializeField] private AudioSource grillesAudioSource;
    [SerializeField] private AudioClip leverSound;
    [SerializeField] private AudioClip grillesSound;

    [Header("Objects states")]
    public bool isHasEnergy = false;
    public bool isLever = false;
    public bool isNotification = false;
    public string notificationString = "No energy...";

    void Start()
    {
        player = GameObject.Find("Player").transform;
        lever = GameObject.Find("FactoryLever").transform;
        energyLight = GameObject.Find("EnergyLight").GetComponent<Light>();
        notificationScript = GameObject.Find("Player").GetComponent<Notifications>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, lever.position);

        if (isHasEnergy == false && leverAudioSource.isPlaying == false && isNotification == true && distance <= 11)
        { 
            isNotification = true;
        }
        else if (distance > 11 && isNotification == true)
        { 
            isNotification = false;
        }
        else if (isHasEnergy == true)
        {
            energyLight.color = Color.green;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Collider>().gameObject.name == "LeverTrigger" && isHasEnergy == false)
        {
            LeverNotification();
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "LeverTrigger" && isHasEnergy == true && isLever == false)
        {
            OpenGate();
        }
    }

    void LeverNotification()
    {
        leverAudioSource.clip = leverSound;
        leverAudioSource.Play();
        isNotification = true;
    }

    void OpenGate()
    {
        leverAudioSource.clip = leverSound;
        leverAudioSource.Play();
        grillesAudioSource.clip = grillesSound;
        grillesAudioSource.Play();
        isLever = true;
        grillesAnimator.SetTrigger("OpenGate");
    }
}
