using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

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

    public GameObject[] crewmates;
    
    
    public GameObject[] data; // catch the data gameobject and put it in a array with his tag
    public GameObject[] cable; // the eletric cables
    public GameObject[] engine; // the fuel + engine
    public GameObject[] trash; // the door that opens to get the trash out
    
    public Vector3[] dataPosition;
    public Vector3[] cablePosition;
    public Vector3[] enginePosition;
    public Vector3[] trashPosition;

    // -- not a task but a sabotage task
    public GameObject[] explosion;
    public Vector3[] explosionPosition;

    // tasks that don't need arrays
    public GameObject scan;
    public GameObject pad;
    public GameObject wallet;

    public Vector3 scanPosition;
    public Vector3 padPosition;
    public Vector3 walletPosition;

    // -- not a task but a sabotage task (the original game has 2, but i will have only one)
    public GameObject o2;

    public Vector3 o2Position;
    // the impostor vent positions

    public int index; // decides wich index of dataPosition the position of data obj will be stored
    public int decision; // make a decision in the start of the game, and whe the objetive is done
    public float wait; //wait when reaching the objective for complete
                       // the wait attribute is only available in certain tasks

    public bool firstMove;

    public float waitPattern; // the constant value of wait;



    public List<int> receiveTaskList = new List<int>();


    

    public int[] tasksArray;

    //private int tasks = 9;

    public int counter = 0;

    void Start(){
        firstMove = true;
        receiveTask = 10;
        index = 0;
        wait = 5;
        dataPosition = new Vector3[3];
        cablePosition = new Vector3[3];
        enginePosition = new Vector3[3];
        trashPosition = new Vector3[3];


        explosionPosition = new Vector3[2];

      

        data = GameObject.FindGameObjectsWithTag("Data");
        cable = GameObject.FindGameObjectsWithTag("Cable");
        engine = GameObject.FindGameObjectsWithTag("Engine");
        trash = GameObject.FindGameObjectsWithTag("Trash");

        explosion = GameObject.FindGameObjectsWithTag("Explosion");

        scan = GameObject.FindGameObjectWithTag("Scan");
        pad = GameObject.FindGameObjectWithTag("Pad");
        wallet = GameObject.FindGameObjectWithTag("Wallet");

        o2 = GameObject.FindGameObjectWithTag("O2");


        crewmates = GameObject.FindGameObjectsWithTag("Crewmate");


       


        if (!isImpostor){

            receiveTask = Random.Range(0, 7);
            /*foreach (GameObject go in crewmates)
            {
                if (go.tag == "Impostor")
                {
                    break;
                }
                else if (go.tag == "Crewmate")
                {
                    //receiveTask = receiveTaskList[counter];
                  
                    receiveTask = tasksArray[counter];
                    Debug.Log("RECEIVE TASK É : " + receiveTask);
                    counter++;
                }
            }*/

     

            foreach (GameObject obj in data)
            {

                dataPosition[index] = obj.transform.position;
                index++;
            }
            index = 0;
            foreach (GameObject obj in cable)
            {
                Debug.Log("O INDEX DO ELEMENTO É " + index);
                cablePosition[index] = obj.transform.position;
                index++;
            }
            index = 0;
            foreach (GameObject obj in engine)
            {
                enginePosition[index] = obj.transform.position;
                index++;
            }
            index = 0;
            foreach (GameObject obj in trash)
            {
                trashPosition[index] = obj.transform.position;
                index++;
            }





        }
    }



    



    void Update(){

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


    public void MakeADataDecision(){
        decision = Random.Range(0, 3);
    
      
        Debug.Log("Is making a decision, has decided " + decision);
        firstMove = false;
    }


    public void GoToObjectives() {

        switch (receiveTask) {
            case 0:
                agent.SetDestination(cablePosition[decision]);
                Debug.DrawRay(agent.transform.position, cablePosition[decision]);
                break;

            case 1:
                agent.SetDestination(enginePosition[decision]);
                Debug.DrawRay(agent.transform.position, enginePosition[decision]);
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            case 6:
                Debug.Log("is goin to to objective");
                agent.SetDestination(dataPosition[decision]);
                Debug.DrawRay(agent.transform.position, dataPosition[decision]);
                if (Vector3.Distance(dataPosition[decision], agent.transform.position) < 2f){
                    /*while (wait >= 0)
                    {
                        Debug.Log("Is waiting for completition");
                        wait -= Time.deltaTime;
                    }*/
                    Invoke("MakeADecision", 5);
                    Debug.Log("Task Completed");
                    //MakeADecision();
                }
                if (firstMove){
                    MakeADataDecision();
                }
                break;
        }
    }


    public void ReportBody(){

    }


    public void CallEmergency(){

    }








}
