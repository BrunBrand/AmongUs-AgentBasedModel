using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class CrewMate : MonoBehaviour{

    public NavMeshAgent agent;
    public Agents agente;

    public bool isImpostor;

    // to wander
    private float _randomX;
    private float _randomZ;
    Vector3 wander;


    public int[] receiveTask;

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


    public Vector3 positionOfDraw;

    GameObject[] allCrewMembers;

    public int[] tasksArray;

    //private int tasks = 9;

    public int counter = 0;

    public Vector3[] spawnArea =     {new Vector3(-9.19386578f,0.356f,14.1794643f),
                                     new Vector3(-2.86f, 0.356f, 12.58f),
                                     new Vector3(0.1744623f, 0.356f, 7.133203f),
                                     new Vector3(0.806316f, 0.356f,1.287264f),
                                     new Vector3(-2.45715f, 0.356f, -4.005596f),
                                     new Vector3(-7.880685f, 0.356f, -6.942453f),
                                     new Vector3(-14.45415f, 0.356f, -6.030566f),
                                     new Vector3(-19.25f, 0.356f, -0.68f),
                                     new Vector3(-19.8600006f,0.356f,6.80000019f),
                                     new Vector3(-15.6599998f,0.356f,12.4300003f),


        };

    void Start(){


        


        firstMove = true;
        receiveTask = new int[5];
        receiveTask[0] = 10;
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

        allCrewMembers = FindGameObjecstWithLayer(8);
        

        if (!isImpostor){
            for (int i = 0; i < receiveTask.Length; i++){
                receiveTask[i] = Random.Range(0, 7);
            }

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
            index = 0;
            foreach( GameObject obj in explosion)
            {
                explosionPosition[index] = obj.transform.position;
                index++;
            }

            scanPosition = scan.transform.position;
            

            padPosition = pad.transform.position;
            walletPosition = wallet.transform.position;
            o2Position = o2.transform.position;




        }
    }


    public void GoToSpawnArea(){
        for( int i = 0; i < 9; i++)
        {
            allCrewMembers[i].transform.position = spawnArea[i];
        }
    }

 
    public GameObject[] FindGameObjecstWithLayer(int layer){
        GameObject[] gameObjectArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List<GameObject> gameObjectList = new List<GameObject>();
        for(int i = 0; i < gameObjectArray.Length; i++)
        {
            if(gameObjectArray[i].layer == layer)
            {
                gameObjectList.Add(gameObjectArray[i]);
            }
        }
        if(gameObjectList.Count == 0)
        {
            return null;
        }
        return gameObjectList.ToArray();
    }

    void Update(){

        switch (isImpostor){
            case true:
                Wander();
                break;

            case false:
                GoToObjectives();
                Debug.DrawLine(agent.transform.position, positionOfDraw);
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
        for (int i = 0; i < receiveTask.Length; i++) {
            switch (receiveTask[i]) {
                case 0:
                    Debug.Log("is goin to to objective");
                    agent.SetDestination(dataPosition[decision]);
                 
                    positionOfDraw = dataPosition[decision];
                    if (Vector3.Distance(dataPosition[decision], agent.transform.position) < 2f)
                    {
                        /*while (wait >= 0)
                        {
                            Debug.Log("Is waiting for completition");
                            wait -= Time.deltaTime;
                        }*/
                        Invoke("MakeADecision", 5);
                        Debug.Log("Task Completed");
                        //MakeADecision();
                    }
                    if (firstMove)
                    {
                        MakeADataDecision();
                    }
                    break;

                case 1:
                    agent.SetDestination(cablePosition[decision]);
          
                    positionOfDraw = cablePosition[decision];
                    if (firstMove)
                    {
                        MakeADataDecision();
                    }
                    break;

                case 2:
                    agent.SetDestination(enginePosition[decision]);
           
                    positionOfDraw = enginePosition[decision];
                    if (firstMove)
                    {
                        MakeADataDecision();
                    }
                    break;

                case 3:
                    agent.SetDestination(trashPosition[decision]);
            
                    positionOfDraw = trashPosition[decision];
                    if (firstMove)
                    {
                        MakeADataDecision();
                    }
                    break;

                case 4:
                    agent.SetDestination(scanPosition);
       
                    positionOfDraw = scanPosition;
                    break;

                case 5:
                    agent.SetDestination(walletPosition);
                    positionOfDraw = walletPosition;
                    break;

                case 6:
                    agent.SetDestination(padPosition);
                    positionOfDraw = padPosition;
                    break;
                }
            }
        }
    

    public void ApproachDeadBody(Transform target){
        //Agents agente = gameObject.GetComponent<Agents>();
        agent.SetDestination(target.position);
        if(Vector3.Distance(agent.transform.position, target.position) < 5f){
            ReportBody();
      
        }
    }


    public void ReportBody(){


        GoToSpawnArea();
        
    }


    public void CallEmergency(){

    }








}
