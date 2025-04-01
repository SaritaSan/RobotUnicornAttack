using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlatformInstanciate : MonoBehaviour
{
    [SerializeField]
    private List<InstaciateObject> platformPools;
    [SerializeField]
    private List<InstaciateObject> safePlatformPools;

    [SerializeField]
    private float distanceBetweenPlatforms = 2f;

    [SerializeField]
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
            List<InstaciateObject> platformsToUse = platformsIndex < 2 ? safePlatformPools : platformPools;
            int randomIndex = Random.Range(0, platformsToUse.Count);
            if(offsetPositionX != 0)
            {
                offsetPositionX += platformsToUse[randomIndex].ObjectToInstantiate.GetComponent<BoxCollider>().size.x * 0.5f;
            }
            GameObject platform = platformsToUse[randomIndex].CreateInstance();
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
            child.gameObject.SetActive(false);
        }
        Start();
    }
}
