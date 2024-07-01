using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ClickToScreen : MonoBehaviour
{
   private NavMeshAgent agent;
   public LayerMask layerMask;
   RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       if( Physics.Raycast(Ray.origin,Ray.direction, out hit,100,layerMask))
        {
            agent.destination = hit.point;
        }
    }
}
