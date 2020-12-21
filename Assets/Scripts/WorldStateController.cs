using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTN;

public class WorldStateController : MonoBehaviour
{
    [SerializeField] WorldStateHolder m_WorldStateHolder;
    [SerializeField] GameObject m_Character;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = m_Character.transform.position;
        var worldState = m_WorldStateHolder.WorldState;

        var workPos = PlaceManager.GetPosition(PlaceManager.PLACE.Work);
        var shopPos = PlaceManager.GetPosition(PlaceManager.PLACE.Shop);
        var eatPos = PlaceManager.GetPosition(PlaceManager.PLACE.Eat);

        if (Vector2.Distance(position, workPos) < 0.5f)
        {
            worldState.Set(WorldState.TYPE.HaveMoney, true);
        }

        if (Vector2.Distance(position, shopPos) < 0.5f)
        {
            if (worldState.Get(WorldState.TYPE.HaveMoney))
            {
                worldState.Set(WorldState.TYPE.HaveMoney, false);
                worldState.Set(WorldState.TYPE.HaveMeal, true);
            }
        }

        if (Vector2.Distance(position, eatPos) < 0.5f)
        {
            if (worldState.Get(WorldState.TYPE.HaveMeal))
            {
                worldState.Set(WorldState.TYPE.HaveMeal, false);
                worldState.Set(WorldState.TYPE.IsHungry, false);
            }
        }
    }
}
