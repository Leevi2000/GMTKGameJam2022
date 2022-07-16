using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{

    public string takeFrom;
    public string deliverTo;

    public bool delivering;


    // Start is called before the first frame update
    void Start()
    {
        delivering = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Factory")
        {
            if(collision.gameObject.name == takeFrom && takeFrom == null && delivering == false)
            {
                delivering = true;
            }
            if(collision.gameObject.name == deliverTo && delivering == true)
            {
                CompleteQuest();   
            }
        }
    }

    private void CompleteQuest()
    {

    }
}
