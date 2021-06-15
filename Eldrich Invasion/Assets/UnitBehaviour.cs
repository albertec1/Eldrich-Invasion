using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitBehaviour : MonoBehaviour
{

    public Transform Target;
    public int Hp;
    private NavMeshAgent agente;
    public Vector3 size;
    public Vector3 center;


    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(Target.position);

        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void GizmoColor()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("target"))
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage) //should be private, only public for testing
    {
        Hp -= damage;
    }
}
