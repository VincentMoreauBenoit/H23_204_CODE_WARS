using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    [SerializeField] GameObject layerTwo;
    Vector2 layerTwoMin;
    Vector2 layerTwoMax;
    float layerTwoPosition;

    [SerializeField] GameObject layerThree;
    Vector2 layerThreeMin;
    Vector2 layerThreeMax;
    float layerThreePosition;

    float playerMin = -8f;
    float playerMax = 8f;
    public float playersWay = 0;

    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        layerTwoMin = new Vector2(-0.05f, 1.22f);
        layerTwoMax = new Vector2(0.12f, 1.22f);

        layerThreeMin = new Vector2(-0.23f, 1.22f);
        layerThreeMax = new Vector2(-0.04f, 1.22f);
    }

    // Update is called once per frame
    void Update()
    {
        playersWay = (player.transform.position.x + 8f) / 0.15f;
        
        layerTwoPosition = playersWay * 0.0017f - 0.05f;
        layerTwo.transform.position = new Vector2(layerTwoPosition, 1.22f);


        layerTwoPosition = playersWay * 0.0017f - 0.05f;
        layerTwo.transform.position = new Vector2(layerTwoPosition, 1.22f);

        layerThreePosition = -playersWay * 0.0027f - 0.23f;
        layerThree.transform.position = new Vector2(layerThreePosition, 1.22f);

    }
}
