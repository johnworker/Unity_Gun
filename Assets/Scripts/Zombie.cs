using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent _name;
    // Start is called before the first frame update
    void Start()
    {
        this._name = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this._name.enabled)
        {

        }
    }
}
