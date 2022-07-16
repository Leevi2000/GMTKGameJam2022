using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeTopText : MonoBehaviour
{
    public GameObject player;
    private Quests quest;

    public GameObject mainText;
    private TMP_Text tmProAbove;

    public GameObject timerText;
    private TMP_Text tmProBelow;

    public Sprite[] dices;
    public GameObject imageObject;
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        quest = player.GetComponent<Quests>();
        tmProAbove = mainText.GetComponent<TMP_Text>();
        tmProBelow = timerText.GetComponent<TMP_Text>();
        img = imageObject.GetComponent<Image>();
        img.enabled = false;
    }


    

    // Update is called once per frame
    void Update()
    {
        
        if(quest.questStatus == "active")
        {
            if(!quest.delivering)
            {
                tmProAbove.text = $"Load products from:";
                img.enabled = true;
                img.sprite = GetDiceSprite(int.Parse(quest.takeFrom[quest.takeFrom.Length - 1].ToString()));
                
            }
            else
            {
                tmProAbove.text = $"Deliver products to:";
                img.sprite = GetDiceSprite(int.Parse(quest.deliverTo[quest.deliverTo.Length - 1].ToString()));
            }
            tmProBelow.text = $"Time left: {Mathf.Floor(quest.timer)} s";
        }
        else if(quest.questStatus == "completed")
        {
            tmProAbove.text = $"Task completed!";
            tmProBelow.text = "Completed in time";
        }
        else if(quest.questStatus == "failed")
        {

            tmProAbove.text = $"Task failed!";
            tmProBelow.text = "Timer ran out";
          
        }
        else if (quest.questStatus == "inactive")
        {

            tmProAbove.text = "Welcome!";
            tmProBelow.text = "Rolling a route...";

        }
    }

    private Sprite GetDiceSprite(int diceNumber)
    {
        return dices[diceNumber - 1];
    }
}
