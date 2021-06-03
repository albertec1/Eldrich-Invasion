using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            KeepScore.Score += 50;
            Debug.Log("space pressed");
        }

    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Firebolt")
        {
            KeepScore.Score += 50;
            Debug.Log("Firebolt hit");
            Destroy(gameObject);
        }
    }

}
