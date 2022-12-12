using UnityEngine;
using System.Collections;

public class InterfaceInstance : MonoBehaviour
{

    public static InterfaceInstance instance;

    void Awake()
    {

        if (!instance)
        {

            DontDestroyOnLoad(this.gameObject);

            instance = this;
        }
        else
        {

            Destroy(this.gameObject);
        }

    }
}
