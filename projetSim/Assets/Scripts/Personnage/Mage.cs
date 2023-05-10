using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Personnage
{

    public Mage() : base(2, 4,20)
    {
    }


    public override void attaque()
    {

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, this.getAttaqueRange());
    }

}
