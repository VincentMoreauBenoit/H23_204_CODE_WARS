using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] persoEnnemi;
    [SerializeField]
    private GameObject[] persoAllie;
    private GameObject instantiated;
    [SerializeField]
    private List<Bloc> blocs = new List<Bloc>();
    [SerializeField]
    private int nombreDeSec = 3;
    private int index = 0;

    private float tempsEntreAction = 1;

    private bool finPartie = true;

    public Personnage personnage;


    [SerializeField]
    private Vector3 zoneSize;

    private void Start()
    { 


    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            persoAllie[0].GetComponent<Personnage>().setDirection(Direction.AVANT);
            persoAllie[0].GetComponent<Personnage>().resetTimer();
           
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            persoAllie[0].GetComponent<Personnage>().setDirection(Direction.ARRIERE);
            persoAllie[0].GetComponent<Personnage>().resetTimer();

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            persoAllie[0].GetComponent<Personnage>().setDirection(Direction.DROITE);
            persoAllie[0].GetComponent<Personnage>().resetTimer();

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            persoAllie[0].GetComponent<Personnage>().setDirection(Direction.GAUCHE);
            persoAllie[0].GetComponent<Personnage>().resetTimer();

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            persoAllie[0].GetComponent<Personnage>().attaque();
            
        }


        if(!finPartie){
            tempsEntreAction-= Time.deltaTime;
            if(tempsEntreAction<0){
                tempsEntreAction = 1f;
                runGame();
            }
        }

    }
    public void runGame()
    {
        finPartie = false;
        if(!finPartie){
            foreach (GameObject troupe in persoAllie)
            {
               
                accederBloc(troupe);
                
            }
            index = 0;
            if(index>=blocs.Count - 1){
                index = 0;
            }else{
                index++;
            }
            if(persoAllie.Length==0||persoEnnemi.Length==0){
                finPartie = true;
            }
        }
    }
    public void jouer()
    {
        blocs = Ligne.CreerListeBloc();
        runGame();
    }
    public void accederBloc(GameObject troupe)
    {
        blocs[index].executer(troupe);
    }       
}
