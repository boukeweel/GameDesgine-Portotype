using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speer : MonoBehaviour
{
    [Header("range")]
    public float AttackRange;
    //light attacks
    [Header("LightAttack")]
    public float AttackDammages_lightattack;
    public float CoolDown_light;

    //havy attacks
    [Header("Havyattack")]
    public float AttackDammages_havy;
    public float Cooldown_havy;
    

}
