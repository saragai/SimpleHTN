using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTN;

/// <summary>
/// HTN�ɂ���čs���̃v�����j���O������
/// </summary>
public class HTNPlanner : MonoBehaviour
{
    [SerializeField]
    WorldStateHolder m_WorldStateHolder;

    Plan m_PlanList;

    /// <summary>
    /// ������
    /// </summary>
    public void Awake()
    {
        m_PlanList = new Plan();
    }

    /// <summary>
    /// �v�����j���O����
    /// </summary>
    /// <param name="rootTask">�匳�̃^�X�N</param>
    public Plan Plan(ITask rootTask)
    {
        m_PlanList.Clear();
        var tmpState = m_WorldStateHolder.WorldState.CreateCopy();

        rootTask.TryPlanTask(tmpState, ref m_PlanList);

        Log();

        return m_PlanList;
    }

    [SerializeField] UnityEngine.UI.Text m_Text;
    /// <summary>
    /// �v�����j���O���o��
    /// </summary>
    private void Log()
    {
        string str = "�v�����F ";

        foreach (var @operator in m_PlanList.Operators)
        {
            str += @operator.OperatorName + " �� ";
        }
        str += "END";

        m_Text.text = str;
    }
}
