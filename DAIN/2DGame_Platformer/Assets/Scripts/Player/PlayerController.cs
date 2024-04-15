using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private StageData stageData;

	[SerializeField] // �Է��ϴ� Ű ���� ������ �����صθ� Ű ������ �� �����ϴ�
	private	KeyCode				jumpKeyCode = KeyCode.C;

	private	MovementRigidbody2D	movement;
	private PlayerAnimator playerAnimator;

	private void Awake()
	{
		movement		= GetComponent<MovementRigidbody2D>();
		playerAnimator = GetComponentInChildren<PlayerAnimator>();
	}

	private void Update()
	{
		// Ű �Է� (��/�� ���� Ű, x Ű)
		float x		 = Input.GetAxisRaw("Horizontal");
		float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f; // xŰ ������ ������ 1, x Ű �� ������ ������ 0.5
		
		// �ȱ��� �� ���� ������ -0.5 ~ 0.5
		// �ٱ��� �� ���� ������ -1 ~ 1�� ����
		x *= offset;

		// �÷��̾��� �̵� ���� (��/��)
		UpdateMove(x);
		// �÷��̾��� ���� ����
		UpdateJump();
		// �÷��̾� �ִϸ��̼� ���
		playerAnimator.UpdateAnimation(x);
	}

	private void UpdateMove(float x)
	{
		// �÷��̾��� ������ �̵� (��/��)
		movement.MoveTo(x); // x ���� ���� �÷��̾ ���, �ȱ�, �ٱ⸦ �Ѵ�

		// �÷��̾��� x�� �̵� �Ѱ�ġ ���� (PlayerLimitMinX ~ PlayerLimitMaxX)
		float xPosition = Mathf.Clamp(transform.position.x, stageData.PlayerLimitMinX, stageData.PlayerLimitMaxX);
		transform.position = new Vector2(xPosition, transform.position.y);
	}

	private void UpdateJump()
	{
		if ( Input.GetKeyDown(jumpKeyCode) ) // ���� Ű ����
		{
			movement.Jump();
		}

		if ( Input.GetKey(jumpKeyCode) ) // ���� Ű ������ ����
		{
			movement.IsLongJump = true;
		}
		else if ( Input.GetKeyUp(jumpKeyCode) ) // ���� Ű ��
		{
			movement.IsLongJump = false;
		}
	}
}
