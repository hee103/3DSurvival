using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqipTool : Equip
{
    public float attackRate;
    private bool attacking;
    public float attakDistance;
    public float useStamina;

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
            if(CharacterManager.Instance.Player.condition.UseStamina(useStamina))
            {
                attacking = true;
                animator.SetTrigger("Attack");
                Invoke("OnCanAttack", attackRate);
            }
            
        }
    }
    void OnCanAttack()
    {
        attacking = false;
    }
    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attakDistance))
        {
            if (doesGatherResource && hit.collider.TryGetComponent(out Resource resource))
            {
                resource.Gather(hit.point, hit.normal);
            }
        }
    }
}
