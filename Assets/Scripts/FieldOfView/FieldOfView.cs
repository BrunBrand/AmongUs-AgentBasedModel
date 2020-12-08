using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour{

    public float viewRadius;
    [Range(0, 360)] public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public CrewMate crew;

    public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets(){
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        if (crew.isImpostor)
        {
            Debug.Log("CREW IMPOSTOR BEFORE IF" + targetsInViewRadius.Length);
            if (targetsInViewRadius.Length == 2){
                Debug.Log("After target Length equals to 2 " + targetsInViewRadius.Length + " And 0 index have"  + targetsInViewRadius[0]
                    + " and has a value in 1 index of: " + targetsInViewRadius[1]);
                crew.Kill(targetsInViewRadius);
            }
        }
        for(int i = 0; i < targetsInViewRadius.Length; i++){
            Transform target = targetsInViewRadius[i].transform;
            
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    if (!crew.isImpostor)
                    {
                        if (target.gameObject.tag == "Dead")
                        {
                            crew.ApproachDeadBody(target);
                            //crew.agent.SetDestination(target.position); // Approaching dead body

                        }
                    }
                 
                    
                    
                    
                }

            
            }
        }
    }


    public Vector3 DirFromAngle( float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees* Mathf.Deg2Rad));
    }


    

  
    void Update(){
        


    }
}
