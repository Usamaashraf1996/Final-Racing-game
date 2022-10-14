using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRight : MonoBehaviour
{
    private Rigidbody enemyrb;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAi();
    }

    void EnemyAi()
    {

        enemyrb.AddForce(Vector3.right * speed, ForceMode.Force);
        if (transform.position.x > 110) { 
        
        Destroy(gameObject);
        }
    }
}
