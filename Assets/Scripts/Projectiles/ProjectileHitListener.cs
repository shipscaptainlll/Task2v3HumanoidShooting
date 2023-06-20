using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitListener : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] BoxCollider collider;
    [SerializeField] ParticleSystem hitParticles;
    public SoundManager soundManager;
    Coroutine AutoDestroyCoroutine;

    // Start is called before the first frame update
    void Awake()
    {
        AutoDestroyCoroutine = StartCoroutine(AutoDestruction(5));
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with " + other);
        if (other.gameObject.GetComponent<TrainingDummyBehavior>() != null)
        {
            other.gameObject.GetComponent<TrainingDummyBehavior>().RecieveHit();
            HitDestruction();
        } else if (other.gameObject.tag == "Wood")
        {
            HitDestruction();
            soundManager.Play("HitWood");
        } else if (other.gameObject.tag == "Stone")
        {
            HitDestruction();
            soundManager.Play("HitStone");
        } else if (other.gameObject.tag == "Tree")
        {
            HitDestruction();
            soundManager.Play("HitTree");
        } else if (other.gameObject.tag == "Grass")
        {
            HitDestruction();
            soundManager.Play("HitDirt");
        } else if (other.gameObject.tag == "FenceDoor")
        {
            other.gameObject.GetComponent<DoorHealthController>().DealDamage();
            HitDestruction();
            //soundManager.Play("HitDirt");
        }
    }

    void HitDestruction()
    {
        if (AutoDestroyCoroutine != null) { StopCoroutine(AutoDestroyCoroutine); }
        meshRenderer.enabled = false;
        collider.enabled = false;
        hitParticles.Play();
        AutoDestroyCoroutine = StartCoroutine(AutoDestruction(1.2f));
    }

    IEnumerator AutoDestruction(float delay)
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
