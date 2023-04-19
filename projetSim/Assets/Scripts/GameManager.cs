using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] persoEnnemi;
    private GameObject[] persoAllie;
    private GameObject instantiated; 

    private int activePersoIndex = 0;

    [SerializeField]
    private Vector3 zoneSize;

    
    void Start()
    {
        pickPerso();
        instantiated = Instantiate(persoAllie[activePersoIndex]);

        instantiated.transform.position = new Vector3(-100,-198.8f, 150);

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

    }
    
    private void pickPerso()
    {
       
        int persoIndex = UnityEngine.Random.Range(0, persoAllie.Length);
        activePersoIndex= persoIndex;
        GameObject activePerso = persoAllie[activePersoIndex];
    }
}
