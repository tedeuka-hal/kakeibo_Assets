using System;
using UnityEngine;
using UnityEngine.UI;

public class ConstController : MonoBehaviour
{

	[SerializeField]
	private Text m_Date;

	// Use this for initialization
	void Start()
	{
		// 現在の日付を取得
		DateTime date = DateTime.Today;
		m_Date.text = date.ToString("yyyy/MM/dd");
	}
}
    