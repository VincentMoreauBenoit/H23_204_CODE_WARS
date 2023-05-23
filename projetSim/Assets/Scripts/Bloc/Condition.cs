using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;


//Permets de créer et de vérifier la condition d'un bloc if
public class Condition
{
    private GameObject objet;

    private int indiceOperation;

    private int indicePersoBase;

    public Condition(GameObject objet, int indiceOperation, int indicePersoBase){
        this.objet = objet;
        this.indiceOperation = indiceOperation;
        this.indiceOperation = indiceOperation;
    }

    // Vérifie la condition du bloc
    public bool verifier(){
        if(indiceOperation != 0 && indiceOperation !=1){
            return verifierHealth();
        }else{
            return checkClass();
        }
    }
    //Vérifie si la vie est conforme 
    private bool verifierHealth(){
        float vie = objet.GetComponent<Personnage>().getVie();
        if(indiceOperation%2 == 0 ){
            if(vie<=120){
                if(indiceOperation == 4){
                    if(vie!= 120){
                        return true;
                    }else{
                        return false;
                    }
                }
                
                if(indiceOperation == 2){
                    return true;
                }else{
                    return false;
                }
            }else{
                return false;
            }
        }else{
            if(vie>=100){
                if(indiceOperation == 5){
                    if(vie!= 100){
                        return true;
                    }else{
                        return false;
                    }
                }
                
                if(indiceOperation == 3){
                    return true;
                }else{
                    return false;
                }
            }else{
                return false;
            }
        }
    }
    //Vérifie si la classe de la troupe est bien celle choisi à l'arrière
    private bool checkClass(){
        if(objet.GetComponent<Archer>() != null){
            if(indicePersoBase == 0){
                return true;
            }else{
                return false;
            }
        }
        if(objet.GetComponent<Barbare>() != null){
            if(indicePersoBase == 1){
                return true;
            }else{
                return false;
            }

        }
        if(objet.GetComponent<Infanterie>() != null){
            if(indicePersoBase == 2){
                return true;
            }else{
                return false;
            }

        }
        if(objet.GetComponent<Mage>() != null){
            if(indicePersoBase == 3){
                return true;
            }else{
                return false;
            }

        }

        return false;

    }
}
