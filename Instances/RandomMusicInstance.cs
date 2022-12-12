using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusicInstance : MonoBehaviour
{

    public static RandomMusicInstance instance;

    void Awake()
    {

        if (!instance)
        {

            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
