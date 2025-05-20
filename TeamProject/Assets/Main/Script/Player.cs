using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
 // 배경음과 효과음
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip slideSound;
    [SerializeField] private AudioClip DamageSound;
    [SerializeField] private AudioClip CoinSound;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource itemSource;
    private Animator animator;

    // 이동 속도와 점프 세기
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    private bool wasGrounded = false;
    private float coyoteTime = 0.1f;
    private float coyoteTimer = 0f;

    // 최대 점프 횟수 (2단 점프)
    public int maxJump = 2;
    private int jumpCount = 0;

    // Rigidbody2D 저장용
    private Rigidbody2D rb;

    // 땅 체크용 변수
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    // 슬라이드 관련 설정
    public Vector2 slideScale = new Vector2(1f, 0.5f); // 슬라이드 시 캐릭터 크기
    private bool isSliding = false;
    private float originalColliderRadius;
    private Vector2 originalColliderOffset;
    public float slideColliderRadius = 0.3f;
    private Vector2 slideColliderOffset = new Vector2(0f, 0.3f);
    private CircleCollider2D circleCollider;

    private Vector2 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        originalScale = transform.localScale;
        originalColliderRadius = circleCollider.radius;
        originalColliderOffset = circleCollider.offset;
    }

    void Update()
    {
        Run();
        HandleJump();
        UpdateGroundState();
        HandleSlide();
    }

    // 자동으로 오른쪽 이동
    void Run()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    // 점프
    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // 기존 위속도 초기화
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("IsJump", true);
            sfxSource.PlayOneShot(jumpSound); 
            jumpCount++;
        }
        else
        {
            return;
        }
    }

    // 땅에 닿을 시 점프횟수 초기화
    void UpdateGroundState()
    {
        bool currentlyGrounded = IsGrounded();

        if (currentlyGrounded)
        {
            coyoteTimer = coyoteTime;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }
        
        if (!wasGrounded && currentlyGrounded)
        {
            jumpCount = 0;
            animator.SetBool("IsJump", false);
        }
        wasGrounded = currentlyGrounded;
    }


    // 슬라이드 입력 처리
    void HandleSlide()
    {
        // Shift 누르면 슬라이드 시작
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartSlide();
        }
        // Shift 떼면 슬라이드 종료
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            EndSlide();
        }
    }

    // 슬라이드 시작
    void StartSlide()
    {
        if (isSliding) return;
        isSliding = true;
        transform.localScale = slideScale; // 작아짐
        circleCollider.radius = slideColliderRadius;
        circleCollider.offset = slideColliderOffset;
        sfxSource.PlayOneShot(slideSound);
    }

    // 슬라이드 종료      
    void EndSlide()
    {
        isSliding = false;
        transform.localScale = originalScale; // 원래 크기로 복원
        circleCollider.radius = originalColliderRadius;
        circleCollider.offset = originalColliderOffset;
    }    

    // 땅 체크 (OverlapCircle 사용)
    bool IsGrounded()
    {   
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        return isGrounded;
    }
    
    private void OnDrawGizmosSelected()
    {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    // 피격
    public void Damage()
    {
        animator.SetBool("IsDamage", true);
        StartCoroutine(ResetDamageState());
        sfxSource.PlayOneShot(DamageSound);
    }
    IEnumerator ResetDamageState()
    {
        yield return new WaitForSeconds(1f); // 1초 대기
        animator.SetBool("IsDamage", false);
    }

    // 죽음 - 못 움직이게 함.
    public void Death()
    {
        rb.velocity = Vector3.zero;

        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Item"))
        {
            itemSource.PlayOneShot(CoinSound);
        }
    }
}

