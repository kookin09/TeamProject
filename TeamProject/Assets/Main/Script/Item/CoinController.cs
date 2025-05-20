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
    Player player;
    public ItemPoolManager pool;
    Spawner spawner;

    void Start()
    {
        // Vector3 targetPos = target.transform.position;
        // targetRangeX = targetPos.x + 10f;

        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        pool = GameObject.Find("ItemPoolManager").GetComponent<ItemPoolManager>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if(gameObject.name.StartsWith("BigCoin"))
            {
                uiManager.AddGold(bigCoin);
                
                pool.ReturnToPool(ObjectType.bigCoin, this.gameObject);
                foreach (var pair in pool.pools)
                {
                    Debug.Log($"Type: {pair.Key}, Count: {pair.Value.Count}");
                }
            }
            else if(gameObject.name.StartsWith("SmallCoin"))
            {
                uiManager.AddGold(smallCoin);
                StartCoroutine(PlayEffectAndReturn(ObjectType.smallCoin));
                // pool.ReturnToPool(ObjectType.smallCoin, this.gameObject);
                spawner.PlayDestroyEffect(transform.position);
            }
            else if(gameObject.name.StartsWith("CoinBundle"))
            {
                uiManager.AddGold(coinBundle);
                pool.ReturnToPool(ObjectType.coinBundle, this.gameObject);
            }  
            
        
        }
    }
    

    public void CoinDestroyEffect()
    {
        coinDestroyEffectSystem.Stop();
        coinDestroyEffectSystem.Play();
        Debug.Log("이펙트 실행중");
        
    }
    

        private IEnumerator PlayEffectAndReturn(ObjectType type)
    {
        // 이펙트 위치 옮기고 재생
        coinDestroyEffectSystem.transform.position = transform.position;
        coinDestroyEffectSystem.Play();

        float waitTime = 0.2f;

        yield return new WaitForSeconds(waitTime);

        // 코인을 풀로 되돌리기
        pool.ReturnToPool(type, this.gameObject);
    }
}
