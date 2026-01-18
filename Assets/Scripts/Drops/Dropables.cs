using System.Collections;
using UnityEngine;

public abstract class Dropables : MonoBehaviour,ICollectibles
{
    private bool collected;
    void OnEnable()
    {
        collected = false;
    }
    public void Collect(Player player)
    {
        if (collected)
        {
            return;
        }
        collected = true;
        StartCoroutine(collecting(player));
    }
    private IEnumerator collecting(Player player)
    {
        float timer = 0;
        Vector2 hp = transform.position;
        while (timer <=1)
        {
            Vector2 playerpos = player.getCenter();
            transform.position = Vector2.Lerp(hp,playerpos,timer);
            timer += Time.deltaTime;
            yield return null;
        }
        Collected();
    }

    protected abstract void Collected();
}
