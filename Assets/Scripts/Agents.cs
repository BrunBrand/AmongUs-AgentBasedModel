using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agents : MonoBehaviour{

    public GameObject[] crewList;
    public GameObject crewArray;
    public GameObject[] prefabs;

    private int _impostorChooser;

    CrewMate crew = new CrewMate();


    Vector3[] spawnArea;

    
    void Start(){
        Vector3[] spawnArea = new [] {new Vector3(-12.5f, 1.52f, 5.7f), new Vector3(-10.23f, 1.52f, 7.52f), new Vector3(-7.26f, 1.52f, 7.52f),
                                      new Vector3(-4.48f, 1.52f,5.7f), new Vector3(-12.5f, 1.52f, 3.46f), new Vector3(-10.23f, 1.52f, 1.83f),
                                      new Vector3(-7.26f, 1.52f, 1.83f), new Vector3(-4.48f, 1.52f, 3.46f)};
        
        _impostorChooser = Random.Range(0, 8);
        for (int i = 0; i < prefabs.Length; i++){
            GameObject crewMate =  Instantiate(prefabs[i], spawnArea[i], Quaternion.identity);
            crewMate.transform.parent = crewArray.transform;
           
            crewList = GameObject.FindGameObjectsWithTag("Crewmate");
            CrewMate crewMateScript = crewMate.gameObject.GetComponent<CrewMate>();
            foreach (GameObject go in crewList){
                if(i == _impostorChooser){
                    crewMateScript.isImpostor = true;
                }
            }


        }






    }

    

    // Update is called once per frame
    void Update(){
        
    }
}
