using UnityEngine;
using System.Collections;

public class StartPoint : MonoBehaviour
{

    private Transform trans;
    private GameObject player;
    private bool isStartSet = false;
    private AudioListener audioListener;

    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        audioListener = GameObject.Find("PlayerCamera").GetComponent<AudioListener>();
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        if (!isStartSet)
        {

            if (!PlayerInstance.isRespown)
            {
                isStartSet = true;
                return;
            }

            if (player != null)
            {

                GameObject start = null;

                if (PlayerInstance.startNr != null && !PlayerInstance.startNr.Equals(""))
                {

                    start = GameObject.FindGameObjectWithTag(PlayerInstance.startNr);
                }

                Vector3 position = trans.position;

                if (start != null)
                {
                    position = start.GetComponent<Transform>().position;
                }

                player.GetComponent<Transform>().position = position;

                isStartSet = true;
                audioListener.enabled = true;
            }
        }
    }
}
