using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlatformInstanciate : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platforms;
    [SerializeField]
    private List<GameObject> safePlatforms;

    [SerializeField]
    private float distanceBetweenPlatforms = 2f;

    private int initialPlatforms = 10;

    private float offsetPositionX = 0f;

    private int platformsIndex = 0;

    public void Start()
    {
        platformsIndex = 0;
        offsetPositionX = 0;
        InstantiatePlatforms(initialPlatforms); 
    }

    public void InstantiatePlatforms(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            List<GameObject> platformsToUse = platformsIndex < 2 ? safePlatforms : this.platforms;
            int randomIndex = Random.Range(0, platformsToUse.Count);
            if(offsetPositionX != 0)
            {
                offsetPositionX += platformsToUse[randomIndex].GetComponent<BoxCollider>().size.x * 0.5f;
            }
            GameObject platform = Instantiate(platformsToUse[randomIndex], Vector3.zero, Quaternion.identity);
            offsetPositionX += distanceBetweenPlatforms + platform.GetComponent<BoxCollider>().size.x * 0.5f;
            platform.transform.SetParent(transform);
            platform.transform.localPosition = new Vector3(offsetPositionX, 0,0);
            platformsIndex++;
        }
    }

    public void Restart()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Start();
    }
}
