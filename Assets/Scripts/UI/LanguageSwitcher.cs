using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageSwitcher : MonoBehaviour
{
    private int languagesCount;
    private int currentLanguageIndex;

    void Awake()
    {
        languagesCount = LocalizationSettings.AvailableLocales.Locales.Count;
        currentLanguageIndex = LocalizationSettings.AvailableLocales.Locales.IndexOf(LocalizationSettings.SelectedLocale);
    }


    public void NextLanguage()
    {
        currentLanguageIndex--;

        if (currentLanguageIndex < 0)
        {
            currentLanguageIndex = languagesCount - 1;
        }
        
        SetGameLanguage(currentLanguageIndex);
    }

    public void PrevLanguage()
    {
        currentLanguageIndex++;

        if (currentLanguageIndex > 5)
        {
            currentLanguageIndex = 0;
        }

        SetGameLanguage(currentLanguageIndex);
    }

    public void SetGameLanguage(int currentIndex)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentIndex];
        PlayerPrefs.SetString("selected-locale", LocalizationSettings.SelectedLocale.ToString());
    }
}
