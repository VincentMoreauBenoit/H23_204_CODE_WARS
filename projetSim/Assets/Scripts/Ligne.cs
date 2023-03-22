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

        int index = 0;
        foreach(Ligne ligne in lignes)
        {
            ligne.modifierText(index);
            index++;
        }
    }
    public static void verifLine()
    { 
        
        for(int i = 1; i< lignes.Count;i++)
        {
            var rect = lignes[i].GetComponent<RectTransform>();
            if (rect.childCount != 2)
            {
                lignes.RemoveAt(i);
                Destroy(rect.gameObject);
                i--;
            }
        }
        var toutPlein = true;
        for(int i = 0; i< lignes.Count; i++)
        {
            var rect = lignes[i].GetComponent<RectTransform>();
            if (rect.childCount != 2)
            {
                toutPlein= false;
            }
        }
        if (toutPlein) { }

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
}
