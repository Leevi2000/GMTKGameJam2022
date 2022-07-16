using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceImage : MonoBehaviour
{
    public Sprite[] dices;
    GameObject imageObject;
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
    img = imageObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
