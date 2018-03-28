using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAmusementmachineController : MonoBehaviour {

    [SerializeField] private Transform          m_RankContents;
    [SerializeField] private SceneController    m_SceneController;
    [SerializeField] private InputField         m_NowGameCount;

    private int m_TempNowCount;

    private void Start()
    {
        UpdateRankCountContents();
    }

    public void SettingDiscrimination(int gameCount)
    {
        m_TempNowCount = string.IsNullOrEmpty(m_NowGameCount.text) ? 0: int.Parse(m_NowGameCount.text);

        foreach (Transform rankCount in m_RankContents)
        {
            var rank = rankCount.GetComponent<RankCountController>();

            if (rank == null) return;

            rank.ProbabilityCalculation();
        }
    }

    public void UpdateRankCountContents()
    {
        foreach(Transform rankCount in m_RankContents)
        {
            var rank = rankCount.GetComponent<RankCountController>();

            if (rank == null) return;

            rank.Initialize(
            () =>   // 子役カウント時コールバック
            {
                rank.TotalGameCount = m_SceneController.AllGameCount + m_TempNowCount;
            },
            () =>   // ボーナスカウント時コールバック
            {
                m_SceneController.OpenBonusPopup();
            }, true);
        }
    }

    public void EndEditGameCount()
    {
        var gameCount = int.Parse(m_NowGameCount.text);
        var editCount = gameCount > m_SceneController.StartGameCount ? gameCount:m_SceneController.StartGameCount;
        m_NowGameCount.text = editCount.ToString();
    }

    public void SetGameCount(int setGameCount)
    {
        m_NowGameCount.text = setGameCount.ToString();
    }
}