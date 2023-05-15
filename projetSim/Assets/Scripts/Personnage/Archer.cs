using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Personnage
{
    public Archer() : base(10, 3,15)
    {
    }

    // L'attaque est différente pour un archer. Il tir un flèche à l'infini et touche la première 
    // personne que la fléche rencontre. Ensuite, la fléche disparait.
    public override void attaque()
    {

        
        Vector3 devant = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;


        if(Physics.Raycast(transform.position, devant, out hit, Mathf.Infinity))
        {
            if(hit.collider == true) 
            {

                hit.collider.GetComponent<Vie>().Damage(this.getDommage());
            }

        }
        
    }
}
