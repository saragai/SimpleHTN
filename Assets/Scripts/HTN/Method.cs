using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    /// <summary>
    /// タスクとそれを実行する条件
    /// </summary>
    [System.Serializable]
    public class Method
    {
        [SerializeField] List<Condition> m_Conditions;
        [SerializeField] List<Task> m_SubTasks;

        /// <summary>
        /// 状態を指定して実行条件を満たすか判断する
        /// </summary>
        /// <param name="state">状態</param>
        /// <returns>条件を満たすか</returns>
        public bool Match(WorldState state)
        {
            foreach (var condition in m_Conditions)
            {
                if (!condition.Match(state))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// サブタスクの実行をプランニング
        /// </summary>
        /// <param name="state"></param>
        /// <param name="plan"></param>
        /// <returns></returns>
        public bool TryPlanSubTasks(WorldState state, ref Plan plan)
        {
            foreach (var task in m_SubTasks)
            {
                if (!task.TryPlanTask(state, ref plan))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
