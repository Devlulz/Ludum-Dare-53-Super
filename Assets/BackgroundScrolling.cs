using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    [SerializeField]
    GameObject[] bgLayers;

    [SerializeField]
    GameObject groundObject;
    [SerializeField]
    float groundMultiplier;


    [SerializeField]
    Vector2[] layerMultipliers;

    public float trainSpeed;

    private float textureUnitSizeX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        /*for (int i = 0; i < bgLayers.Length; i++)
        {
            Instantiate(bgLayers[i], bgLayers[i].transform.position + new Vector3(32,0,0) , bgLayers[i].transform.rotation, bgLayers[i].transform);
            Instantiate(bgLayers[i], bgLayers[i].transform.position + new Vector3(-32,0,0) , bgLayers[i].transform.rotation, bgLayers[i].transform);
        }*/
        Sprite sprite = bgLayers[0].GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void Update()
    {

    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        for (int i = 0; i < bgLayers.Length; i++)
        {
            bgLayers[i].transform.position += new Vector3((deltaMovement.x + (trainSpeed * Time.deltaTime))* layerMultipliers[i].x, deltaMovement.y * layerMultipliers[i].y);
            if(Mathf.Abs(cameraTransform.position.x - bgLayers[i].transform.position.x) >= textureUnitSizeX)
            {
                //float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                bgLayers[i].transform.position = new Vector3(cameraTransform.position.x, bgLayers[i].transform.position.y);
            }
        }
        MoveGround(deltaMovement);
        //transform.position += deltaMovement * layerMultipliers[0];
        lastCameraPosition = cameraTransform.position;
    }

    void MoveGround(Vector3 deltaMovement)
    {
        groundObject.transform.position += new Vector3((deltaMovement.x + ((trainSpeed * groundMultiplier) * Time.deltaTime)), 0);
        if (Mathf.Abs(cameraTransform.position.x - groundObject.transform.position.x) >= textureUnitSizeX)
        {
            //float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            groundObject.transform.position = new Vector3(cameraTransform.position.x, groundObject.transform.position.y);
        }
    }
}
