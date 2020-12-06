using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agents : MonoBehaviour
{

    public GameObject[] crewList;
    public GameObject crewArray;
    public GameObject[] prefabs;

    private int _impostorChooser;

    public CrewMate crew;


    public Vector3[] spawnArea;

    public int randomTask;
    List<int> receiveTaskList = new List<int>();

    private int counter;

    GameObject crewMate;


    void Awake()
    {
        Vector3[] spawnArea =       {new Vector3(-9.19386578f,0.356f,14.1794643f),
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

    

        _impostorChooser = Random.Range(0, 9);
        for (int i = 0; i < prefabs.Length; i++)
        {
            crewMate = Instantiate(prefabs[i], spawnArea[i], Quaternion.identity);
            crewMate.transform.parent = crewArray.transform;

            crewList = GameObject.FindGameObjectsWithTag("Agent");
            CrewMate crewMateScript = crewMate.gameObject.GetComponent<CrewMate>();
            foreach (GameObject go in crewList)
            {
                if (i == _impostorChooser)
                {
                    crewMateScript.isImpostor = true;
                    //crewMateScript.gameObject.layer = 10;
                    crewMateScript.gameObject.layer = 8;
                    crewMateScript.tag = "Impostor";
                }
                else
                {
                    crewMateScript.gameObject.layer = 8;
                    crewMateScript.tag = "Crewmate";
                }
            }

            /*foreach(GameObject go in crewList){

                if (crew.receiveTask != 10 && !crew.isImpostor) {

                    while (!receiveTaskList.Contains(randomTask))
                    {
                        randomTask = Random.Range(0, 6);
                        if (receiveTaskList)
                        {
                            receiveTaskList.Add(randomTask);
                            crew.receiveTask = randomTask;
                        }
                    }
                    
                }
            }*/
        }
           
          



        






    }



    /*public void GoToSpawnArea(){
        for(int i = 0; i < 9 ; i++){
            prefabs[i].transform.position = spawnArea[i];
        }

    }*/

    // Update is called once per frame
    void Update()
    {

    }

}
