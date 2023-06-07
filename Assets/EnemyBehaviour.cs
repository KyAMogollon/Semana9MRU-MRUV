using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    public float TimeToArrive=1f;
    public float CurrentTime=0;
    public float aceleracion;
    private float Vo;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        Vo = CalculateVelocidadInicial();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentTime < TimeToArrive)
        {
            Vector3 direccion=(player.position - transform.position).normalized;
            float distancia = Vo * CurrentTime + (aceleracion * CurrentTime * CurrentTime);
            Vector3 posicion = transform.position+ direccion*distancia;
            rb.MovePosition(posicion);
            CurrentTime +=Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    private float CalculateVelocidadInicial()
    {
        Vector3 direccion = (player.position - transform.position).normalized;
        float distancia = Vector3.Distance(transform.position, player.position);
        return (distancia - (aceleracion * Mathf.Pow(TimeToArrive, 2))) / TimeToArrive;
    }
}
