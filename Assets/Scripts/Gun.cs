using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    internal bool isFiring;
    [SerializeField] bool _IsFiring;
    [SerializeField] Bullet _bullet;
    [SerializeField] float _bulletSpeed;
    [SerializeField] float _timeBetweenShots;
    [SerializeField] Transform _firePoint;

    private float _shotCounter;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(_IsFiring)
        {
            _shotCounter -= Time.deltaTime;
            if(_shotCounter <= 0)
            {
                _shotCounter = _timeBetweenShots;
               Bullet newBullet =  Instantiate(_bullet, _firePoint.position, _firePoint.rotation) as Bullet;
                newBullet.speed = _bulletSpeed;
            }
            else
            {
                _shotCounter = 0;
            }
        }
    }
}
