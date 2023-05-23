using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


// Outils utiliser pour placer les lignes de code et avoir accès à leur contenu plus tard
public class Ligne : MonoBehaviour
{
    private static List<Ligne> lignes = new List<Ligne>();
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        lignes.Add(this);
        verifIndice();
    }
    // Vérifie si certaine lignes sont vides sauf celle du haut
    public static void verifLine()
    {

        for (int i = 1; i < lignes.Count - 1; i++)
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
    // Vérifie si les lignes sont vides sauf celle du bas
    public static void verifLineHaut()
    {
        for (int i = 0; i < lignes.Count - 1; i++)
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
    //Modifie l'indice d'une ligne
    public void modifierText(int index)
    {
        index++;
        string num = index.ToString();
        text.GetComponent<TMP_Text>().text = num;
    }
    //Vérifie si toutes les lignes présentes sont conformes et ont le bon indice
    public static void verifIndice()
    {
        int index = 0;
        foreach (Ligne ligne in lignes)
        {
            ligne.modifierText(index);
            index++;
        }
    }
    // Permets de créer la liste de Bloc contenue dans les lignes pour rouler le programme
    public static List<Bloc> CreerListeBloc()
    {
        List<Bloc> blocs = new List<Bloc>();
        foreach (Ligne ligne in lignes)
        {
            if (ligne.GetComponentInChildren<Bloc>() != null)
            {
                blocs.Add(ligne.GetComponentInChildren<Bloc>());
            }

        }
        return blocs;
    }
    //Permets de vider la liste de Ligne lorsqu'on quitte un niveau ou qu'elle doit être vider
    public static void viderList()
    {
        lignes.Clear();
    }
}
