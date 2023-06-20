using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHealthController : MonoBehaviour
{
    float minimalWidth = 0;
    [SerializeField] float maximumWidth;
    [SerializeField] float maximumHealth;
    [SerializeField] float currentHealth;
    [SerializeField] Transform heatlhPanel;
    [SerializeField] RectTransform healthTransform;
    Animator doorAnimator;

    [SerializeField] SoundManager soundManager;
    AudioSource hitDoorSound;



    int currentDamage;

    public event Action HealthReachedZero = delegate { };

    public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }




    void Awake()
    {
        doorAnimator = transform.GetComponent<Animator>();
    }

    void Start()
    {
        hitDoorSound = soundManager.FindSound("HitWood");
    }


    public void VisualizeOreHealth()
    {
        
    }

    public void DealDamage()
    {
        //Debug.Log(currentDamage);
        doorAnimator.Play("DoorHit");
        int damage = 100;
        Debug.Log("current health is " + currentHealth);
        Debug.Log("current width is " + maximumWidth);
        currentHealth -= damage;
        Debug.Log("current health is " + currentHealth);
        Debug.Log("current maximumhealth is " + maximumHealth);
        float leftHealthPercent = ((currentHealth) / maximumHealth) * 100;
        //Debug.Log("hello there");

        leftHealthPercent = Mathf.Clamp(leftHealthPercent, 0, 100);
        Debug.Log("left percent is " + leftHealthPercent);
        int updatedWidth = (int)(leftHealthPercent * maximumWidth / 100);
        Debug.Log("updated width is " + updatedWidth);
        StartCoroutine(SmoothHealthDecrease(updatedWidth));
    }

    IEnumerator SmoothHealthDecrease(float updatedWidth)
    {
        float counter = 0;
        float smoothingDuration = 0.15f;
        float initialWidth = healthTransform.rect.width;
        float currentWidth = initialWidth;
        while (counter < smoothingDuration)
        {
            counter += Time.deltaTime;
            currentWidth = Mathf.Lerp(initialWidth, updatedWidth, counter / smoothingDuration);
            //Debug.Log(currentWidth);
            healthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, currentWidth);
            yield return null;
        }
        healthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, updatedWidth);
        if (currentHealth <= 0)
        {
            //crystalBehavior.DestroyCrystal();
            //if (HealthReachedZero != null) { HealthReachedZero(); }
        }
        yield return null;
    }

    public void UpdateOreHealth()
    {
        float leftHealthPercent = ((currentHealth) / maximumHealth) * 100;
        //Debug.Log(currentHealth);
        //Debug.Log(leftHealthPercent);
        leftHealthPercent = Mathf.Clamp(leftHealthPercent, 0, 100);
        int updatedWidth = (int)(leftHealthPercent * maximumWidth / 100);
        healthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, updatedWidth);
    }


    public void RefillHP()
    {
        currentHealth = maximumHealth;

        healthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maximumWidth);
    }


}
