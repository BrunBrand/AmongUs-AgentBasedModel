using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomTasks : MonoBehaviour
{
    public CrewMate crew;

    public GameObject[] crewmates;
    public int counter = 0;
    public int[] tasksArray;
    public List<int> receiveTaskList = new List<int>();
    private int tasks = 9;


    void Start(){

        crewmates = GameObject.FindGameObjectsWithTag("Crewmate");



      




    }



    /*public void RandomizeTask()
    {
        for (int i = 0; i < tasks; i++)
        {
            receiveTaskList.Add(i);
        }

        tasksArray = receiveTaskList.OrderBy(tvz => System.Guid.NewGuid()).ToArray();

        for (int i = 0; i < tasks; i++)
        {
            print(receiveTaskList[i]);
        }

        foreach (GameObject go in crewmates)
        {
            if (go.tag == "Impostor")
            {
                break;
            }
            else if (go.tag == "Crewmate")
            {
                //receiveTask = receiveTaskList[counter];

                crew.receiveTask = crew.tasksArray[counter];
                Debug.Log("RECEIVE TASK É : " + crew.receiveTask);
                counter++;
            }
        }
    }*/


    // Update is called once per frame
    void Update()
    {
        
    }
}
