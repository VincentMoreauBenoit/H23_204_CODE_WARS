using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Personnage
{

    public Mage() : base(2, 4,20)
    {
    }


    /// <summary>
    ///   Le mage lance un jet de magie devant lui qui a une portée définie. IL fait des dégats à 
    ///   tout les personnages touchés par son jet de magie.
    /// </summary>
    public override void attaque()
    {

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, this.getAttaqueRange());


        for (int i = 0; i < hits.Length; i++)
        {

            RaycastHit hit = hits[i];
            Renderer rend = hit.transform.GetComponent<Renderer>();

            Debug.Log(rend);
            if (rend)
            {

                rend.GetComponent<Vie>().Damage(this.getDommage());
            }
        }

    }

}
