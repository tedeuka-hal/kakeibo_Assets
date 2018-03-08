using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField] private PopupController m_PopupController;

	// Use this for initialization
	void Start () {
        m_PopupController.StartPopupActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
