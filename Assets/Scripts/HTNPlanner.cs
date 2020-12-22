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

    Plan m_Plan;

    /// <summary>
    /// ������
    /// </summary>
    public void Awake()
    {
        m_Plan = new Plan();
    }

    /// <summary>
    /// �v�����j���O����
    /// </summary>
    /// <param name="rootTask">�匳�̃^�X�N</param>
    public Plan DoPlan(ITask rootTask)
    {
        m_Plan.Clear();

        // WorldState�̃R�s�[������Ď��R�ɏ�����������悤�ɂ���
        var tmpState = m_WorldStateHolder.WorldState.CreateCopy();
        rootTask.TryPlanTask(tmpState, ref m_Plan);

        Log();

        return m_Plan;
    }

    [SerializeField] UnityEngine.UI.Text m_Text;
    /// <summary>
    /// �v�����j���O���o��
    /// </summary>
    private void Log()
    {
        string str = "�v�����F ";

        foreach (var @operator in m_Plan.Operators)
        {
            str += @operator.OperatorName + " �� ";
        }
        str += "END";

        m_Text.text = str;
    }
}
