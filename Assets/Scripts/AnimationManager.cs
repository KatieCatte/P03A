using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] Sprite playerNeutral;
    [SerializeField] Sprite playerMoveForward;
    [SerializeField] Sprite playerMoveBack;
    [SerializeField] Sprite playerShoot1;
    [SerializeField] Sprite playerShoot2;
    [SerializeField] Sprite playerShoot3;
    public float shootInterval;

    public void SetPoseNeutral()
    {
        playerSprite.sprite = playerNeutral;
    }
    public void SetPoseBack()
    {
        playerSprite.sprite = playerMoveBack;
    }
    public void SetPoseForward()
    {
        playerSprite.sprite = playerMoveForward;
    }
    public void SetAnimationDirection(float xMove, float yMove)
    {
        if (xMove < 0 && yMove == 0)
        {
            SetPoseBack();
        }
        if(xMove>0 && yMove== 0) 
        {
            SetPoseForward();
        }
        if(xMove==0 && yMove != 0)
        {
            SetPoseForward();
        }
    }
    public IEnumerator ShootAnimation()
    {
        playerSprite.sprite = playerShoot1;
        yield return new WaitForSeconds(shootInterval);
        if (playerSprite.sprite == playerShoot1) { 
            playerSprite.sprite = playerShoot2;
            yield return new WaitForSeconds(shootInterval);
            if (playerSprite.sprite = playerShoot2)
            {
                playerSprite.sprite = playerShoot3;
            }
        }
        
    }

}
