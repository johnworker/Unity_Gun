using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PigMonster : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent pigControl;
    public Animator anim;
    private string parDamage = "hurt";
    // Start is called before the first frame update
    void Start()
    {
       this.pigControl = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.pigControl.enabled)
        {
            this.pigControl.SetDestination(this.target.position);
        }
    }

    public void kill()
    {
        this.pigControl.enabled = false;
        anim.SetTrigger(parDamage);
        
    }
}
