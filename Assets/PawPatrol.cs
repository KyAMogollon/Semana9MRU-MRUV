using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawPatrol : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField]
    public List<ControlPoints> controlPoints;
    public ControlPoints currentPatrol;
    public int currentPosition = 0;
    float currentTime;
    Vector3 velocidad;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        currentTime = currentPatrol.GetTime();
        currentPatrol = controlPoints[currentPosition];
        velocidad = (currentPatrol.transform.position - transform.position) / currentTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = velocidad;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point")
        {
            if (currentPosition == controlPoints.Count - 1)
            {
                currentPosition = 0;
                currentPatrol = controlPoints[currentPosition];
                currentTime= currentPatrol.GetTime();
            }
            else
            {
                currentPosition++;
                currentPatrol = controlPoints[currentPosition];
                currentTime= currentPatrol.GetTime();
            }
            velocidad = (currentPatrol.transform.position - transform.position) / currentTime;
        }
    }
}
