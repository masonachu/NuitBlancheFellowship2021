using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOnDemand : Spawner
{
    public override void Awake() {
        
    }

    private void OnTriggerEnter(Collider other) {

        if(other.CompareTag("Player")) {
            
            for (int i = 0; i < spawnCount; i++) {

            Vector3 pos = transform.position + Random.insideUnitSphere * spawnRadius;
            Boid boid = Instantiate(prefab);
            boid.transform.position = pos;
            boid.transform.forward = Random.insideUnitSphere;
            boid.SetColour(colour);

            spawnedBoids = true;
            }
        }
    }
}
