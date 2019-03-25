using UnityEngine;

internal class UIManager : MonoBehaviour
{
	public static UIManager Instance { get; internal set; }

	[SerializeField]
	private EndGameMessage EndGameMessagePrefab;

	public void ShowEndGameMessage()
	{
		Time.timeScale = 0;
		Instantiate(EndGameMessagePrefab, transform, false);

	}

	public void Awake()
	{
		Instance = this;
	}
}