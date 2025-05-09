//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HitObject : MonoBehaviour
//{
//    public float HighPosX = 1f;
//    public float LowPosX = -1f;

//    public float holeSize = 1.5f;

//    public Transform TopObject;
//    public Transform BottomObject;

//    public float widthPadding = 3f;

//    public Vector3 SetRandomPlace(Vector3 lastPosition, int HitObjectCount)
//    {
//        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
//        float halfHoleSize = holeSize / 2;

//        TopObject.localPosition = new Vector3(halfHoleSize, 0);
//        BottomObject.localPosition = new Vector3(halfHoleSize,0);

//        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
//        placePosition.x = Random.Range(LowPosX, HighPosX);

//        transform.position = placePosition;

//        return placePosition;
//    }
//}


using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

}