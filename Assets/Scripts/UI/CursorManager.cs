using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] PanelsOpener panelsOpener;
    bool somethingOpened;

    public bool SomethingOpened
    {
        get
        {
            return somethingOpened;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        panelsOpener.PanelsUpdated += CheckSomethingOpened;
        Cursor.lockState = CursorLockMode.Locked;
        somethingOpened = false;
    }

    public static void ForceCursorEnabled()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public static void ForceCursorDisabled()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CheckSomethingOpened()
    {
        if (panelsOpener.CurrentlyOpened != null)
        {
            Cursor.lockState = CursorLockMode.Confined;
            somethingOpened = true;
        }
        else { Cursor.lockState = CursorLockMode.Locked; somethingOpened = false; }
    }
}
