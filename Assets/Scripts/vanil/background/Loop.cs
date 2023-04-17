using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private Texture texture;
    private float inGameWidth;

    [SerializeField] private int _pixelPerUnits=16;

    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        texture = this.GetComponent<SpriteRenderer>().sprite.texture;
        inGameWidth = texture.width / _pixelPerUnits;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(player.transform.position.x - this.transform.position.x) >= inGameWidth)
        {
            Vector2 pos = this.transform.position;
            pos.x = player.transform.position.x;

            this.transform.position = pos;
        }
    }
}
