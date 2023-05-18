using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] Vector3 velocidad;
    [SerializeField] Vector3 V0;
    [SerializeField] Vector3 acelaracion;
    [SerializeField] float time;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        velocidad = V0*time+(acelaracion*time*time)/2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        _rb.velocity = velocidad;
    }
}
