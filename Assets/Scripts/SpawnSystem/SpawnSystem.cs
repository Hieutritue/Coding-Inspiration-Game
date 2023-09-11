using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] Transform QuestionBoxes;
    [SerializeField] GameObject boxPrefabs;
    [SerializeField] Transform spawnPlane;
    [SerializeField] float fallSpeed = 10f;
    [SerializeField] List<QuestionOS> list;

    int spawnBoxNumber = 4;
    // Start is called before the first frame update
    void Start()
    {
        SpawnQuestionBox();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnQuestionBox()
    {
        for (int i = 0; i < spawnBoxNumber && list.Count > 0; i++)
        {
            // set random question in box
            GameObject newBox = Instantiate(boxPrefabs,GetRandomPosition(),Quaternion.identity);
            if (newBox != null)
            {
                newBox.GetComponent<QuestionBox>().SetQuestionInBox(GetRandomQuestionOS());
                newBox.transform.SetParent(QuestionBoxes);
                // box fall
                Rigidbody rb = newBox.GetComponent<Rigidbody>();
                if (boxPrefabs != null)
                {
                    rb.velocity = Vector3.down * fallSpeed;
                }
            }
        }
        
    }

    public Vector3 GetRandomPosition()
    {
        float maxX = 19f; 
        float minX = -10f; 
        float maxZ = -29f; 
        float minZ = -37f; 
        float xSpawnRandom = Random.Range(minX, maxX);
        float zSpawnRandom = Random.Range(minZ, maxZ);

        return new Vector3(xSpawnRandom,spawnPlane.position.y,zSpawnRandom);
    }

    public QuestionOS GetRandomQuestionOS()
    {
        if (list.Count > 0)
        {
            int randomIndex  = Random.Range(0,list.Count);
            QuestionOS randomQuesOS = list[randomIndex];
            if (list.Contains(randomQuesOS))
            {
                list.Remove(randomQuesOS);
            }
            return randomQuesOS;
        }
        return null;
    }
}
