using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOperateController : MonoBehaviour
{
	[TextArea(1, 6)]
	public string[] Gameoperate;

	[SerializeField] Text uiText;
	[SerializeField, Tooltip("敵オブジェクト")] private GameObject enemy;
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

	// 文字の表示が完了しているかどうか
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
		// 文字の表示が完了してるならクリック時に次の行を表示する
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
			// 完了してないなら文字をすべて表示する
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
	/// 次の文をセットする
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
