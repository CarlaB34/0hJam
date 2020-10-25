using UnityEngine;
using UnityEngine.Events;

///<summary>
/// 
///</summary>
[AddComponentMenu("_GAME/Checkpoint")]
public class Checkpoint : MonoBehaviour
{

    [Header("Events")]

    [SerializeField]
    private InteractiveObjectIDEvent m_OnPlayerCrossCheckpoint = new InteractiveObjectIDEvent();

    private bool m_HasBeenUsed = false;

    private void OnTriggerEnter(Collider _Collider)
    {
        if (m_HasBeenUsed)
            return;

        if(_Collider.gameObject.TryGetComponent(out InteractiveObjectID _Obj))
        {
            m_OnPlayerCrossCheckpoint.Invoke(_Obj);
            m_HasBeenUsed = true;
            Destroy(gameObject);
        }
    }

}