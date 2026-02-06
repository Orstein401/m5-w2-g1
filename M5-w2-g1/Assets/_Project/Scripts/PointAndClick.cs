using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClick : MonoBehaviour
{
    private float h;
    private float v;
    private Camera cam;

    private NavMeshAgent agentNav;

    private void Awake()
    {
        cam = Camera.main;
        agentNav = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            PointMove();
        }
        if (dir != Vector3.zero)
        {
            agentNav.SetDestination(dir+transform.position);
            //agentNav.velocity = dir*agentNav.speed;
        }


    }
    public void PointMove()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitinfo);
        Vector3 destination = hitinfo.point;
        agentNav.SetDestination(destination);
    }

}
