using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

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

    public bool verifier(){
        if(indiceOperation != 0 $$ indiceOperation !=1){
            return verifierHealth();
        }else{
            if(indiceOperation == 0){
                return true;
            }
        }
    }
    private bool verifierHealth(){
        int vie = objet.GetComponent<Personnage>().getVie();
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
        }
    }
}
