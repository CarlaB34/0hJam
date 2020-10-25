using UnityEngine;

namespace Game
{

    ///<summary>
    /// 
    ///</summary>
    [AddComponentMenu("_GAME/Terrain Generator")]
    public class TerrainGenerator : MonoBehaviour
    {

        [Header("References")]

        [SerializeField]
        private Transform m_TerrainParent = null;

        [SerializeField]
        private GameObject m_CheckpointPrefab = null;

        [SerializeField]
        private GameObject m_FinishLinePrefab = null;

        [Header("Settings")]

        [SerializeField]
        [Tooltip("The space (in units) from the start line to the first checkpoint")]
        private float m_StartSpace = 30f;

        [SerializeField]
        private float m_MinCheckpointInterval = 20f;

        [SerializeField]
        private float m_MaxCheckpointInterval = 50f;

        [SerializeField]
        private float m_CheckpointXRange = 6f;

        [SerializeField, Min(1)]
        private int m_NbCheckpoints = 10;

        private void Awake()
        {
            if(!m_TerrainParent) { m_TerrainParent = transform; }
        }

        private void Start()
        {
            GenerateTerrain();
        }

        /// <summary>
        /// Deletes the existing terrain and generate a new one.
        /// </summary>
        public void GenerateTerrain()
        {
            DeleteTerrain();

            Vector3 nextPosition = m_TerrainParent.position + Vector3.up * m_StartSpace;
            nextPosition = GetNextCheckpointPosition(nextPosition.y);
            for (int i = 0; i < m_NbCheckpoints; i++)
            {
                Instantiate(m_CheckpointPrefab, nextPosition, Quaternion.identity, m_TerrainParent);
                nextPosition = GetNextCheckpointPosition(nextPosition.y);
            }

            nextPosition.x = m_TerrainParent.position.x;
            GameObject finishLineObj = Instantiate(m_FinishLinePrefab, nextPosition, Quaternion.identity, m_TerrainParent);
            Vector3 scale = finishLineObj.transform.localScale;
            scale.x = m_CheckpointXRange;
            finishLineObj.transform.localScale = scale;
        }

        private Vector3 GetNextCheckpointPosition(float _CurrentY)
        {
            Vector3 nextPosition = m_TerrainParent.position;
            nextPosition.x = Random.Range(nextPosition.x - m_CheckpointXRange / 2, nextPosition.x + m_CheckpointXRange / 2);
            nextPosition.y = _CurrentY + Random.Range(m_MinCheckpointInterval, m_MaxCheckpointInterval);
            return nextPosition;
        }

        private void DeleteTerrain()
        {
            foreach (Transform child in m_TerrainParent)
            {
                Destroy(child.gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            float terrainHeight = (m_NbCheckpoints + 1) * m_MaxCheckpointInterval + m_StartSpace;
            Gizmos.DrawWireCube(m_TerrainParent.position + Vector3.up * terrainHeight / 2, new Vector3(m_CheckpointXRange, terrainHeight, 0f));
        }

    }

}