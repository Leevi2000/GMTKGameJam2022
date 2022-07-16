using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorPitch : MonoBehaviour
{

    private AudioSource audioSource;
    private TruckMovement truckScript;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        truckScript = GetComponent<TruckMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.pitch = 0.34f + (truckScript.currentSpeedByFrame * 10);
    }
}
