using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour {

    [SerializeField]
    private GameObject m_Value;
    [SerializeField]
    private Text m_Open;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        m_Value.SetActive(!m_Value.activeSelf);
        m_Open.text = m_Value.activeSelf ? "▼" : "▲";
    }
}
