using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("── 타겟 설정 ──")]
    [Tooltip("카메라가 따라갈 대상 (플레이어)")]
    public Transform target;

    [Header("── 부드러운 추적 설정 ──")]
    [Tooltip("0에 가까울수록 천천히, 1에 가까울수록 즉시 따라옴")]
    [Range(0.01f, 1f)]
    public float smoothSpeed = 0.125f;

    [Header("── 오프셋 설정 ──")]
    [Tooltip("타겟보다 X축으로 얼만큼 앞서 보여줄지")]
    public float offsetX = 2f;

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        if (target == null) return;

        // 1) 목표 X 위치 = 타겟 X + 오프셋
        float targetX = target.position.x + offsetX;

        // 2) 현재 카메라 위치에서 Y,Z는 그대로, X만 목표로 보간
        Vector3 desiredPosition = new Vector3(
            targetX,
            transform.position.y,
            transform.position.z
        );

        // 3) Lerp로 부드럽게 이동
        Vector3 smoothed = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed
        );

        transform.position = smoothed;
    }
}
