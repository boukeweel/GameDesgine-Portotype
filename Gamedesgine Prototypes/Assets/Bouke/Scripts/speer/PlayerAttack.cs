using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public GameObject Hand;
    public speer speer;
    Animator handani;

    private float cooldowntimer;

    private float test1, test2;
    public float endAnimation_light;
    public float endAnimation_heavy;

    private void Start()
    {
        handani = Hand.GetComponent<Animator>();
        speer = Hand.GetComponentInChildren<speer>();
        handani = Hand.GetComponent<Animator>();
    }
    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && cooldowntimer >= speer.CoolDown_light)
        {
            handani.SetBool("pressed", true);
            Attack();
            cooldowntimer = 0;
            
            
        }
        test1 += Time.deltaTime;
        if(test1 >= endAnimation_light)
        {
            handani.SetBool("pressed", false);
            test1 = 0;
        }
        if (Input.GetMouseButtonDown(1) && cooldowntimer >= speer.Cooldown_havy)
        {
            handani.SetBool("heavy pressed", true);
            heavyattack();
            cooldowntimer = 0;
            
        }
        test2 += Time.deltaTime;
        if(test2 >= endAnimation_heavy)
        {
            handani.SetBool("heavy pressed", false);
            test2 = 0;
        }
    }
    private void heavyattack()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, speer.AttackRange))
        {
            if(hit.collider.tag == "Enemy")
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.TakeDammages(speer.AttackDammages_havy);
            }
        }
    }

    private void Attack()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, speer.AttackRange))
        {
            if(hit.collider.tag == "Enemy")
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.TakeDammages(speer.AttackDammages_lightattack);
            }
        }
    }
}
