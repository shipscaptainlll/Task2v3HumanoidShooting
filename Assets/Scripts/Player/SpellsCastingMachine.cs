using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellsCastingMachine : MonoBehaviour
{
    [SerializeField] Transform firePosition;
    [SerializeField] float projectileSpeed;
    [SerializeField] Transform projectile;

    [SerializeField] ParticleSystem aoeParticles;

    [SerializeField] SoundManager soundManager;
    AudioSource spellCast;

    // Start is called before the first frame update
    void Start()
    {
        spellCast = soundManager.FindSound("CastMagic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CastSpell()
    {
        Transform newProjectile = Instantiate(projectile, firePosition.position, Quaternion.identity);
        newProjectile.GetComponent<ProjectileHitListener>().soundManager = soundManager;
        newProjectile.GetComponent<Rigidbody>().velocity = firePosition.forward * projectileSpeed;
        aoeParticles.Play();
        spellCast.Play();
        //Vector2 calculatedVelocities = CalculateVelocities();
        //ShootAmmo(calculatedVelocities.x, calculatedVelocities.y);
    }

    /*
    void ShootAmmo(float xVelocity, float yVelocity)
    {
        Transform newAmmo = Instantiate(catapultAmmo);
        newAmmo.position = shootingStart.position;
        newAmmo.GetComponent<Rigidbody>().velocity = transform.forward * yVelocity + -transform.right * xVelocity;
        newAmmo.GetComponent<CatapultAmmo>().CastleHealthDecreaser = castleHealthDecreaser;
    }

    Vector2 CalculateVelocities()
    {
        Vector2 calculatedVelocities;
        Vector3 initialPosition = shootingStart.position;
        Vector3 finalPosition = catapultMovement.FireTarget.position;
        float Distance = Vector3.Distance(initialPosition, finalPosition);
        float gravity = Physics.gravity.y;
        float tangAngle = Mathf.Tan(45 * Mathf.Deg2Rad);
        float height = finalPosition.y - initialPosition.y;
        float xVelocity = Mathf.Sqrt(gravity * Distance * Distance / (2f * (height - Distance * tangAngle)));
        float yVelocity = tangAngle * xVelocity;
        calculatedVelocities = new Vector2(xVelocity, yVelocity);
        return calculatedVelocities;
    }


    public void CheckNotFiring()
    {
        isFiring = false;
    }
    */
}
