using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour {

    [SerializeField] private Canvas hudCanvas;
    [SerializeField] private TextMeshProUGUI currenntItemTitle;
    [SerializeField] private Image currentItemIcon;
    private string currentItemText = "Item";

    void Start () {
		
	}
	

	void Update () {

        if (Time.timeScale == 0)
        {
            hudCanvas.enabled = false;
        }
        else if (Time.timeScale == 1)
        {
            hudCanvas.enabled = true;
        }

    }

    void UpdateHud()
    {
        currentItemIcon.sprite = null;
        currentItemIcon.color = Color.black;
        currenntItemTitle.text = currentItemText;
    }
}
