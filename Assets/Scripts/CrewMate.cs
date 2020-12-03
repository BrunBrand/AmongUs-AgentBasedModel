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
    public GameObject[] data;

    // the impostor vent positions

    public int index; // decides wich index of dataPosition the position of data obj will be stored
    public int decision; // make a decision in the start of the game, and whe the objetive is done
    public float wait; //wait when reaching the objective for complete
                       // the wait attribute is only available in certain tasks

    public bool firstMove;

    public float waitPattern; // the constant value of wait;



    public Vector3[] dataPosition;

    void Start(){
        firstMove = true;
        receiveTask = 10;
        index = 0;
        wait = 5;
        dataPosition = new Vector3[3];        

        data = GameObject.FindGameObjectsWithTag("Data");
        
        foreach(GameObject obj in data){

            dataPosition[index] = obj.transform.position;
            index++;
        }

        if (!isImpostor){
            for (int i = 0; i < 6; i++){
                receiveTask = Random.Range(0, 7); //define which task the crewmate is going to peform
                Debug.Log("receveid task is: " + receiveTask);
            }
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


    public void MakeADecision(){
        decision = Random.Range(0, 3);
        Debug.Log("Is making a decision, has decided " + decision);
        firstMove = false;
    }


    public void GoToObjectives() {

        switch (receiveTask) {
            case 6:
                Debug.Log("is goin to to objective");
                agent.SetDestination(dataPosition[decision]);
                Debug.DrawRay(agent.transform.position, dataPosition[decision]);
                if (dataPosition[decision].magnitude < 2f && wait >= 0){
                    while (wait >= 0)
                    {
                        Debug.Log("Is waiting for completition");
                        wait -= Time.deltaTime;
                    }
                    Debug.Log("Task Completed");
                    MakeADecision();
                }
                if (firstMove){
                    MakeADecision();
                }
                break;
        }
    }


    public void ReportBody(){

    }


    public void CallEmergency(){

    }








}
