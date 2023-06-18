using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSwitcher : MonoBehaviour
{
    private int currentLanguageIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void NextLanguage()
    {
        currentLanguageIndex--;
    }

    public void PrevLanguage()
    {
        currentLanguageIndex++;
    }
}
