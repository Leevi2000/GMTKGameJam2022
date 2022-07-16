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

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        lastPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        temp = (lastPos - transform.position);
        lastPos = transform.position;
        currentSpeedByFrame = Mathf.Sqrt(Mathf.Pow(temp.x, 2) + Mathf.Pow(temp.y, 2) + Mathf.Pow(temp.z, 2));
        
        if (Input.GetAxis("Vertical") > 0 && currentSpeedByFrame < maxSpeed)
        {
            move = currentSpeedByFrame + acceleration * Time.deltaTime;
        }
        //if (Input.GetAxis("Vertical") < 0 && currentSpeedByFrame < maxSpeed)
        //{
        //    move = -currentSpeedByFrame + -acceleration * Time.deltaTime;
        //}


        // When car is going backwards, reverse turning controls
        //if (Input.GetAxis("Vertical") < 0)
        //{
        //    rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //}
        //else
        //{
        //    rotation = Input.GetAxis("Horizontal") * -rotationSpeed;
        //}
        rotation = Input.GetAxis("Horizontal") * -rotationSpeed;


        if (Input.GetAxis("Vertical") == 0 && currentSpeedByFrame > 0.001f)
        {
            move = currentSpeedByFrame - stallForce * Time.deltaTime;
        }

        
        if(move > 0.0005f)
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
    private void LateUpdate()
    {
   
        
    }
}
