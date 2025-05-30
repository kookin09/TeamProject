using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
 // 배경음과 효과음
    public AudioClip jumpSound;
    public AudioClip slideSound;
    public AudioClip DamageSound;
    public AudioSource sfxSource;
    private Animator animator;

    // 이동 속도와 점프 세기
    public float moveSpeed = 5f;
    public float jumpForce = 15f;

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

    private Vector2 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Debug.Log(animator);
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

    // 점프
    void HandleJump()
    {

        // 땅에 닿으면 점프 횟수 초기화
        if (IsGrounded())
        {
            animator.SetBool("IsJump", false);
            jumpCount = 0;
            Debug.Log("Touch Ground");
        }

        // Space를 누르고, 점프 횟수가 남았다면 점프
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // 기존 위속도 초기화
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("IsJump", true);
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
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        return isGrounded;
    }

    //피격
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

    //죽음
    public virtual void Death()
    {

    rb.velocity = Vector3.zero;

    // foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
    // {
    //     Color color = renderer.color;
    //     color.a = 0.3f;
    //     renderer.color = color;
    // }

    foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
    {
        component.enabled = false;
    }

    Destroy(gameObject, 2f);
    }
}




//3단점프 버그 수정중
// using UnityEngine;

// /// <summary>
// ///  ▣ 자동 달리기 캐릭터 컨트롤러
// ///   - 달리기 / 2단 점프 / 슬라이드 / 벽 끼임 탈출
// /// </summary>
// [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(Animator))]
// public class Player : MonoBehaviour
// {

//  // 배경음과 효과음
//     public AudioClip jumpSound;
//     public AudioClip slideSound;
//     public AudioSource sfxSource;
//     private Animator animator;

//     // 이동 속도와 점프 세기
//     public float moveSpeed = 5f;
//     public float jumpForce = 15f;

//     // 최대 점프 횟수 (2단 점프)
//     public int maxJump = 2;
//     private int jumpCount = 0;

//     // Rigidbody2D 저장용
//     private Rigidbody2D rb;

//     // 땅 체크용 변수
//     public Transform groundCheck;
//     public float groundCheckRadius = 0.2f;
//     public LayerMask groundLayer;

//     // 슬라이드 관련 설정
//     public Vector2 slideScale = new Vector2(1f, 0.5f); // 슬라이드 시 캐릭터 크기
//     private bool isSliding = false;

//     private Vector2 originalScale;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         animator = GetComponent<Animator>();
//         Debug.Log(animator);
//         originalScale = transform.localScale;
//     }
// // =======
// //     [Header("── 이동 / 점프 ──")]
// //     [SerializeField] float moveSpeed = 5f;
// //     [SerializeField] float jumpForce = 11f;
// //     [SerializeField, Range(1, 2)] int maxJump = 2;

// //     [Header("── 땅 판정 ──")]
// //     [SerializeField] Transform groundCheck;
// //     [SerializeField] float groundRadius = 0.2f;
// //     [SerializeField] LayerMask groundMask;

// //     [Header("── 슬라이드 ──")]
// //     [SerializeField] AudioSource slideSource;
// //     [SerializeField] AudioClip slideClip;

// //     [Header("── 벽 끼임 해소 ──")]
// //     [SerializeField] float stuckSpeedThreshold = 0.05f;
// //     [SerializeField] float stuckCheckDuration = 0.25f;
// //     [SerializeField] LayerMask wallMask;

// //     Rigidbody2D rb;
// //     Animator anim;
// //     BoxCollider2D boxCol;

// //     Vector3 origScale;
// //     Vector2 origSize, origOffset;

// //     int jumpCount = 0;
// //     bool isSliding = false;
// //     bool wasGrounded = false;
// //     float stuckTimer = 0f;

// //     void Awake()
// //     {
// //         rb = GetComponent<Rigidbody2D>();
// //         anim = GetComponent<Animator>();
// //         boxCol = GetComponent<BoxCollider2D>();

// //         origScale = transform.localScale;
// //         origSize = boxCol.size;
// //         origOffset = boxCol.offset;

// //         slideSource.loop = true;
// //         slideSource.clip = slideClip;
// // >>>>>>> develop

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump)
//         {
//             if (isSliding) EndSlide();
//             rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//             jumpCount++;
//             anim.SetBool("IsJump", true);
//             SoundManager.Instance?.PlaySFX(SFXType.Jump);
//         }

//         if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding)
//             StartSlide();
//         else if (Input.GetKeyUp(KeyCode.LeftShift) && isSliding)
//             EndSlide();
//     }


// //     // 점프
// //     void HandleJump()
// //     {
// // // =======
// // //     void FixedUpdate()
// // //     {
// // //         bool grounded = IsGrounded();
// // // >>>>>>> develop
// //         if (!wasGrounded && grounded)
// //         {
// //             jumpCount = 0;
// //             anim.SetBool("IsJump", false);
// //         }
// //         wasGrounded = grounded;

// //         // 지면 슬로프 대응
// //         if (!grounded)
// //         {
// //             rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
// //         }
// //         else
// //         {
// //             RaycastHit2D hit = Physics2D.Raycast(
// //                 groundCheck.position, Vector2.down, groundRadius + 0.1f, groundMask);
// //             if (hit && Mathf.Abs(hit.normal.x) > 0.1f)
// //             {
// //                 Vector2 slopeDir = new Vector2(hit.normal.y, -hit.normal.x).normalized;
// //                 rb.velocity = slopeDir * moveSpeed;
// //             }
// //             else
// //             {
// //                 rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
// //             }
// //         }

// //         // 벽 끼임 검사
// //         if (IsWallAhead() && Mathf.Abs(rb.velocity.x) < stuckSpeedThreshold)
// //         {
// //             stuckTimer += Time.fixedDeltaTime;
// //             if (stuckTimer > stuckCheckDuration)
// //             {
// //                 rb.velocity += Vector2.down * 0.5f;
// //                 stuckTimer = 0f;
// //             }
// //         }
// //         else
// //         {
// //             stuckTimer = 0f;
// //         }
//     // }

//     void StartSlide()
//     {
//         isSliding = true;
//         transform.localScale = new Vector3(origScale.x, origScale.y * 0.5f, 1f);
//         boxCol.size = new Vector2(origSize.x, origSize.y * 0.5f);
//         boxCol.offset = new Vector2(origOffset.x, origOffset.y - 0.25f);
//         slideSource.Play();
//         SoundManager.Instance?.PlaySFX(SFXType.Slide);
//     }

//     void EndSlide()
//     {
//         isSliding = false;
//         transform.localScale = origScale;
//         boxCol.size = origSize;
//         boxCol.offset = origOffset;
//         slideSource.Stop();
//     }

//     bool IsGrounded()
//     {   
//         bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
//         return isGrounded;
//     }

//     //피격
//     public void Damage()
//     {
//         animator.SetBool("IsDamage", true);
//         StartCoroutine(ResetDamageState());
//     }
//     IEnumerator ResetDamageState()
//     {
//         yield return new WaitForSeconds(1f); // 1초 대기
//         animator.SetBool("IsDamage", false);
//     }

//     //죽음
//     public virtual void Death()
//     {

//     rb.velocity = Vector3.zero;

//     // foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
//     // {
//     //     Color color = renderer.color;
//     //     color.a = 0.3f;
//     //     renderer.color = color;
//     // }

//     foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
//     {
//         component.enabled = false;
//     }

//     Destroy(gameObject, 2f);
//     }
// // =======
// //     {
// //         return Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
// //     }

// //     bool IsWallAhead()
// //     {
// //         Vector2 origin = (Vector2)transform.position + Vector2.right * (boxCol.size.x / 2 + 0.01f);
// //         origin.y += boxCol.offset.y;
// //         return Physics2D.BoxCast(origin, boxCol.size, 0f, Vector2.right, 0.01f, wallMask);
// //     }

// //     void LateUpdate()
// //     {
// //         transform.rotation = Quaternion.identity;
// //     }

// // #if UNITY_EDITOR
// //     void OnDrawGizmosSelected()
// //     {
// //         if (groundCheck)
// //         {
// //             Gizmos.color = Color.green;
// //             Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
// //         }
// //     }
// // #endif
// // >>>>>>> develop
// }
