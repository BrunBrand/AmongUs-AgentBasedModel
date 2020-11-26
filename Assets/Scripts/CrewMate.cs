using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CrewMate : MonoBehaviour{

    public NavMeshAgent agent;

    public bool isImpostor;

    // to wander
    private float _randomX;
    private float _randomZ;
    Vector3 wander;


    public int receiveTask;

    public Transform roundTable; // the table with the emergency button

    //  all the objects position


    public Transform medBay; // the scan in medbay
    public Transform[] reactor; // first, use the fuel and then fill the engines, it's four movements
    public Transform[] electricCables; // the eletric cables, i think that's 3 
    public Transform wallet; // the one that you have to pass you card slowly...
    public Transform[] trash; // there are 3 trashes in the game, but my map will have just 2
    public Transform pad; // the one in reactor where you need to follow the block pattern


    // the impostor vent positions






    void Start(){

        for(int i=0; i< 6; i++){
            receiveTask = Random.Range(0, 6);
            Debug.Log(receiveTask);
        }
    
    }

    
    void Update(){
        Debug.Log("is impostor: " + isImpostor);


        switch (isImpostor){
            case true:
                Wander();
                break;

            case false:
                GoToObjectives();
                break;
        }


    }

    // ---------- Impostor Methods ---------- //
    public void Wander(){
        _randomX = Random.Range(-10, 10);
        _randomZ = Random.Range(-10, 10);

        wander = new Vector3(_randomX, 0, _randomZ);
        agent.SetDestination(wander);
    
    }

    public void Sabotage(){









    }


    public void Kill(){

    }


    // ---------- CrewMate Methods ---------- //

    public void GoToObjectives(){
        





    }


    public void ReportBody(){

    }


    public void CallEmergency(){

    }








}
