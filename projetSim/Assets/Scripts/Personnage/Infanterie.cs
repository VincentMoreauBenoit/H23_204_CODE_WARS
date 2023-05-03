using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infanterie : Personnage
{
    public Infanterie() : base(5, 2, 5)
    {

    }

    public override void attaque()
    {
        //Il prend l'attaque de base, car il attaque aussi vers l'avant  
        base.attaque();

        RaycastHit hit;

        //Il peut attaquer derrière lui
        if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.back), out hit, attackRange))
        {


            if (hit.transform.tag == "test")
            {
                print(hit.transform.name + "detected");
                Destroy(hit.transform.gameObject);

            }
        }

        //Il peut attaquer à sa droite 
        if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.right), out hit, attackRange))
        {


            if (hit.transform.tag == "test")
            {
                print(hit.transform.name + "detected");
                Destroy(hit.transform.gameObject);

            }
        }

        //Il peut attaquer à sa gauche
        if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.left), out hit, attackRange))
        {
            

            if (hit.transform.tag == "test")
            {
                print(hit.transform.name + "detected");
                Destroy(hit.transform.gameObject);

            }
        }

    }
}
