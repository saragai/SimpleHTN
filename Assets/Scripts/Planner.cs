using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTN;

/// <summary>
/// HTN�ɂ���čs���̃v�����j���O������
/// </summary>
public class Planner : MonoBehaviour
{
    [SerializeField]
    WorldStateHolder m_WorldStateHolder;
    [SerializeField] Task m_RootTask;

    Queue<IOperator> m_PlanList;

    /// <summary>
    /// ������
    /// </summary>
    public void Start()
    {
        m_PlanList = new Queue<IOperator>();

        Plan(m_RootTask);
    }

    /// <summary>
    /// �v�����j���O����
    /// </summary>
    /// <param name="rootTask">�匳�̃^�X�N</param>
    public void Plan(ITask rootTask)
    {
        var tmpState = m_WorldStateHolder.WorldState.CreateCopy();

        rootTask.TryPlanTask(tmpState, ref m_PlanList);

        foreach (var @operator in m_PlanList)
        {
            Debug.Log(@operator.OperatorName);
        }
        Debug.Log(tmpState);
    }
}
