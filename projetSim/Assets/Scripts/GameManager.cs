using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
    [SerializeField]
    private List<GameObject> persoEnnemi = new List<GameObject>();
    [SerializeField]
    private List<GameObject> persoAllie = new List<GameObject>();
    */

    [SerializeField]
    private GameObject[] persoEnnemi;
    private int ennemis = 0;
    [SerializeField]
    private GameObject[] persoAllie;
    private GameObject instantiated;
    [SerializeField]
    private List<Bloc> blocs = new List<Bloc>();
    [SerializeField]
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

        for(int i = 0; i < persoAllie.Length; i++) 
        {
            if (persoAllie[i].GetComponent<Personnage>().getVie() <= 0) 
            {
                Debug.Log("DEAD!!!");
               // Destroy(persoAllie[i]);
               // persoAllie.RemoveAt(i);
            }
        }

        for (int i = 0; i < persoEnnemi.Length; i++)
        {
            if (persoEnnemi[i].GetComponent<Personnage>().getVie() <= 0)
            {
                int elementAEnlever = i;

                Destroy(persoEnnemi[i]);
                enleverPerso(elementAEnlever);   
                
            }
        }
    }
    public void runGame()
    {
        finPartie = false;
        if(!finPartie){
            foreach (GameObject troupe in persoAllie)
            {
                ennemis++;
                accederBloc(troupe);
                if(ennemis == persoAllie.Length * 2) 
                {

                    ennemis = 0;
                    ennemiBouge();
                
                }
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

    public GameObject[] getPersoAllie(){
        return persoAllie;
    }     

    public GameObject[] getPersoEnnemi(){
        return persoEnnemi;
    }

    public void enleverPerso(int indexAEnlever)
    {

        List<GameObject> list = new List<GameObject>(persoEnnemi);
        list.RemoveAt(indexAEnlever);
        Debug.Log(list.Count);
        persoEnnemi = list.ToArray();

    }
    public void ennemiBouge() 
    {


        for (int i = 0; i < persoEnnemi.Length; i++)
        {
            int deplacement = Random.Range(0,5);
            switch (deplacement)
            {
                case 1:
                    {
                        persoEnnemi[i].GetComponent<Personnage>().setDirection(Direction.AVANT);
                        persoEnnemi[i].GetComponent<Personnage>().resetTimer();
                        break;
                    }
                case 2:
                    {
                        persoEnnemi[i].GetComponent<Personnage>().setDirection(Direction.ARRIERE);
                        persoEnnemi[i].GetComponent<Personnage>().resetTimer();
                        break;
                    }
                case 3:
                    {
                        persoEnnemi[i].GetComponent<Personnage>().setDirection(Direction.DROITE);
                        persoEnnemi[i].GetComponent<Personnage>().resetTimer();
                        break;
                    }
                case 4:
                    {
                        persoEnnemi[i].GetComponent<Personnage>().setDirection(Direction.GAUCHE);
                        persoEnnemi[i].GetComponent<Personnage>().resetTimer();
                        break;
                    }
                case 5:
                    {
                        persoEnnemi[i].GetComponent<Personnage>().attaque();
                        break;
                    }
                default:
                    break;
            }

        }
    }

    public GameObject getObjet(TableauIndice indice){
        int tab =  indice.getTab();
        int index = indice.getIndice();
        if(tab == 0){
            return persoAllie[index];
        }else{
            return persoEnnemi[index];
        }
    }
}
