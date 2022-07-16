using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{

    public string takeFrom;
    public string deliverTo;

    public bool delivering;

    public float timerTime;
    public float timer;
    public bool timerRunning = false;

    public string questStatus = "inactive";
    public AudioSource clickSound;
    public ParticleSystem takeEffect;
    // Start is called before the first frame update
    void Start()
    {
        delivering = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerRunning)
        {
            timer = timer - Time.fixedDeltaTime;
        }
        if (timer < 0)
        {
            CompleteQuest(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Factory")
        {
            if(collision.gameObject.name == takeFrom && delivering == false)
            {
                delivering = true;
                timer = timerTime;
                takeEffect.Play();
                clickSound.Play();
            }
            if(collision.gameObject.name == deliverTo && delivering == true)
            {
                takeEffect.Play();
                clickSound.Play();
                CompleteQuest();   
            }
        }
    }

    public void StartQuest(string take, string destination)
    {
        takeFrom = take;
        deliverTo = destination;
        timer = timerTime;
        timerRunning = true;
        questStatus = "active";
    }

    private void CompleteQuest(bool failure = false)
    {
        timerRunning = false;
        takeFrom = "";
        deliverTo = "";
        delivering = false;

        if(failure)
        {
            questStatus = "failed";
        }
        else
        {
            questStatus = "completed";
        }
    }
}
