using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speedHori = 5;

    [SerializeField]
    private float speedVerti = 10;

    [SerializeField]
    private float speedZ = 2;

    [SerializeField]
    private KeyCode joueur1Up;
    [SerializeField]
    private KeyCode joueur1Down;
    [SerializeField]
    private KeyCode joueur1Left;
    [SerializeField]
    private KeyCode joueur1right;
    
    [SerializeField]
    private KeyCode joeur2Up;
    [SerializeField]
    private KeyCode joeur2Down;
    [SerializeField]
    private KeyCode joeur2Left;
    [SerializeField]
    private KeyCode joeur2Right;

    [SerializeField]
    private float couldDown;

    [SerializeField]
    private GameObject camera;
    private void Start()
    {
        speedVerti = 10;
        Debug.Log(speedVerti);
        
        
    }
    void Update()
    {
        couldDown -= Time.deltaTime;
        Debug.Log(couldDown);

        //quand le timer est fini on avance
        if (couldDown <= 0)
        {
            couldDown = 0;
          //  transform.Translate(Vector3.forward * (speedZ * Time.deltaTime));
            Car1();
            Car2();

        }
    }

    void Car1()
    {
        transform.Translate(Vector3.forward * (speedZ * Time.deltaTime));
        if (Input.GetKey(joueur1Up))
        {
            speedVerti = 12;
            transform.position += new Vector3(0f, speedVerti * Time.deltaTime, 0f);
            Debug.Log(speedVerti);
        }

        if (Input.GetKey(joueur1Down))
        {
            speedVerti = 8;
            transform.position += new Vector3(0f, -speedVerti * Time.deltaTime, 0f);
            Debug.Log(speedVerti);
        }


        if (Input.GetKey(joueur1Left))
        {
            transform.position += new Vector3(-speedHori * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(joueur1right))
        {
            transform.position += new Vector3(speedHori * Time.deltaTime, 0f, 0f);
        }
    }
  
    void Car2()
    {
        transform.Translate(Vector3.forward * (speedZ * Time.deltaTime));
        //Debug.Log(speedZ);


        if (Input.GetKey(joeur2Up))
        {
            speedVerti = 12;
            transform.position += new Vector3(0f, speedVerti * Time.deltaTime, 0f);
            Debug.Log(speedVerti);
        }

        if (Input.GetKey(joeur2Down))
        {
            speedVerti = 8;
            transform.position += new Vector3(0f, -speedVerti * Time.deltaTime, 0f);
            Debug.Log(speedVerti);
        }


        if (Input.GetKey(joeur2Left))
        {
            transform.position += new Vector3(-speedHori * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(joeur2Right))
        {
            transform.position += new Vector3(speedHori * Time.deltaTime, 0f, 0f);
        }
    }
}
