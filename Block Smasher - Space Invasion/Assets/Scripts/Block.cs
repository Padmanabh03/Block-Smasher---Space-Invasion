using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    [SerializeField] int timeHits;

    Level level;

    GameStatus gameStatus;

    private void Start()
    {
        CountableBlocks();

        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void CountableBlocks()
    {
        level = FindObjectOfType<Level>();
         
        if(tag=="Breakable")
        {
            level.CountBreakableBlocks();
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag=="Breakable")
        {
            timeHits++;
            int maxHits = hitSprites.Length + 1;
            if(timeHits >= maxHits)
            {
                BlockDestroyed();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timeHits - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite Is missing from Array"+gameObject.name);
        }
           
    }

    

    private void BlockDestroyed()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlocksDestroyed();
        gameStatus.AddToScore();
        TriggerSparkleVFX();
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkle = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 1f);
    }
}
