using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform playerStartTransform;
    [SerializeField] LevelCreator creator;
    [SerializeField] Player player;

    private void Awake()
    {
        Instantiate(creator, transform.position, Quaternion.identity).createNewSteps();
        Instantiate(player, playerStartTransform.position, playerStartTransform.rotation);
    }
}
