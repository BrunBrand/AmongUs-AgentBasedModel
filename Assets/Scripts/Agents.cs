using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Agents : MonoBehaviour{

    public Slider sliderAgent;
    public Slider sliderImpostor;

    public GameObject[] crewList;
    public GameObject crewArray;
    public GameObject[] prefabs;

    private int[] _impostorChooser;

    public CrewMate crew;


    public Vector3[] spawnArea;

    public int randomTask;
    List<int> receiveTaskList = new List<int>();

    private int counter;

    GameObject crewMate;

    public bool startButtonIsClicked;


    public int numberOfAgents;

    public int numberOfImpostor;

    public int count;
    void Awake(){

        numberOfAgents = (int)sliderAgent.value;
        numberOfImpostor = (int)sliderImpostor.value;
        _impostorChooser = new int[numberOfImpostor];
        count = 0;
        startButtonIsClicked = false;
        if (startButtonIsClicked)
        {
            StartAgents();
        }
    }

    public void StartAgents()
    {

        numberOfAgents = (int)sliderAgent.value;
        numberOfImpostor = (int)sliderImpostor.value;
        Debug.Log(numberOfImpostor);
        _impostorChooser = new int[numberOfImpostor + 1];
        Debug.Log(_impostorChooser.Length);
        count = 0;

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


        for (int i = 0; i < numberOfImpostor; i++)
        {

            _impostorChooser[i] = Random.Range(0, numberOfAgents);
            Debug.Log("IMPOSTOR CHOOSER" + _impostorChooser[i]);
        }
        for (int i = 0; i < numberOfAgents; i++)
        {
            crewMate = Instantiate(prefabs[i], spawnArea[i], Quaternion.identity);
            crewMate.transform.parent = crewArray.transform;

            crewList = GameObject.FindGameObjectsWithTag("Agent");
            CrewMate crewMateScript = crewMate.gameObject.GetComponent<CrewMate>();
            foreach (GameObject go in crewList)
            {
                
                if (i == _impostorChooser[count])
                {
                    crewMateScript.isImpostor = true;
                    //crewMateScript.gameObject.layer = 10; // we don't assign the impostor layer because we use the crewmate layer to search for targets
                    crewMateScript.gameObject.layer = 8;
                    crewMateScript.tag = "Impostor";
                }
                else
                {
                    crewMateScript.gameObject.layer = 8;
                    crewMateScript.tag = "Crewmate";
                }
                count++;
                if (count == numberOfImpostor)
                {
                    count = 0;
                }



            }
        }
    }
    


    // Update is called once per frame
    void Update()
    {

    }

}
