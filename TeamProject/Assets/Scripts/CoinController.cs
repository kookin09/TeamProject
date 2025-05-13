using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [플레이어가 코인과 충돌시]
// 코인추가
// 코인파괴 - 이펙트걸기

// 코인 저장 - 상점에서 골드로 아이템 구입

// 맵에 코인 배치?

public class CoinController : MonoBehaviour
{
    private int bigCoin = 50; //빅코인 아이템의 골드값
    private int smallCoin = 10; //스몰코인 아이템의 골드값
    public static int gold = 0; //골드
    private float moveSpeed = 5f;
    public float targetRangeX;
    
    [SerializeField] private GameObject target;
    [SerializeField] private ParticleSystem coinDestroyEffectSystem; //코인아이템 충돌시 이펙트

    void Start()
    {
        Vector3 targetPos = target.transform.position;
        targetRangeX = targetPos.x + 10f;
    
    }
    void Update()
    {
        transform.Translate(Vector3.zero * Time.deltaTime);

        // 화면 벗어나면 풀로 반환
        if (transform.position.x < targetRangeX)
        {
            PoolManager pool = FindObjectOfType<PoolManager>();
            pool.ReturnToPool(ObjectType.smallCoin, this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(gameObject.name == "BigCoin")
            {
                gold += bigCoin;
                Debug.Log($"BigCoin : {gold}");
            }

            else if(gameObject.name == "SmallCoin")
            {
                gold += smallCoin;
                Debug.Log($"SmallCoin : {gold}");
            }

            Destroy(gameObject);
            CoinDestroyEffect();
        
        }
    }
    
    // 코인아이템 획득시 골드증가

    public void CoinDestroyEffect()
    {
        coinDestroyEffectSystem.Stop();
        coinDestroyEffectSystem.Play();
    }
    
}
