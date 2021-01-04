using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
                
        //앞쪽방향(z축)으로 스피드만큼 이동
        bulletRigidbody.velocity = transform.forward * speed;

        //3초 뒤에 자신의 게임오브젝트 파괴
        Destroy(gameObject, 3f);
    }
    // 충돌
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); //platerController스크립트 가져옴(public클래스여서 가져오기 가능)

            if(playerController != null)
            {
                playerController.Die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
