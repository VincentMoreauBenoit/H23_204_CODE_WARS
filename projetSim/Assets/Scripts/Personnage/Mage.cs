using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Personnage
{

    public Mage() : base(2, 4,20)
    {
    }

    // Le mage lance un jet de magie devant lui qui a une portée difinie. IL fait des dégats à 
    // tout les personnages que son jet touche.
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

                // Change the material of all hit colliders
                // to use a transparent shader.
                /*
                rend.material.shader = Shader.Find("Assets/Toucher.mat");
                Color tempColor = rend.material.color;
                tempColor.a = 0.3F;
                rend.material.color = tempColor;
                */
            }
        }

    }

}
