using System.Collections;
using System.Collections.Generic;
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
    public float offsetX;


    void Start()
    {
        offsetX = transform.position.x - target.position.x;
    }
    void LateUpdate()
    {
        // 목표 위치 = 플레이어 위치 + 오프셋
        Vector3 desiredPosition = transform.position;
        desiredPosition.x = target.position.x + offsetX;
        transform.position = desiredPosition;

        // 현재 위치에서 목표 위치로 부드럽게 이동 (Lerp: 선형 보간)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 카메라를 부드럽게 이동시키되 Y, Z 고정하고 X만 따라가게끔
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }
}

