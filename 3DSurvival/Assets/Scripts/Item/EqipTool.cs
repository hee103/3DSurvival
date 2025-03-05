using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqipTool : Equip
{
    public float attackRate;
    private bool attacking;
    public float attakDistance;

    [Header("Resource Gathering")]
    public bool doesGatherResource;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
