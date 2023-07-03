using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintsGenerator : MonoBehaviour
{
    [SerializeField] Transform footprintHolder;
    [SerializeField] Transform playerBody;
    [SerializeField] Transform leftFoot;
    [SerializeField] Transform rightFoot;
    [SerializeField] GameObject FootprintPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("x: " + playerBody.rotation.x + " y: " + playerBody.rotation.y + " z: " + playerBody.rotation.z);
    }

    public void GenerateLeftFootprint()
    {
        GameObject newFootprint = Instantiate(FootprintPrefab, leftFoot.position, Quaternion.identity, footprintHolder);
        newFootprint.GetComponent<ParticleSystem>().startRotation3D = new Vector3(newFootprint.GetComponent<ParticleSystem>().startRotation3D.x, 0, playerBody.rotation.y);
        newFootprint.GetComponent<ParticleSystem>().Play();
    }

    public void GenerateRightFootprint()
    {
        GameObject newFootprint = Instantiate(FootprintPrefab, rightFoot.position, Quaternion.identity, footprintHolder);
        newFootprint.GetComponent<ParticleSystem>().startRotation3D = new Vector3(newFootprint.GetComponent<ParticleSystem>().startRotation3D.x, 0, playerBody.rotation.y);
        newFootprint.GetComponent<ParticleSystem>().Play();
    }
}
