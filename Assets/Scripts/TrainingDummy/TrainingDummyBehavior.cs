using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummyBehavior : MonoBehaviour
{
    [SerializeField] Animator dummyAnimator;
    [SerializeField] ParticleSystem hitParticles;
    int animationIndexer;

    [SerializeField] SoundManager soundManager;
    AudioSource hitDummy;

    // Start is called before the first frame update
    void Start()
    {
        hitDummy = soundManager.FindSound("HitDummy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            RecieveHit();
        }
    }

    public void RecieveHit()
    {
        animationIndexer++;
        if (animationIndexer % 2 == 0)
        {
            dummyAnimator.CrossFade("Damaged_Small", 0.1f, 0);
        } else
        {
            dummyAnimator.CrossFade("Damaged_Big", 0.1f, 0);
        }
        hitDummy.Play();
        hitParticles.Play();
    }
}
