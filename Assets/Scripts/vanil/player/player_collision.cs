using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vanil.player;

public class player_collision : MonoBehaviour
{
    public bool _isHurt = false;
    [SerializeField] private GameObject manager;

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag)
        {
            case "point":
                GetComponent<fox>().point += 1;
                Debug.Log(GetComponent<fox>().point);
                Destroy(other.gameObject);
                manager.GetComponent<SoundHandle>().collect.Play();
                break;
            
            case "sub":
                GetComponent<fox>().subHP += 1;
                Debug.Log("sub");
                break;
            
            case "objective":
                manager.GetComponent<Win>().Completed();
                break;
            
            case "HP":
                if (GetComponent<fox>().HP < GetComponent<fox>().maxHP)
                    GetComponent<fox>().HP++;
                break;
            case "enemy":
                if (GetComponent<fox_anim>()._playerState == fox_anim.PlayerState.FALL)
                {
                    manager.GetComponent<SoundHandle>().destroy.Play();
                    Destroy(other.gameObject);
                    GetComponent<fox_controller>()._rb.velocity = Vector2.zero;
                    GetComponent<fox_controller>().Jump();
                    GetComponent<fox>().point += 3;
                }
                else
                {
                    manager.GetComponent<SoundHandle>().hurt.Play();
                    _isHurt = true;
                    GetComponent<fox>().takeDamage();
                    GetComponent<fox>().knockedBack(other.gameObject);
                }
                break;
            case "death":
                GetComponent<fox>().HP = 0;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
    }
}
