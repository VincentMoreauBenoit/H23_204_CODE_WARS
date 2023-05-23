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
    // Variable déplacement pour les personnages
    CharacterController Cac;
    Vector3 moveD = Vector3.zero;
    public Direction direction;

    //Variable pour bloc
    private TableauIndice memoire;
    private bool accesBloc = true;

    // Variable pour l'attaque
    [SerializeField]
    public int attaqueRange;
    public bool toucher = false;
    private float dommage;

    // Vie des personnages
    [SerializeField] private Vie vie;


    /// <summary>
    /// Tout les personnages qui héritent de cette classe auront une vitesse, un déplacement et des
    /// dommages.
    /// </summary>
    /// <param name="speed">La vitesse du personnage</param>
    /// <param name="deplacement">Le déplacement du personnage</param>
    /// <param name="dommage">L'attaque du personnage</param>
    public Personnage(int speed, int deplacement, float dommage)
    {
        this.speed = speed;
        this.deplacement = deplacement;
        this.dommage = dommage;
        gravity = 1;

    }

    /// <summary>
    /// On prend les component du CharacterController pour nos 
    /// personnages.
    /// </summary>
    public void Start()
    {
        Cac = GetComponent<CharacterController>();
    }

    /// <summary>
    /// Le déplacement du personnage.
    /// </summary>
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

    /// <summary>
    /// Comment le personnage se déplacement.
    /// Il peut aller en haut, en bas, à droite et à gauche
    /// </summary>
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

    /// <summary>
    /// Setter pour la directions
    /// </summary>
    /// <param name="direction">4 direction : Haut, bas , droite, gauche.</param>
    public void setDirection(Direction direction)

    {
        this.direction = direction;
    }

    /// <summary>
    /// Reset le timer pour l'animation du personnage.
    /// </summary>
    public void resetTimer()
    {
        tempsEcouler = 0;
        avancer = true;
    }

    /// <summary>
    /// L'attaque de base (Infanterie et Barbare)
    /// </summary>
    public virtual void attaque()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attaqueRange);

        foreach (Collider c in colliders)
        {

            if (c.GetComponent<Personnage>())
            {
                // Recherche si le GameObject toucher est un ennemie pour l'allier et
                // un allier pour l'ennemi. Les personnages de même famille ne peuvent pas
                // se faire de dégats.
                if (gameObject.tag != c.tag)
                {
                    
                    c.GetComponent<Vie>().Damage(dommage);
                }
            }
        }
        
    }

    /// <summary>
    /// Setter pour le mémoire.
    /// </summary>
    /// <param name="indice">Indice tableau</param>
    public void setMemoire(TableauIndice indice)
    {
        memoire = indice;
    }

    /// <summary>
    /// Getter pour la mémoire.
    /// </summary>
    /// <returns></returns>
    public TableauIndice accederMemoire()
    {
        return memoire;
    }

    /// <summary>
    /// permet d'accéder ou on aux bloc
    /// </summary>
    /// <param name="allo">Vrai ou faux</param>
    public void flip(bool allo)
    {
        accesBloc = allo;
    }

    /// <summary>
    /// Gravité
    /// </summary>
    public void getGravity()
    {
        moveD.y -= gravity * Time.deltaTime;
        Cac.Move(moveD * Time.deltaTime);
    }

    /// <summary>
    /// Getter pour les dommages des personnages.
    /// </summary>
    /// <returns></returns>
    public float getDommage() 
    {

        return dommage;
    }

    /// <summary>
    /// Setter pour les dommages des personnages
    /// </summary>
    /// <param name="newDamage"></param>
    public void setDommage(float newDamage) 
    {
        this.dommage = newDamage; 
    }
    /// <summary>
    /// Getter pour la range.
    /// </summary>
    /// <returns></returns>
    public int getAttaqueRange() 
    {

        return attaqueRange;
    }
    /// <summary>
    /// Getter pour la vie
    /// </summary>
    /// <returns></returns>
    public float getVie() 
    {
        return vie.getLife();
    
    } 
    public bool accesBlocs(){
        return accesBloc;
    }
}




