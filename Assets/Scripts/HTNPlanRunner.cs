using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTN;

/// <summary>
/// HTN
/// </summary>
public class HTNPlanRunner : MonoBehaviour
{
    [SerializeField] HTNPlanner m_Planner;
    [SerializeField] Operatable m_Operatable;

    [SerializeField] Task m_Task;

    [SerializeField] float m_ReplanningInterval = 1f;

    List<IEnumerator> m_RunningCoroutines;

    // Start is called before the first frame update
    void Start()
    {
        m_RunningCoroutines = new List<IEnumerator>();
        StartCoroutine(SetTaskRoutine(m_Task));
    }

    IEnumerator SetTaskRoutine(ITask task)
    {
        while (true)
        {
            // 一定時間ごとにリプランニング
            SetTask(task);
            yield return new WaitForSeconds(m_ReplanningInterval);
        }
    }

    public void SetTask(ITask task)
    {
        StopCoroutine();

        var plan = m_Planner.DoPlan(task);
        StartPlan(plan);
    }

    /// <summary>
    /// プランの実行を開始
    /// </summary>
    /// <param name="plan"></param>
    void StartPlan(Plan plan)
    {
        var coroutine = Execute(plan.Operators);
        m_RunningCoroutines.Add(coroutine);

        StartCoroutine(coroutine);
    }

    /// <summary>
    /// 進行中のコルーチンを止める
    /// </summary>
    void StopCoroutine()
    {
        foreach (var coroutine in m_RunningCoroutines)
        {
            StopCoroutine(coroutine);
        }
        m_RunningCoroutines.Clear();
    }

    IEnumerator Execute(IEnumerable<IOperator> operators)
    {
        foreach (var @operator in operators)
        {
            var action = Execute(@operator);
            m_RunningCoroutines.Add(action);
            yield return StartCoroutine(action);
        }
    }

    IEnumerator Execute(IOperator @operator)
    {
        var action = @operator.Execute(m_Operatable);
        m_RunningCoroutines.Add(action);
        yield return StartCoroutine(action);
    }
}
