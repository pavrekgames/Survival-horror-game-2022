using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour {

    private Inventory inventoryScript;

    [SerializeField] private Canvas hudCanvas;
    [SerializeField] private TextMeshProUGUI currenntItemTitle;
    [SerializeField] private Image currentItemIcon;
    private string currentItemText = "Item";

    void Start () {
        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
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
        for (int i = 0; i < inventoryScript.items.Count; i++)
        {
            if (inventoryScript.items[i].isUsed == true)
            {
                currentItemIcon.sprite = inventoryScript.items[i].icon;
                currentItemIcon.color = Color.white;
                currenntItemTitle.text = inventoryScript.items[i].name;
            }
          
        }
    }

    void ResetHud()
    {
        currentItemIcon.sprite = null;
        currentItemIcon.color = Color.black;
        currenntItemTitle.text = currentItemText;
    }
}
