using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform[] points;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody rb;
    public List<Vector3> dists = new List<Vector3>();
    private bool forward = true;

    private void Start()
    {
        dists.Add(points[0].position);
        dists.Add(points[1].position);
    }

    private void FixedUpdate()
    {
     
        if (forward)
        {
            transform.position = Vector3.MoveTowards(transform.position,dists[0], moveSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position,dists[0])<0.5) forward=false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,dists[1], moveSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position,dists[1])<0.5) forward=true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
