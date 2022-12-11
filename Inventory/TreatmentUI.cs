using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreatmentUI : MonoBehaviour {

    public static bool isTreatmentActive = false;

    private InventoryUIManager inventoryUIManager;
    private Inventory inventoryScript;
    private Player playerScript;
    private CrosshairGUI cursorScript;
    private Health healthScript;

    [Header("Audio")]
    [SerializeField] private AudioSource itemAudioSource1;
    [SerializeField] private AudioSource itemAudioSource2;
    [SerializeField] private AudioSource itemAudioSource3;
    [SerializeField] private AudioSource pauseAudioSource;
    [SerializeField] private AudioClip menuButtonSound;
    [SerializeField] private AudioClip itemDesciptionSound;
    [SerializeField] private AudioClip openInventorySound;
    [SerializeField] private AudioClip createPotSound;
    [SerializeField] private AudioClip usePotSound;
    [SerializeField] private AudioClip lackVialsSound;

    [Header("UI")]
    [SerializeField] private Canvas treatmentCanvas;
    [SerializeField] private TextMeshProUGUI mixturesText;
    [SerializeField] private Text blueHerbsText;
    [SerializeField] private Text greenHerbsText;
    [SerializeField] private Text vialsCountText;
    [SerializeField] private Text healthPotsText;
    [SerializeField] private Text staminaPotsText;
    [SerializeField] private TextMeshProUGUI healthConditionText;

    [Header("Texts")]
    private string healthPotDescription = "Health Mixture  - Increase your health. You need 2 green herbs and 2 blue herbs to create it.";
    private string staminaPotDescription = "Stamina Mixture  - Increase your Stamina. You need 1 green herb and 2 blue herbs to create it.";
    private string stateGoodText = "<color=#08FF5BFF>Good</color>";
    private string stateInjuredText = "<color=#FFC117FF>Injured</color>";
    private string stateCriticalText = "<color=#FF4E26FF>Critical</color>";
    private string stateTiredText = "<color=#BF42C7FF>Tired</color>";
    private string lackComponentsText = "<color=#FF0000FF>You don't have enough herbs or a vial</color>";

    void Start()
    {
        inventoryUIManager = GameObject.Find("CanvasInventory").GetComponent<InventoryUIManager>();
        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        cursorScript = GameObject.Find("PlayerCamera").GetComponent<CrosshairGUI>();
        healthScript = GameObject.Find("Player").GetComponent<Health>();
    }

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isTreatmentActive == true)
        {
            TreatmentBackFunction();
        }
    }

    public void ShowTreatment()
    {
        inventoryUIManager.ResetUI();
        CheckHealthCondition();
        itemAudioSource2.PlayOneShot(menuButtonSound);
        treatmentCanvas.enabled = true;
        isTreatmentActive = true;
    }

    public void TreatmentBackFunction()
    {

        inventoryUIManager.ResetUI();

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;
    }

    public void ShowHealthPotDescription()
    {
        itemAudioSource2.PlayOneShot(itemDesciptionSound);
        mixturesText.text = healthPotDescription;
    }

    public void ShowStaminaPotDescription()
    {
        itemAudioSource2.PlayOneShot(itemDesciptionSound);
        mixturesText.text = staminaPotDescription;
    }

    public void CreateHealthPot()
    {

        if (inventoryScript.greenHerbsCount >= 2 && inventoryScript.blueHerbsCount >= 2 && inventoryScript.vialsCount > 0)
        {
            inventoryScript.greenHerbsCount -= 2;
            inventoryScript.blueHerbsCount -= 2;
            inventoryScript.vialsCount--;
            inventoryScript.healthPotsCount++;
            itemAudioSource1.PlayOneShot(createPotSound);
            healthPotsText.text = inventoryScript.healthPotsCount.ToString();
            greenHerbsText.text = inventoryScript.greenHerbsCount.ToString();
            blueHerbsText.text = inventoryScript.blueHerbsCount.ToString();
            vialsCountText.text = inventoryScript.vialsCount.ToString();
        }
        else
        {
            itemAudioSource2.PlayOneShot(lackVialsSound);
            mixturesText.text = lackComponentsText;
        }
    }

    public void CreateStaminaPot()
    {

        if (inventoryScript.greenHerbsCount >= 1 && inventoryScript.blueHerbsCount >= 2 && inventoryScript.vialsCount > 0)
        {
            inventoryScript.greenHerbsCount -= 1;
            inventoryScript.blueHerbsCount -= 2;
            inventoryScript.vialsCount--;
            inventoryScript.staminaPotsCount++;
            itemAudioSource2.PlayOneShot(createPotSound);
            staminaPotsText.text = inventoryScript.staminaPotsCount.ToString();
            greenHerbsText.text = inventoryScript.greenHerbsCount.ToString();
            blueHerbsText.text = inventoryScript.blueHerbsCount.ToString();
            vialsCountText.text = inventoryScript.vialsCount.ToString();
        }
        else
        {
            itemAudioSource2.PlayOneShot(lackVialsSound);
            mixturesText.text = lackComponentsText;
        }
    }

    public void UseHealthPot()
    {

        if (inventoryScript.healthPotsCount > 0)
        {
            inventoryScript.healthPotsCount--;
            healthScript.health += 50;
            itemAudioSource3.PlayOneShot(usePotSound);
            healthPotsText.text = inventoryScript.healthPotsCount.ToString();
        }
    }

    public void UseStaminaPot()
    {

        if (inventoryScript.staminaPotsCount > 0)
        {
            inventoryScript.staminaPotsCount--;
            Player.currentStamina += 60;
            itemAudioSource3.PlayOneShot(usePotSound);
            staminaPotsText.text = inventoryScript.staminaPotsCount.ToString();
        }
    }

    void CheckHealthCondition()
    {

        if (healthScript.health >= 70 && playerScript.isRest == true)
        {
            healthConditionText.text = stateGoodText;
        }
        else if (healthScript.health > 40 && healthScript.health < 70)
        {
            healthConditionText.text = stateInjuredText;
        }
        else if (healthScript.health <= 40)
        {
            healthConditionText.text = stateCriticalText;
        }
        else if (healthScript.health >= 70 && playerScript.isRest == false)
        {
            healthConditionText.text = stateTiredText;
        }

    }

    public void HoverButton()
    {

        itemAudioSource2.PlayOneShot(itemDesciptionSound);

    }

}
