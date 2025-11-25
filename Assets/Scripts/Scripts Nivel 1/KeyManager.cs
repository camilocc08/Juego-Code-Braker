using UnityEngine;
using TMPro;
using System.Collections;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance;

    public int totalKeys = 3;      
    public int keysCollected = 0;  

    public TextMeshProUGUI keyText;  

    public GameObject rulesPopup;   

    private bool rulesShown = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddKey()
    {
        keysCollected++;
        UpdateUI();

        
        if (!rulesShown)
        {
            rulesShown = true;
            if (rulesPopup != null)
            {
                rulesPopup.SetActive(true);
                StartCoroutine(HideRulesAfterTime());
            }
        }
    }

    private IEnumerator HideRulesAfterTime()
    {
        yield return new WaitForSeconds(5f); 
        rulesPopup.SetActive(false);
    }

    private void UpdateUI()
    {
        if (keyText != null)
            keyText.text = keysCollected + " / " + totalKeys;
    }
}