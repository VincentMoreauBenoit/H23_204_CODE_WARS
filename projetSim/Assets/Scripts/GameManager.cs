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
    private bool joue = false;


    [SerializeField]
    private Vector3 zoneSize;

    private void Start()
    {
        instantiated = persoEnnemi[0];
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            instantiated.GetComponent<Personnage>().setDirection(Direction.AVANT);
            instantiated.GetComponent<Personnage>().resetTimer();
           
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            instantiated.GetComponent<Personnage>().setDirection(Direction.ARRIERE);
            instantiated.GetComponent<Personnage>().resetTimer();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            instantiated.GetComponent<Personnage>().setDirection(Direction.DROITE);
            instantiated.GetComponent<Personnage>().resetTimer();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            instantiated.GetComponent<Personnage>().setDirection(Direction.GAUCHE);
            instantiated.GetComponent<Personnage>().resetTimer();
        }
        if(joue)
        {
            index = 0;
        }

    }
    public void runGame()
    {
        bool finpartie = false;
        while (!finpartie)
        {
            
            foreach (GameObject troupe in persoAllie)
            {
               
                accederBloc(troupe);
            }
            joue = false;
            finpartie= true;
        }

    }
    public void jouer()
    {
        blocs = Ligne.CreerListeBloc();
        runGame();
        joue = true;
    }
    public void accederBloc(GameObject troupe)
    {
        blocs[index].executer(troupe);
    }
    

    

        
               
}
