using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinController : MonoBehaviour
{
    private int bigCoin = 50; //빅코인 아이템의 골드값
    private int smallCoin = 10; //스몰코인 아이템의 골드값
    private int coinBundle = 130; //코인번들 아이템의 골드값    
    // public float targetRangeX;
    
    [SerializeField] private GameObject target;
    [SerializeField] private ParticleSystem coinDestroyEffectSystem; //코인아이템 충돌시 이펙트
    UIManager uiManager;
    void Start()
    {
        // Vector3 targetPos = target.transform.position;
        // targetRangeX = targetPos.x + 10f;

        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();



        Debug.Log(uiManager);
    
    }
    void Update()
    {
        // transform.Translate(Vector3.zero * Time.deltaTime);

        // // 화면 벗어나면 풀로 반환
        // // if (transform.position.x < targetRangeX)
        // // {
        //     PoolManager pool = FindObjectOfType<PoolManager>();
        //     pool.ReturnToPool(ObjectType.smallCoin, this.gameObject);
        // // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어가 골드에 부딪힘");
            if(gameObject.name.StartsWith("BigCoin"))
            {
                uiManager.AddGold(bigCoin);
                CoinDestroyEffect();
            }

            else if(gameObject.name.StartsWith("SmallCoin"))
            {
                uiManager.AddGold(smallCoin);
                CoinDestroyEffect();

            }

            else if(gameObject.name.StartsWith("CoinBundle"))
            {
                uiManager.AddGold(coinBundle);
                CoinDestroyEffect();
            }  
            Destroy(gameObject);
        
        }
    }
    

    public void CoinDestroyEffect()
    {
        coinDestroyEffectSystem.Stop();
        coinDestroyEffectSystem.Play();
    }


    
}
