using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] perso;
    private GameObject instantiated; 

    private int activePersoIndex = 0;

    [SerializeField]
    private Vector3 zoneSize;

    
    void Start()
    {
        pickPerso();
        instantiated = Instantiate(perso[activePersoIndex]);

        instantiated.transform.position = new Vector3(
            Random.Range(transform.position.x - zoneSize.x / 2,transform.position.x + zoneSize.x / 2),
            Random.Range(zoneSize.y / 2,zoneSize.y / 2),
            Random.Range(transform.position.z - zoneSize.z / 2, transform.position.z + zoneSize.z / 2)
            );

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
       
        int persoIndex = UnityEngine.Random.Range(0, perso.Length);
        activePersoIndex= persoIndex;
        GameObject activePerso = perso[activePersoIndex];
    }
}
