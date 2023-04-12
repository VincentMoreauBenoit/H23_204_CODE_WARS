using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Ligne : MonoBehaviour 
{
    private static List<Ligne> lignes = new List<Ligne>();
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        lignes.Add(this);
        verifIndice();
    }
    public static void verifLine()
    { 
        
        for(int i = 1; i< lignes.Count-1;i++)
        {
            var rect = lignes[i].GetComponent<RectTransform>();
            if (rect.childCount != 2)
            {
                lignes.RemoveAt(i);
                Destroy(rect.gameObject);
                i--;
            }
        }
        verifIndice();

       
    }
    public static void verifLineHaut()
    {
        for(int i = 0;i < lignes.Count - 1; i++)
        {
            var rect = lignes[i].GetComponent<RectTransform>();
            if (rect.childCount != 2)
            {
                lignes.RemoveAt(i);
                Destroy(rect.gameObject);
                i--;
            }
        }
    }
    public void modifierText(int index)
    {
        index++;
        string num = index.ToString();
        text.GetComponent<TMP_Text>().text = num;
    }
    public static void verifIndice()
    {
        int index = 0;
        foreach (Ligne ligne in lignes)
        {
            ligne.modifierText(index);
            index++;
        }
    }
    public static List<Bloc> CreerListeBloc()
    {
        List<Bloc> blocs = new List<Bloc>();
        foreach (Ligne ligne in lignes)
        {
            if(ligne.GetComponentInChildren<Bloc>() != null)
            {
                blocs.Add(ligne.GetComponentInChildren<Bloc>());
            }
               
        }
        return blocs;
    }
    public static void viderList()
    {
        lignes.Clear();
    }
}
