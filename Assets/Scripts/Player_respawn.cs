using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_respawn : MonoBehaviour
{
    public Animator anim;
    private float checkPointPositionX, checkPointPositionY;
    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"),PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }
    public void pasarcheckpoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }
    public void PlayerDamaged()
    {
        anim.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
