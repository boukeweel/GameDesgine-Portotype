using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class arrow : MonoBehaviour
{
    

    

    static bool  vuuren = true;

    private float timehold = 10;

    private float eve;

    bool holding = false;

    public float xmouse;

    public float mousesensetifity;

    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        xmouse = Input.GetAxis("Mouse X") * mousesensetifity;

        if (Input.GetMouseButtonDown(1))
        {
            holding = true;
        }
        if (holding)
        {
            //timehold += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(1))
        {
            holding = false;
            //if(timehold > 10)
            //{
            //    timehold = 10;
            //}
            
            vuuren = true;
        }


        if (vuuren)
        {
            //transform.position(0, xmouse, 0);
            rig.AddForce(transform.forward * timehold * Time.deltaTime);
        }
    }

    

    
}
