using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject stepPrefab;
    [SerializeField] private Material goodMaterial;
    [SerializeField] private Material badMaterial;

    [SerializeField] private Vector2 difficultyMinMax;
    [SerializeField] private int stepNumber = 10;
    [SerializeField] private float stepHeight;
    [SerializeField] private float rotationAngle;
    [SerializeField] private float rotationSpeed = 10f;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    [ContextMenu("Generate Level")]
    public void createNewSteps() {
        string holderName = "Generated Steps";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform stepHolder = new GameObject(holderName).transform;
        stepHolder.parent = transform;
        //the above code block to make it easier to handle

        int badBlockCount = Utility.getDifficulty(difficultyMinMax);
        //print(badBlockCount);
        int remainingBadBlockNumber = badBlockCount;
        //generate steps
        for (int i = 0; i < stepNumber; i++)
        {
            GameObject newStep = Instantiate(stepPrefab, i * stepHeight * -Vector3.up, Quaternion.Euler(i * rotationAngle * Vector3.up));
            
            bool badBlock = Utility.randomBool();
            //print(i +" "+ badBlock);

            //it always return true if the remaining bad block number is equal to the remaining step number.
            if (remainingBadBlockNumber == stepNumber-i)
            {
                badBlock = true;
            }

            //just handle for the future which is doesn't generate more badblock than desired
            if (badBlock && remainingBadBlockNumber > 0)
            {
                remainingBadBlockNumber--;
            }

            //if enough badblocks have formed return false
            else if (badBlock && remainingBadBlockNumber == 0)
            {
                badBlock = false;
            }

            //print("remaining " + remainingBadBlockNumber);

            //bad block or good block is ready but which side is bad or good?
            //the code block below answers this
            int childCount = newStep.transform.childCount;
            int randomChild = Random.Range(0, childCount);
            for (int j = 0; j < childCount; j++)
            {
                GameObject childObject = newStep.transform.GetChild(j).gameObject;
                if (badBlock && j == randomChild)
                {
                    childObject.tag = "BadBlock";
                    childObject.GetComponent<Renderer>().material = badMaterial;
                    continue;
                }
                childObject.tag = "GoodBlock";
                childObject.GetComponent<Renderer>().material = goodMaterial;
            }

            //just easy to handle
            newStep.transform.parent = stepHolder;
        }
    }
}
