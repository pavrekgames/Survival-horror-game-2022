using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour {

    private Inventory inventoryScript;
    private InventoryUI inventoryUIScript;
    private Player playerScript;

    [SerializeField] private Canvas hudCanvas;
    [SerializeField] private TextMeshProUGUI currenntItemTitle;
    [SerializeField] private Image currentItemIcon;
    private string currentItemText = "Item";

    [SerializeField] private Image staminaBar;
    private string defaultStaminaString = "#D2D7D7A7";
    private string tiredStaminaString = "#FF5A5ABA";
    private Color defaultStaminaColor;
    private Color tiredStaminaColour;

    void Start () {

        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
        inventoryUIScript = GameObject.Find("CanvasInventory").GetComponent<InventoryUI>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();

        ColorUtility.TryParseHtmlString(defaultStaminaString, out defaultStaminaColor);
        ColorUtility.TryParseHtmlString(tiredStaminaString, out tiredStaminaColour);

        staminaBar.color = defaultStaminaColor;

        inventoryUIScript.OnUsedItemFromSlot += UpdateHud;

    }

	void Update () {

        StaminaBar();

        if (Time.timeScale == 0)
        {
            hudCanvas.enabled = false;
        }
        else if (Time.timeScale == 1)
        {
            hudCanvas.enabled = true;
        }

    }

    void StaminaBar()
    {
        staminaBar.fillAmount = Player.currentStamina / Player.maxStamina;

        if (Player.currentStamina <= 0 && playerScript.isRest == true)
        {
            staminaBar.color = tiredStaminaColour;
        }
        else if (Player.currentStamina > 75 && playerScript.isRest == false)
        {
            staminaBar.color = defaultStaminaColor;
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
                currenntItemTitle.text = inventoryScript.items[i].itemName;
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
