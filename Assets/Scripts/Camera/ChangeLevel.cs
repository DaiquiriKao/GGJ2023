using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public LevelScroll Scroll;
    public int LowerLevel = 0;
    public int UpperLevel = 1;

    public void LevelUp()
    {
        Scroll.MoveUp();
    }
    public void LevelDown()
    {
        Scroll.MoveDown();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Scroll.CurrentLevel == LowerLevel)
            LevelUp();
        else if (collision.tag == "Player" && Scroll.CurrentLevel == UpperLevel)
            LevelDown();
    }
}
