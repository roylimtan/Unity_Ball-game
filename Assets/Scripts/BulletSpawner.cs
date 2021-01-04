using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;   //탄알 생성시 사용할 프리펩
    public float spawnRateMin = 0.5f;   //새 탄알 생성시 걸리는 최소 시간
    public float spawnRateMax = 3.0f;   //새 탄알 생성시 걸리는 최대 시간

    private Transform target;    //조준할 대상 
    private float spawnRate;     //spawnRateMin~spawnRateMax 사이의 랜덤 값
    private float timeAfterSpawn;  //마지막 탄알 생성 시점으로부터 시간의 흐름을 표시할 타이머

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;   //PlayerController를 가진 오브젝트를 찾아 대상으로 지정
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }    
    }
}
