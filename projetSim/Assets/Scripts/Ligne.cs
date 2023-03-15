using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Ligne : MonoBehaviour 
{
    private static List<Ligne> lignes = new List<Ligne>();
    [SerializeField] private TMP_Text text;
    private int numero;
    private static int index = 1;

    private void Start()
    {
        numero = index;
        index++;
        string num = numero.ToString();
        text.GetComponent<TMP_Text>().text = num;
        lignes.Add(this);
    }
}
