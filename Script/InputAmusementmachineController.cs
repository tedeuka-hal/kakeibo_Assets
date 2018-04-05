using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAmusementmachineController : MonoBehaviour {

    [SerializeField] private Transform          m_RankContents;
    [SerializeField] private SceneController    m_SceneController;
    [SerializeField] private Dropdown           m_MachineDropDown;
    [SerializeField] private InputField         m_NowGameCount;
    [SerializeField] private DataBaseController m_DatabaseController;
    [SerializeField] private GameObject         m_RankPrefab;

    private int m_TempNowCount;

    private void Start()
    {
        UpdateRankCountContents();
        CreateMachineContents();
        CreateRankContents(0);
    }

    public void SettingDiscrimination()
    {
        var gameCount = int.Parse(m_NowGameCount.text);
        m_TempNowCount = gameCount - m_SceneController.StartGameCount;

        foreach (Transform rankCount in m_RankContents)
        {
            var rank = rankCount.GetComponent<RankCountController>();

            if (rank == null) return;

            rank.ProbabilityCalculation();
        }
    }

    public void CreateRankContents(int id)
    {
        foreach(var rank in m_DatabaseController.SelectMachineRank(id))
        {
            var content = Instantiate(m_RankPrefab,m_RankContents).GetComponent<RankCountController>();
            content.gameObject.SetActive(true);
        }
    }

    public void CreateMachineContents()
    {
        Dropdown.OptionData machineData;

        Dropdown.OptionData registOption = new Dropdown.OptionData { text = "機種を選択" };    // 新規登録を追加
        m_MachineDropDown.options.Add(registOption);
        foreach (var machine in m_DatabaseController.SelectMachineMaster())
        {
            machineData = new DropDownOptionDataExtends<AmusumentMachineMasterData>() {Data = machine,text = machine.machineName};
            m_MachineDropDown.options.Add(machineData);
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