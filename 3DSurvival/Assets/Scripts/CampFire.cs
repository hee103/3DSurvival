using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;
    List<IDamageIbe> things = new List<IDamageIbe>();
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("DealDamage",0,damageRate); 
    }

    // Update is called once per frame
    void DealDamage()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.TryGetComponent(out IDamageIbe damageIbe))
        {
            things.Add(damageIbe);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out IDamageIbe damageIbe))
        {
            things.Remove(damageIbe);
        }
    }
}
