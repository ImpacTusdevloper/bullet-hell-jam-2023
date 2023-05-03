using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class EnemyHit : MonoBehaviour
{
    private EnemyHealth _eC;
    
    [SerializeField] private int healthToReduce = 5;
    // Start is called before the first frame update
    void Start()
    {
        _eC = GetComponent<EnemyHealth>();
    }

    public void OnBulletHit(BulletContainer bCon, BulletCollider bCol)
    {
        _eC.ReduceEnemyHealth(healthToReduce);
        _eC.CheckEnemyHealth(); 
    }
}
