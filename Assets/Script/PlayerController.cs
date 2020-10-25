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
    private KeyCode joueur1;
    private KeyCode joeur2;

    [SerializeField]
    private float couldDown;
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

            Car1();
            Car2();

        }
    }

    void Car1()
    {
        if (Input.GetKey(joueur1))
        {
            speedVerti = 12;
            transform.position += new Vector3(0f, speedVerti * Time.deltaTime, 0f);
            Debug.Log(speedVerti);
        }

        if (Input.GetKey(KeyCode.S))
        {
            speedVerti = 8;
            transform.position += new Vector3(0f, -speedVerti * Time.deltaTime, 0f);
            Debug.Log(speedVerti);
        }


        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += new Vector3(-speedHori * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speedHori * Time.deltaTime, 0f, 0f);
        }
    }
  
    void Car2()
    {
        transform.Translate(Vector3.forward * (speedZ * Time.deltaTime));
        Debug.Log(speedZ);


        if (Input.GetKey(KeyCode.UpArrow))
        {
            speedVerti = 12;
            transform.position += new Vector3(0f, speedVerti * Time.deltaTime, 0f);
            Debug.Log(speedVerti);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            speedVerti = 8;
            transform.position += new Vector3(0f, -speedVerti * Time.deltaTime, 0f);
            Debug.Log(speedVerti);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speedHori * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speedHori * Time.deltaTime, 0f, 0f);
        }
    }
}
