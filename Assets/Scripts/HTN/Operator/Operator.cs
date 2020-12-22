using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    // 操作対象
    public interface IOperatable
    {
        Transform Transform { get; }
    }

    // 操作者
    public interface IOperator
    {
        string OperatorName { get; }
        IEnumerator Execute(IOperatable operatable);
    }

    namespace Operator
    {
        /// <summary>
        /// タスクが行う操作の設定クラス
        /// </summary>
        public abstract class Operator : ScriptableObject, IOperator
        {
            [SerializeField] string m_OperatorName;
            public string OperatorName => m_OperatorName;

            /// <summary>
            /// 操作を実行
            /// </summary>
            /// <param name="operatable">操作されるもの</param>
            /// <returns></returns>
            public abstract IEnumerator Execute(IOperatable operatable);
        }
    }
}
