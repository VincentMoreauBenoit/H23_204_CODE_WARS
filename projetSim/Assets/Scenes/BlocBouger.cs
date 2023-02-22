using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlocBouger : Bloc
{
    public Direction direction = Direction.AVANT;
    override
    public void executer(int i)
    {
        Debug.Log(direction.ToString());
    }
    public void setDirection(Direction direction)
    {
        this.direction = direction;
    }
}
