using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    public List<Rigidbody> rigidList;
    public Animator anim;

    private NavMeshAgent _name;
    // Start is called before the first frame update
    void Start()
    {
        this._name = this.GetComponent<NavMeshAgent>();
        this.anim.PlayInFixedTime("Walk", 0, Random.Range(0.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (this._name.enabled)
        {
            this._name.SetDestination(this.target.position);
        }
    }

    public void kill()
    {
        this._name.enabled = false;
        this.anim.enabled = false;
        foreach (Rigidbody r in this.rigidList)
        {
            r.isKinematic = false;
        }
    }
}
