using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    //Variable déplacement
    [SerializeField]
    private int life = 0;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float deplacement = 0;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float tempsMax = 1;
    private float tempsEcouler = 0;
    private bool avancer = false;

    // Variable pour l'attaque
    [SerializeField]
    public float attackRange;
    public bool toucher = false;
    //public GameObject RayHit;



    CharacterController Cac;
    Vector3 moveD = Vector3.zero;
    public Direction direction;


    public Personnage(int life, int speed, int deplacement)
    {
        this.life = life;
        this.speed = speed;
        this.deplacement = deplacement;
        gravity = 1;

    }
    public void Start()
    {
        Cac = GetComponent<CharacterController>();
      //  RayHit = GameObject.Find("RayHit");
    }

    public void Update()
    {

        if (avancer)
        {
            tempsEcouler = tempsEcouler + Time.deltaTime;
            bouger();
        }
        if (tempsEcouler >= tempsMax)
        {
            avancer = false;
        }

    }

    public void bouger()
    {


        if (direction == Direction.DROITE)
        {

            transform.Rotate(0, 90, 0);
            direction = Direction.AVANT;

        }

        if (direction == Direction.GAUCHE)
        {

            transform.Rotate(0, -90, 0);
            direction = Direction.AVANT;


        }

        if (direction == Direction.ARRIERE)
        {

            transform.Rotate(0, 180, 0);
            direction = Direction.AVANT;

        }



        if (Cac.isGrounded)
        {

            moveD = new Vector3(0, 0, deplacement);
            moveD = transform.TransformDirection(moveD);

        }



        moveD.y -= gravity * Time.deltaTime;
        Cac.Move(moveD * Time.deltaTime);



    }

    public void setDirection(Direction direction)

    {
        this.direction = direction;
    }

    public void resetTimer()
    {
        tempsEcouler = 0;
        avancer = true;
    }


    public virtual void attaque()
    {
        /*
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Destroy(hit.transform.gameObject);
            }
        }
    */
        /*
         Si le personnage n'a pas d'attaque spécifiquer il obtient tout simplement
         l'attaque de base
        */

        attaqueDeBase();


    }
    public void attaqueDeBase()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward), out hit, attackRange))
        {
            
            if (hit.transform.tag == "test")
            {
                print(hit.transform.name + "detected");
                Destroy(hit.transform.gameObject);

            }
        }
    }

    public int getLife()
    {
        return life;
    }

}



