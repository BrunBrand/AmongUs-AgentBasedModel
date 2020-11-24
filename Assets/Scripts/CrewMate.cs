using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMate : MonoBehaviour{
    
    public bool isImpostor;



    void Start(){
        
    }

    
    void Update(){
        Debug.Log("is impostor: " + isImpostor);
    }



    public void GoToObjectives(){
        if (isImpostor){
            return;
        }





    }

}
