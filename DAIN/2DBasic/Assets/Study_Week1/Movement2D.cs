using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f; // �̵� �ӵ�
    private Vector3 moveDirection = Vector3.zero; // �̵� ����
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        // Ŭ���� ���� ��𿡼��� rigid2D ������ �̿��� Rigidody2D ������Ʈ ������ �ٲٰų� ���� �� ����
    }

    private void Update()
    {
        // Negative left, a : -1
        // Positive right, d : 1
        // Non : 0
        float x = Input.GetAxisRaw("Horizontal"); // �¿� �̵�
        // Negative down, s : -1
        // Positive up, w : 1
        // Non : 0
        float y = Input.GetAxisRaw("Vertical"); // ���Ʒ� �̵�

        // �̵� ���� ����
        moveDirection = new Vector3(x, y, 0);

        // ���ο� ��ġ = ���� ��ġ + (���� x �ӵ�)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // �̵��Ÿ� = ���� * �ӵ� * Time.deltaTime
        // Time.deltaTime : ��ǻ�� ��� ���̰� ���� �����ִ� �� ����


        // ���������� ��� �̵� (�Ʒ� 2�� ���� �ڵ���)
        //transform.position = transform.position + new Vector3(1, 0, 0) * 1;
        //transform.position += Vector3.right * 1 * Time.deltaTime;

        // Rigidbody2D ������Ʈ�� �ִ� �ӷ� ���� ����
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;   


    }
}