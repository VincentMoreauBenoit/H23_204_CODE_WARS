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
<<<<<<< Updated upstream
    private GameObject instantiated;
    [SerializeField]
    private List<Bloc> blocs = new List<Bloc>();
    [SerializeField]
    private int nombreDeSec = 3;
    private int index = 0;
    private bool joue = false;

=======
>>>>>>> Stashed changes

    [SerializeField]
    private Vector3 zoneSize;

    private void Start()
    {
<<<<<<< Updated upstream
        instantiated = persoEnnemi[0];
=======
        


>>>>>>> Stashed changes
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
        if(joue)
        {
            index = 0;
        }

    }
<<<<<<< Updated upstream
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
    

    

        
               
=======

>>>>>>> Stashed changes
}
