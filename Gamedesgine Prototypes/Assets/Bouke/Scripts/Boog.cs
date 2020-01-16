using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boog : MonoBehaviour
{
    public float max_loading_time;
    public GameObject Arrow;

    public float xmouse;

    public Player speler;

    public Animator animator;

    private void Update()
    {

        xmouse = Input.GetAxis("Mouse X") * speler.mousesensetifity;
        if (Input.GetMouseButtonDown(0))
        {
            //animator.SetBool("MouseDown", true);
            Instantiate(Arrow, transform.position, transform.rotation * Quaternion.Euler(0, xmouse, 0));


        }

        //if(animator.GetBool("MouseDown") == true)
        //{
            
            
        //}
    }

}
