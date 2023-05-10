using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;  


public class Personnage : MonoBehaviour
{
    //Variable deplacement   
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
    private TableauIndice memoire;
    private bool accesBloc = true;

    // Variable pour l'attaque
    [SerializeField]
    public int attaqueRange;
    public bool toucher = false;
    private int damage;
    //public GameObject RayHit;

    [SerializeField] private Vie vie;


    CharacterController Cac;
    Vector3 moveD = Vector3.zero;
    public Direction direction;


    public Personnage(int speed, int deplacement, int damage)
    {
        this.speed = speed;
        this.deplacement = deplacement;
        this.damage = damage;
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



        getGravity();



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
         Si le personnage n'a pas d'attaque sp�cifiquer il obtient tout simplement
         l'attaque de base
        */
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20f);

        foreach (Collider c in colliders)
        {
            if (c.GetComponent<Personnage>())
            {
                
                Debug.Log(gameObject.tag);
                Debug.Log(c.tag);
                if (gameObject.tag != c.tag)
                {
                    
                    c.GetComponent<Vie>().Damage(10);
                }
            }
        }
        
    }
    public void setMemoire(TableauIndice indice)
    {
        memoire = indice;
    }
    public TableauIndice accederMemoire()
    {
        return memoire;
    }
    public void flip(bool allo)
    {
        accesBloc = allo;
    }
    public void getGravity()
    {
        moveD.y -= gravity * Time.deltaTime;
        Cac.Move(moveD * Time.deltaTime);
    }
    public int getDomage() 
    {

        return damage;
    }

    public int getAttaqueRange() 
    {

        return attaqueRange;
    }
}




