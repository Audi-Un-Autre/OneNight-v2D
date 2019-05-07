using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NilBoss : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyInScene;

    public GameObject music;
    public AudioSource nilMusic;
    public double nilMusicVolume;

    public float spawnTime = 0f;
    public float maxSpawnTime;

    public float deSpawnTime = 0f;
    public float maxDeSpawnTime;

    public Tilemap tilemap;
    public List<Vector3> openTiles;

    public double defVolume;

    public bool spawned;

    void Start(){

        defVolume = music.GetComponent<AudioSource>().volume;
        nilMusicVolume = .5F;

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

            if (music.GetComponent<AudioSource>().volume < defVolume){
                music.GetComponent<AudioSource>().UnPause();
                music.GetComponent<AudioSource>().volume += .05F * Time.deltaTime;
            }
            if (nilMusic.volume >= .1F)
                nilMusic.volume -= .05F * Time.deltaTime;
            else
                nilMusic.Pause();

            spawnTime += Time.deltaTime;
            if (spawnTime >= maxSpawnTime){
                enemyInScene = Instantiate(enemy, openTiles[Random.Range(0, openTiles.Count)], Quaternion.identity);
                maxSpawnTime = Random.Range(30f, 35f);
                spawned = true;
                spawnTime = 0f; 
            }
        }else if (spawned){

            nilMusic.enabled = true;

            if (music.GetComponent<AudioSource>().volume > .1F)
                music.GetComponent<AudioSource>().volume -= .05F * Time.deltaTime;
            else
                music.GetComponent<AudioSource>().Pause();

            if (nilMusic.volume < nilMusicVolume){
                nilMusic.UnPause();
                nilMusic.volume += .05F * Time.deltaTime;
            }

            deSpawnTime += Time.deltaTime;
            if (deSpawnTime >= maxDeSpawnTime){
                Destroy(enemyInScene);
                maxDeSpawnTime = Random.Range(30f, 35f);
                spawned = false;
                deSpawnTime = 0f;
            }
        }
    }
}
