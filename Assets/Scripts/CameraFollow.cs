using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // �÷��̾� �� ���� ����� Transform
    public Transform target;

    // ���� �� �ε巴�� �����̴� �ӵ� ���� (0~1 ����, �������� �� õõ�� ����)
    public float smoothSpeed = 0.125f;

    // ī�޶� ��ġ�� �ణ �ű�� ���� �� ��� (��: ĳ���ͺ��� ������ �����ְ� ���� ��)
    public Vector3 offset;

    // ���� ���� �� ī�޶� �̵��� LateUpdate����
    void LateUpdate()
    {
        // ���� ����� ������ �ƹ��͵� �� ��
        if (target == null) return;

        // ��ǥ ��ġ = �÷��̾� ��ġ + ������
        Vector3 desiredPosition = target.position + offset;

        // ���� ��ġ���� ��ǥ ��ġ�� �ε巴�� �̵� (Lerp: ���� ����)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ī�޶� �ε巴�� �̵���Ű�� Y, Z �����ϰ� X�� ���󰡰Բ�
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }
}
