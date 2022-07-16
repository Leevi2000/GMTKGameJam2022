using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    //[SerializeField]
    //private float speed;

    //[SerializeField] float tireRotation;

    //public float maxSpeed;
    //public float maxTireRotation;
    //public GameObject moveTowards;
    //public Vector2 optimalMovingVector;

    public float move;
    public float speed;
    private float rotation;
    public float rotationSpeed;
    public float acceleration;


    public float maxSpeed;
    public float stallForce;

    [SerializeField]
    private float currentSpeedByFrame;

    private Vector3 lastPos;
    public Vector3 temp;

    private int[] gearList;
    public int currentGear;

    // Start is called before the first frame update
    void Start()
    {
        gearList = new int[] { 0, 1, 2 };
        currentGear = 1;
        rb = gameObject.GetComponent<Rigidbody2D>();
        lastPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeGears();

        if (currentGear == 0)
        {
            maxSpeed = 0.01f;
        }
        else if (currentGear == 1)
        {
            maxSpeed = 0.025f;
        }
        else if (currentGear == 2)
        {
            maxSpeed = 0.04f;
        }

        temp = (lastPos - transform.position);
        lastPos = transform.position;
        currentSpeedByFrame = Mathf.Sqrt(Mathf.Pow(temp.x, 2) + Mathf.Pow(temp.y, 2) + Mathf.Pow(temp.z, 2));
        
        if (Input.GetAxis("Vertical") > 0 && currentSpeedByFrame < maxSpeed)
        {
            
            if (currentGear == 0)
                {
                move = (-1) * (currentSpeedByFrame + (acceleration * Time.deltaTime));
            }
            else
            {
                move = currentSpeedByFrame + (acceleration * Time.deltaTime);
            }
            
            
        }

        rotation = Input.GetAxis("Horizontal") * -rotationSpeed;


        if (Input.GetAxis("Vertical") == 0 && currentSpeedByFrame > 0.001f || currentSpeedByFrame > maxSpeed)
        {
            if (currentGear > 0)
            {
                move = currentSpeedByFrame - stallForce * Time.deltaTime;
            }
            else if (currentGear == 0)
            {
                move = (-1) * (currentSpeedByFrame - stallForce * Time.deltaTime);
            }
            
        }

        
        if(move > 0.0005f || move < 0.0005f)
            transform.Translate(0, move, 0);


        if (currentSpeedByFrame > 0.01f)
        {
            if (currentSpeedByFrame < 0.025f)
            {
                transform.Rotate(0, 0, rotation / 2);
            }
            else
            {
                transform.Rotate(0, 0, rotation);
            }

        }
        
        
    }

    private void ChangeGears()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(currentGear > 1)
            {
                currentGear = gearList[currentGear - 1];
            }
            else if(currentGear > 0 && currentSpeedByFrame < 0.001f)
            {
                currentGear = gearList[currentGear - 1];

            }
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentGear >= 1 && currentGear < 2)
            {
                currentGear = gearList[currentGear + 1];
            }
            else if(currentGear == 0 && currentSpeedByFrame < 0.001f)
            {
                currentGear = gearList[currentGear + 1];
            }
        }
    }
    private void LateUpdate()
    {
   
        
    }
}
