using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundsManager : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    AudioSource walkGrassSound;
    AudioSource walkWoodSound;

    // Start is called before the first frame update
    void Start()
    {
        walkGrassSound = soundManager.FindSound("WalkGrass");
        walkWoodSound = soundManager.FindSound("WalkWood");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateWalkSound()
    {
        GameObject groundUnderneath = ReturnObjectUnderneath();
        if (groundUnderneath == null) return;
        if (groundUnderneath.tag == "Wood")
        {
            walkWoodSound.Play();
        } else if (groundUnderneath.tag == "Grass")
        {
            walkGrassSound.Play();
        }
        
    }

    GameObject ReturnObjectUnderneath()
    {
        Collider[] hitcollider;
        hitcollider = Physics.OverlapSphere(groundCheck.position, checkRadius);
        if (hitcollider.Length > 0)
        {
            return hitcollider[0].gameObject;
        }
        else
        {
            return null;
        }
    }
}
