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

    private Animator animator;
    private Camera camera;
    // Start is called before the first frame update
    private void Awake()
    {
        camera = Camera.main;
        animator = GetComponent<Animator>();
    }


    public override void OnAttackInput()
    {
        if (!attacking)
        {
            attacking = true;
            animator.SetTrigger("Attack");
            Invoke("OnCanAttack",attackRate);
        }
    }
    void OnCanAttack()
    {
        attacking = false;
    }
}
