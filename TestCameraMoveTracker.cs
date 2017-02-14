using UnityEngine;

public class TestCameraMoveTracker : MonoBehaviour {

    SectorManager sectorManager;
    Vector3 lastUpdate;
    float offset = 2;

    void Start() {
        sectorManager = new SectorManager();
        lastUpdate = transform.position;
        sectorManager.updateSectors(lastUpdate);
    }

    void Update() {

        if (Vector3.Distance(transform.position, lastUpdate) > offset) {
            lastUpdate = transform.position;
            sectorManager.updateSectors(lastUpdate);
        }
    }
    
}
