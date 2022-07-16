using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour
{
    public int score;

    public GameObject player;
    private Quests playerQuest;



    // Start is called before the first frame update
    void Start()
    {
        playerQuest = player.GetComponent<Quests>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckQuestStatus();
    }

    private void CheckQuestStatus()
    {
        if(playerQuest.questStatus == "inactive")
        {
            Invoke("StartQuest", 3);
        }
        else if(playerQuest.questStatus == "failed")
        {
            score = score - 100;
            Invoke("StartQuest", 3);
        }
        else if(playerQuest.questStatus == "completed")
        {
            score = score + 100;
            Invoke("StartQuest", 3);
            
        }
    }

    public void StartQuest()
    {
        int num1;
        int num2;
        while (true)
        {
            num1 = Random.Range(1, 6);
            num2 = Random.Range(1, 6);

            if (num1 != num2)
            {
                break;
            }
        }



        playerQuest.StartQuest($"Factory_{num1}", $"Factory_{num2}");
       
    }
}
