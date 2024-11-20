using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocalizedTextComponent : MonoBehaviour
{
    
    [SerializeField] private string tableReference; // name of the table
    [SerializeField] private string localizationKey; // Key of the entry in the table


    private LocalizedString localizedString;
    private Text textComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
        localizedString = new LocalizedString { TableReference = tableReference, TableEntryReference = localizationKey };

        LocalizationSettings.SelectedLocaleChanged += UpdateText;
    }

    void OnDestroy()
    {
        LocalizationSettings.SelectedLocaleChanged -= UpdateText;
    }

    void UpdateText(Locale locale)
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<Text>();
        }
        textComponent.text = localizedString.GetLocalizedString(); // Actual translation logic is executed here
    }
}
