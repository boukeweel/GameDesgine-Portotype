using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Boog : MonoBehaviour
{
    public float max_loading_time;
    public GameObject Arrow;
    

    public float xmouse;

    public Player speler;

    public float mousesensetifity = 2;

    



    public Animator animator;
    private void Start()
    {
        
    }


    private void Update()
    {

        xmouse = Input.GetAxis("Mouse X") * mousesensetifity;
        if (Input.GetMouseButtonDown(1))
        {
            //animator.SetBool("MouseDown", true);
            

            
            Instantiate(Arrow, transform.position, transform.rotation * Quaternion.Euler(0, xmouse, 0));
            

        }
       

        //if(animator.GetBool("MouseDown") == true)
        //{
            
            
        //}
    }

}
