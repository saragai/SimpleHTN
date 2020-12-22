using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    public interface ITask
    {
        bool TryPlanTask(WorldState state, ref Plan plan);
    }

    public abstract class Task : ScriptableObject, ITask
    {
        public abstract bool TryPlanTask(WorldState state, ref Plan plan);
    }
}
