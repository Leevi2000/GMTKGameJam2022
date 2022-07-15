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

    private float move;
    public float speed;
    private float rotation;
    public float rotationSpeed;

    private float maxSpeed = 0.04f;

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

        
        temp = lastPos - transform.position;
        lastPos = transform.position;
        currentSpeedByFrame = Mathf.Sqrt(Mathf.Pow(temp.x, 2) + Mathf.Pow(temp.y, 2) + Mathf.Pow(temp.z, 2));
        

        move = Input.GetAxis("Vertical") * speed * (currentSpeedByFrame + 1f) * Time.deltaTime;

        if (Input.GetAxis("Vertical") < 0)
        {
            rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        }
        else
        {
            rotation = Input.GetAxis("Horizontal") * -rotationSpeed;
        }
        

        if (Input.GetAxis("Vertical") == 0)
        {
            move = speed * currentSpeedByFrame * 10 * Time.deltaTime;
        }

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
