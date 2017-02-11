using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Level;

    //public GameObject PlayerPrefab;
    public GameObject PlatformPrefab;
    public List<GameObject> Platforms;
    public GameObject EnemyPrefab;
    public List<GameObject> Enemies;
    public GameObject[] OtherPrefabs;
    public List<GameObject> Others;

    // Use this for initialization
    void Start()
    {
        switch (Level)
        {
            case 1:
                Platforms.Add(Instantiate(PlatformPrefab, new Vector3(0, -4.75f, 0), Quaternion.identity));
                Platforms.Add(Instantiate(PlatformPrefab, new Vector3(8.5f, -3.5f, 0), Quaternion.identity));
                Platforms.Add(Instantiate(PlatformPrefab, new Vector3(14.6f, -4.4f, 0), Quaternion.identity));
                Platforms.Add(Instantiate(PlatformPrefab, new Vector3(18.8f, -3.3f, 0), Quaternion.identity));
                Platforms[3].transform.localScale = new Vector3(0.875f, 1, 1);
                Enemies.Add(CreateFloorEnemy());
                Enemies.Add(Instantiate(EnemyPrefab, new Vector3(7f, -3f, 0), Quaternion.identity));
                Others.Add(Instantiate(OtherPrefabs[0], new Vector3(18.89f, -2.74f, 0), Quaternion.identity));

                foreach (GameObject igo in Platforms)
                    igo.transform.SetParent(this.transform);
                foreach (GameObject igo in Enemies)
                    igo.transform.SetParent(this.transform);
                foreach (GameObject igo in Others)
                    igo.transform.SetParent(this.transform);
                break;

            default:
                Debug.Log("Not Implemented");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private GameObject CreateFloorEnemy()
    {
        GameObject go = Instantiate(EnemyPrefab);
        go.transform.position = new Vector3(0, -6f, 0);
        go.transform.localScale = new Vector3(200, 1, 1);
        go.GetComponent<Rigidbody2D>().isKinematic = true;
        return go;
    }
}
