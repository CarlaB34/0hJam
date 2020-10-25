using UnityEngine;
using UnityEngine.Events;

///<summary>
/// 
///</summary>
[AddComponentMenu("_GAME/Finish Line")]
public class FinishLine: MonoBehaviour
{

    [Header("Events")]

    [SerializeField]
    private InteractiveObjectIDEvent m_OnPlayerCrossFinishLine = new InteractiveObjectIDEvent();

    private bool m_PlayerHasCrossedLine = false;

    private void OnTriggerEnter(Collider _Collider)
    {
        if (m_PlayerHasCrossedLine)
            return;

        if(_Collider.gameObject.TryGetComponent(out InteractiveObjectID _Obj))
        {
            m_OnPlayerCrossFinishLine.Invoke(_Obj);
            m_PlayerHasCrossedLine = true;
        }
    }

}