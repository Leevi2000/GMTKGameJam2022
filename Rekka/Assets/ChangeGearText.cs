using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeGearText : MonoBehaviour
{
    public GameObject player;
    private TruckMovement movement;
    private TMP_Text tmPro;
    // Start is called before the first frame update
    void Start()
    {
        movement = player.GetComponent<TruckMovement>();
        tmPro = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tmPro.text = $"GEAR {movement.currentGear}";
    }
}
