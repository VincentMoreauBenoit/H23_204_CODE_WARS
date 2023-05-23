using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Personnage
{
    public Archer() : base(10, 3,15)
    {
    }


    /// <summary>
    /// L'attaque est diff�rente pour un archer. Il tir un fl�che � l'infini et touche la premi�re 
    /// personne que la fl�che rencontre. Ensuite, la fl�che disparait.
    /// </summary>
    public override void attaque()
    {

        
        Vector3 devant = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        // Le raycast cherche un position devant le personnage jusqu'� l'infini.
        if(Physics.Raycast(transform.position, devant, out hit, Mathf.Infinity))
        {
            if(hit.collider == true) 
            {

                hit.collider.GetComponent<Vie>().Damage(this.getDommage());
            }

        }
        
    }
}
