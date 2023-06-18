using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusicPlayer : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager.Play("Birds");
        soundManager.Play("VillageAmbient");
    }
}
