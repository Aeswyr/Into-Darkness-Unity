using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    [SerializeField] private int constitution;
    //secondary fields
    private int woundsMax;
    [SerializeField] private int endurance;
    //secondary fields
    private int staminaMax;
    private int stamina;
    [SerializeField] private int strength;
    //secondary fields
    private int atkMod;
    [SerializeField] private int precision;
    //secondary fields
    [SerializeField] private int wit;
    //secondary fields
    private int focusMax;
    private int focus;

    private int orbsMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GetWoundsMax() {
        return woundsMax;
    }
}
