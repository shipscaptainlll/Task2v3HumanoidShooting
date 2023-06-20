using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] UserInputListener userInputListener;
    [SerializeField] LayerMask targetLayer;

    //[SerializeField] SoundManager soundManager;

    //public event Action CoinClicked = delegate { };

    // Start is called before the first frame update
    void Awake()
    {
        userInputListener.LMBClicked += InspectObject;
    }

    void Start()
    {
        //crystalHit = soundManager.FindSound("CrystalHit");
    }

    void InspectObject()
    {
        Transform foundObject = FindObjectUnderMouse();
        if (foundObject == null)
        {
            Debug.Log("No object found");
            return;
        }
        /*
        if (foundObject.GetComponent<CoinRotation>() != null)
        {
            CoinClicked?.Invoke();
        } 
        */
    }


    Transform FindObjectUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hit = Physics.RaycastAll(ray);
        foreach (RaycastHit hitElement in hit)
        {
            if (targetLayer == (targetLayer | (1 << hitElement.collider.gameObject.layer)))
            {
                return hitElement.transform;
            }
            
        }
        return null;
    }
}
