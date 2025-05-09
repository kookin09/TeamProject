using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 플레이어 등 따라갈 대상의 Transform
    public Transform target;

    // 따라갈 때 부드럽게 움직이는 속도 조절 (0~1 사이, 작을수록 더 천천히 따라가)
    public float smoothSpeed = 0.125f;

    // 카메라 위치를 약간 옮기고 싶을 때 사용 (예: 캐릭터보다 앞쪽을 보여주고 싶을 때)
    public Vector3 offset;

    // 물리 연산 후 카메라 이동은 LateUpdate에서
    void LateUpdate()
    {
        // 따라갈 대상이 없으면 아무것도 안 함
        if (target == null) return;

        // 목표 위치 = 플레이어 위치 + 오프셋
        Vector3 desiredPosition = target.position + offset;

        // 현재 위치에서 목표 위치로 부드럽게 이동 (Lerp: 선형 보간)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 카메라를 부드럽게 이동시키되 Y, Z 고정하고 X만 따라가게끔
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }
}
