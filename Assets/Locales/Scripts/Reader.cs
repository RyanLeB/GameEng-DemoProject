using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]

public class Language
{
    public string lang;
    public string title;
    public string play;
    public string quit;
    public string options;
    public string credits;
    
}


public class LanguageData
{
    public Language[] languages;
}


public class Reader : MonoBehaviour
{
    public TextAsset jsonFile;
    public LanguageData languageData;
    public string currentLanguage;

    public Text titleText;
    public Text playText;
    public Text quitText;
    public Text optionsText;
    public Text creditsText;

    public void Start()
    {
        languageData = JsonUtility.FromJson<LanguageData>(jsonFile.text);
        SetLanguage(currentLanguage);
        
    }
    
    public void SetLanguage(string newLanguage)
    {
        
        foreach (Language language in languageData.languages)
        {
            if (language.lang.ToLower() == newLanguage.ToLower())
            {
                titleText.text = language.title;
                playText.text = language.play;
                quitText.text = language.quit;
                optionsText.text = language.options;
                creditsText.text = language.credits;
                
                return;
            }
        }
    }
    
}
