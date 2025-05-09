using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // 배경음과 효과음
    public AudioClip jumpSound;
    public AudioClip slideSound;
    public AudioSource sfxSource;


    // 이동 속도와 점프 세기
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    // 최대 점프 횟수 (2단 점프)
    public int maxJump = 2;
    private int jumpCount = 0;

    // Rigidbody2D 저장용
    private Rigidbody2D rb;

    // 땅 체크용 변수
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    // 슬라이드 관련 설정
    public Vector2 slideScale = new Vector2(1f, 0.5f); // 슬라이드 시 캐릭터 크기
    private bool isSliding = false;
    private Vector2 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        Run();
        HandleJump();
        HandleSlide();
    }

    // 자동으로 오른쪽 이동
    void Run()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    // 점프 처리
    void HandleJump()
    {
        // 땅에 닿으면 점프 횟수 초기화
        if (IsGrounded())
        {
            jumpCount = 0;
        }

        // Space를 누르고, 점프 횟수가 남았다면 점프
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // 기존 위속도 초기화
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;

            sfxSource.PlayOneShot(jumpSound);
        }

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
        sfxSource.PlayOneShot(slideSound);
    }

    // 슬라이드 종료      
    void EndSlide()
    {
        isSliding = false;
        transform.localScale = originalScale; // 원래 크기로 복원
    }

    // 땅 체크 (OverlapCircle 사용)
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
