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

    //Variable pour bloc
    private TableauIndice memoire;
    private bool accesBloc = true;

    // Variable pour l'attaque
    [SerializeField]
    public int attaqueRange;
    public bool toucher = false;
    private int dommage;
    [SerializeField]
    private Material myMaterial;



    // Vie des personnage
    [SerializeField] private Vie vie;


    CharacterController Cac;
    Vector3 moveD = Vector3.zero;
    public Direction direction;


    public Personnage(int speed, int deplacement, int dommage)
    {
        this.speed = speed;
        this.deplacement = deplacement;
        this.dommage = dommage;
        gravity = 1;

    }
    public void Start()
    {
        Cac = GetComponent<CharacterController>();
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
        // L'attaque de base (Infanterie et Barbare)
        Collider[] colliders = Physics.OverlapSphere(transform.position, attaqueRange);

        foreach (Collider c in colliders)
        {

            if (c.GetComponent<Personnage>())
            {
                // Recherche si le GameObject toucher est un ennemie pour l'allier et
                // un allier pour l'ennemi. IL n'attaqua pas leur amis.
                if (gameObject.tag != c.tag)
                {
                    
                    c.GetComponent<Vie>().Damage(dommage);
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
    public int getDommage() 
    {

        return dommage;
    }

    public void setDommage(int newDamage) 
    {
        this.dommage = newDamage; 
    }

    public int getAttaqueRange() 
    {

        return attaqueRange;
    }
    public int getVie() 
    {
        return vie.getLife();
    
    } 
}




