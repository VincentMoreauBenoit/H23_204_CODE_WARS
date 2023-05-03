using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Personnage
{
    public Archer() : base(10, 3, 2)
    {
    }

    public override void attaque()
    {

        
        Vector3 devant = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;


        if(Physics.Raycast(transform.position, devant, out hit, attackRange))
        {
            Debug.Log("Trouver un objet cette distance " + hit.distance);

        }
        
    }
}
