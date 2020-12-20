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
        /// サブタスク列挙
        /// </summary>
        public IEnumerable<ITask> SubTasks
        {
            get
            {
                foreach (var task in m_SubTasks)
                    yield return task;
            }
        }

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
    }
}
