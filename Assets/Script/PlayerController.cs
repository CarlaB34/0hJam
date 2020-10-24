using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
    [SerializeField]
    private float speed;

    [SerializeField]
    private Animator anim;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            //rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
                //rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            //rb.AddForce(new Vector3(transform.position.y, 0,0), ForceMode.Impulse);
            
        }
    }*/
    [SerializeField]
    private float speedPlayer;

    private Rigidbody rb;

   
    private Vector3 velocity;
    private float moveVelocity;
    private Vector3 moveDirectionX = Vector3.right;
    private Vector3 moveDirectionZ = Vector3.forward;
    

   // public Animator march;

    private void Start()
    {
       
        rb = GetComponent<Rigidbody>();
       // march = GetComponentInChildren<Animator>();
        //march.SetBool("Take 001", false);
    }


    private void Update()
    {
        moveVelocity = 0;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0 * speedPlayer);
            GetComponent<Rigidbody>().AddForce(moveDirectionX * -speedPlayer, ForceMode.Impulse);
          //  march.SetBool("Take 001", true);

        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0 * speedPlayer);
            //transform.rotation = Quaternion.Euler(0, 90, 0 * speedPlayer);
            GetComponent<Rigidbody>().AddForce(moveDirectionX * speedPlayer, ForceMode.Impulse);

        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, -180, 0 * speedPlayer);
            GetComponent<Rigidbody>().AddForce(moveDirectionZ * -speedPlayer, ForceMode.Impulse);


        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0 * speedPlayer);
          //  transform.rotation = Quaternion.Euler(0, 0, 0 * speedPlayer);
            GetComponent<Rigidbody>().AddForce(moveDirectionZ * speedPlayer, ForceMode.Impulse);

        }
        Vector3 velocity = GetComponent<Rigidbody>().velocity;

        GetComponent<Rigidbody>().velocity = velocity + new Vector3(moveVelocity, 0);


    }
    private void FixedUpdate()
    {
        rb.velocity = velocity;
        //march.SetBool("Take 001", false);
    }



}
