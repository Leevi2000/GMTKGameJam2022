using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public GameObject player;
    private Quests quests;
    [SerializeField]
    private GameObject lookAtObject;
    // Start is called before the first frame update
    void Start()
    {
        quests = player.GetComponent<Quests>();
    }

    // Update is called once per frame
    void Update()
    {
        if (quests.delivering == false)
        {
            lookAtObject = FindFactoryWithName(quests.takeFrom);
        }
        if (quests.delivering == true)
        {
            lookAtObject = FindFactoryWithName(quests.deliverTo);
        }

        if (lookAtObject != null)
        {
            var dir = lookAtObject.transform.position - transform.position;

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
        }
        

    }

    private GameObject FindFactoryWithName(string name)
    {
      
        var x = GameObject.FindGameObjectsWithTag("Factory");
        foreach (GameObject item in x)
        {
            if (item.gameObject.name == name)
            {
                return lookAtObject = item;
               
            }
        }

        return null;
        
    }
}
