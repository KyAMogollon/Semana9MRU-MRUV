using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    public Vector3 v0;
    public float time;
    public Vector3 aceleracion;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionDeseada = player.position+ v0*time+(aceleracion*time*time)/2;
        transform.position = Vector3.MoveTowards(transform.position, posicionDeseada, Time.deltaTime);
        time += Time.deltaTime;

    }
    private void FixedUpdate()
    {
        
    }
}
