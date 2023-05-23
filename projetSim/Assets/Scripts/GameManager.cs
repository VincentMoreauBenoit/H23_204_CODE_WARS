using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variable ennemis
    [SerializeField] private GameObject[] persoEnnemi;
    private int ennemis = 0;
    // Variable allier
    [SerializeField] private GameObject[] persoAllie;

    // Variable pour personnage
    private GameObject instantiated;
    public Personnage personnage;
    private float tempsEntreAction = 1;


    // Variable pour les blocs
    [SerializeField] private List<Bloc> blocs = new List<Bloc>();
    [SerializeField] private int index = 0;

    // Variable pour savoir si c'est la fin de la 
    // partie ou non.
    private bool finPartie = true;


    /// <summary>
    /// Un petit debug qui nous permet de tester le déplacement des personnages.
    /// </summary>
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

        // Petite pause avant chaque action des personnages
        if(!finPartie){

            tempsEntreAction-= Time.deltaTime;
            if(tempsEntreAction<0){
                tempsEntreAction = 1f;
                runGame();
            }
        }

        // Regarde si un personnage allié est mort. Si oui, le supprime de son tableau
        // et le détruit ensuite
        for(int i = 0; i < persoAllie.Length; i++) 
        {
            if (persoAllie[i].GetComponent<Personnage>().getVie() <= 0) 
            {
                int elementASupprimer = i;

                Destroy(persoAllie[i]);
                enleverPerso(elementASupprimer);

            }
        }

        // Regarde si un personnage ennemi est mort. Si oui, le supprime de son tableau
        // et le détruit ensuite
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

    /// <summary>
    /// Lance la partie. Elle lance les bloc à la chaine et 
    /// s'arrête quand un personnage, que sa soit allié ou ennemi, meurt.
    /// </summary>
    public void runGame()
    {
        finPartie = false;
        if(!finPartie){
            foreach (GameObject troupe in persoAllie)
            {
                ennemis++;
                accederBloc(troupe);

                // Les ennemis se déplacement une fois tout les deux tour des personnages alliés. 
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

    /// <summary>
    /// Prend les blocs que l'utilisateur à mit dans la barre
    /// pour ensuite les lancer dans la classe runGame();.
    /// </summary>
    public void jouer()
    {
        blocs = Ligne.CreerListeBloc();
        runGame();
    }

    /// <summary>
    /// Donne accés, à un personnage, à un bloc. 
    /// </summary>
    /// <param name="troupe"></param>
    public void accederBloc(GameObject troupe)
    {
        blocs[index].executer(troupe);
    }

    /// <summary>
    /// Getter pour le tableau des personnages alliés.
    /// </summary>
    /// <returns></returns>
    public GameObject[] getPersoAllie(){
        return persoAllie;
    }     

    /// <summary>
    /// Getter pour le tableau des personnages ennemis.
    /// </summary>
    /// <returns></returns>
    public GameObject[] getPersoEnnemi(){
        return persoEnnemi;
    }

    /// <summary>
    /// Enleve un personnage d'un tableau.
    /// </summary>
    /// <param name="indexAEnlever">Index du personnage à enlever</param>
    public void enleverPerso(int indexAEnlever)
    {

        List<GameObject> list = new List<GameObject>(persoEnnemi);
        list.RemoveAt(indexAEnlever);
        Debug.Log(list.Count);
        persoEnnemi = list.ToArray();

    }

    /// <summary>
    /// Le déplacement des ennemis se fait aléatoirement.
    /// </summary>
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
