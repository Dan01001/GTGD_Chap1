using UnityEngine;
using System.Collections;
namespace Chapter1
{
    public class Spawner : MonoBehaviour
    {
        public int numberOfEnemies;
        private float spawnRadius = 5f;
        public GameObject objectToSpawn;
        private Vector3 spawnPosition;
        private GameManger_EventMaster eventMasterScript; 

        void OnEnable()
        {
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManger_EventMaster>();
            eventMasterScript.myGeneralEvent += SpawnObject;
        }

        void OnDisable()
        {
            eventMasterScript.myGeneralEvent -= SpawnObject;
        }

        void SpawnObject()
        {
            for(int i = 0; i < numberOfEnemies; i++)
            {
                spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }
}

