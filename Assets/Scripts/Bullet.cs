using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    internal float speed;
    [SerializeField] float _speed;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
