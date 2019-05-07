using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NilBoss : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyInScene;

    public GameObject music;

    public float spawnTime = 0f;
    public float maxSpawnTime;

    public float deSpawnTime = 0f;
    public float maxDeSpawnTime;

    public Tilemap tilemap;
    public List<Vector3> openTiles;

    public bool spawned;

    void Start(){
        maxSpawnTime = Random.Range(30f, 35f);
        maxDeSpawnTime = Random.Range(30f, 35f);

        //player = GameObject.FindGameObjectWithTag("Player");
        openTiles = new List<Vector3>();

        // search for free tiles
        for (int i = tilemap.cellBounds.xMin; i < tilemap.cellBounds.xMax; i++){
            for (int k = tilemap.cellBounds.yMin; k < tilemap.cellBounds.yMax; k++){
                Vector3Int tile = (new Vector3Int(i, k, (int)tilemap.transform.position.y));
                Vector3 place = tilemap.CellToWorld(tile);
                if (tilemap.HasTile(tile))
                    openTiles.Add(place);
            }
        }
    }

    void Update(){
        if (!spawned){
            spawnTime += Time.deltaTime;
            if (spawnTime >= maxSpawnTime){
                enemyInScene = Instantiate(enemy, openTiles[Random.Range(0, openTiles.Count)], Quaternion.identity);
                maxSpawnTime = Random.Range(30f, 35f);
                spawned = true;
                spawnTime = 0f;
                music.GetComponent<AudioSource>().Pause();
            }
        }else if (spawned){
            deSpawnTime += Time.deltaTime;
            if (deSpawnTime >= maxDeSpawnTime){
                Destroy(enemyInScene);
                maxDeSpawnTime = Random.Range(30f, 35f);
                spawned = false;
                deSpawnTime = 0f;
                music.GetComponent<AudioSource>().UnPause();
            }
        }
    }
}
