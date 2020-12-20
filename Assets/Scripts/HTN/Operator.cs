using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    // 操作者
    public interface IOperator
    {
        string OperatorName { get; }
        IEnumerator Execute(IOperatable operatable);
    }

    // 操作対象
    public interface IOperatable
    {
        Transform Transform { get; }
    }

    /// <summary>
    /// タスクが行う操作の設定クラス
    /// </summary>
    [CreateAssetMenu(fileName ="operator.asset", menuName = "Operator", order = 1)]
    public class Operator: ScriptableObject, IOperator
    {
        [SerializeField] string m_OperatorName;
        public string OperatorName => m_OperatorName;

        /// <summary>
        /// 操作を実行
        /// </summary>
        /// <param name="operatable">操作されるもの</param>
        /// <returns></returns>
        public virtual IEnumerator Execute(IOperatable operatable)
        {
            Debug.Log(m_OperatorName);
            yield return null;
        }
    }
}
