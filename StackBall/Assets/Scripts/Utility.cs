using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static int getDifficulty(Vector2 difficultyMinMax) {
        return (int)Random.Range(difficultyMinMax.x, difficultyMinMax.y+1);
    }

    public static bool randomBool() {
        return Random.value > 0.5f;
    }
}
