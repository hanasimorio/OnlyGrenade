using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOperateController : MonoBehaviour
{
	[TextArea(1, 6)]
	public string[] Gameoperate;

	[SerializeField] Text uiText;
	[SerializeField, Tooltip("�G�I�u�W�F�N�g")] private GameObject enemy;
	[SerializeField] private GameObject plane;
	[SerializeField] private Transform spawnpos;

	[SerializeField]
	[Range(0.001f, 0.3f)]
	float intervalForCharacterDisplay = 0.05f;

	private string currentText = string.Empty;
	private float timeUntilDisplay = 0;
	private float timeElapsed = 1;
	private int currentLine = 0;
	private int lastUpdateCharacter = -1;

	// �����̕\�����������Ă��邩�ǂ���
	public bool IsCompleteDisplayText
	{
		get { return Time.time > timeElapsed + timeUntilDisplay; }
	}

	void Start()
	{
		SetNextLine();
	}

	void Update()
	{
		// �����̕\�����������Ă�Ȃ�N���b�N���Ɏ��̍s��\������
		if (IsCompleteDisplayText)
		{
			if (currentLine < Gameoperate.Length )
			{
				if (Input.GetKeyDown(KeyCode.Return))
				{
					SetNextLine();
				}
			}
            else
            {
				if (Input.GetKeyDown(KeyCode.Return))
                {
					plane.SetActive(false);
					Instantiate(enemy, spawnpos);
                }

			}
		}
		else
		{
			// �������ĂȂ��Ȃ當�������ׂĕ\������
			if (Input.GetKeyDown(KeyCode.Return))
			{
				timeUntilDisplay = 0;
			}
		}

		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
		if (displayCharacterCount != lastUpdateCharacter)
		{
			uiText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}

	}

	/// <summary>
	/// ���̕����Z�b�g����
	/// </summary>
	void SetNextLine()
	{
		currentText = Gameoperate[currentLine];
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		currentLine++;
		lastUpdateCharacter = -1;
	}
}
