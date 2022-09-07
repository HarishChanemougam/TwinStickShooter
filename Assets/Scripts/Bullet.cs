using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    internal float speed;
    [SerializeField] float _speed;
    [SerializeField] float _lifeTime;
    [SerializeField] int _damageToGive;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        _lifeTime -= Time.deltaTime;

        if(_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnmeyHealth>().HurtEnmey(_damageToGive);
            Destroy(gameObject);
        }
    }
}
