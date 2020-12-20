using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    [CreateAssetMenu(fileName ="compound_task.asset", menuName = "Compound Task", order = 1)]
    public class CompoundTask : Task
    {
        [SerializeField] List<Method> m_Methods;

        [System.NonSerialized]
        static int m_RecurrentCount = 0;

        /// <summary>
        /// ��Ԃ��w�肵�Ď��s����Operator
        /// </summary>
        /// <param name="state"></param>
        /// <param name="plan"></param>
        /// <returns></returns>
        public override bool TryPlanTask(WorldState state, ref Queue<IOperator> plan)
        {
            // �����ċA��h��
            m_RecurrentCount++;
            //Debug.Log($"{m_RecurrentCount}: {this.name}");
            if (m_RecurrentCount > 5)
            {
                return false;
            }

            foreach (var method in m_Methods)
            {
                // ���s����^�X�N��������
                if (method.Match(state))
                {
                    // ���݂�plan��ۑ�
                    var currentPlan = new Queue<IOperator>(plan);

                    // �T�u�^�X�N���s��
                    foreach (var task in method.SubTasks)
                    {
                        if (!task.TryPlanTask(state, ref plan))
                        {
                            // ���s�����Ƃ�plan�����ɖ߂�
                            plan = currentPlan;
                            return false;
                        }
                    }

                    // �T�u�^�X�N���S�Ċ��������̂Ő���
                    return true;
                }
            }

            // �����𖞂������\�b�h���Ȃ������̂Ŏ��s
            return false;
        }
    }
}
