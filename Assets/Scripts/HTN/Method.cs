using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    /// <summary>
    /// �^�X�N�Ƃ�������s�������
    /// </summary>
    [System.Serializable]
    public class Method
    {
        [SerializeField] List<Condition> m_Conditions;
        [SerializeField] List<Task> m_SubTasks;

        /// <summary>
        /// �T�u�^�X�N��
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
        /// ��Ԃ��w�肵�Ď��s�����𖞂��������f����
        /// </summary>
        /// <param name="state">���</param>
        /// <returns>�����𖞂�����</returns>
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
