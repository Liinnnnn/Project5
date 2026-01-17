using System.Collections;
using UnityEngine;

public class Hp : MonoBehaviour
{
    private bool collected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void Collected()
    {
        gameObject.SetActive(false);
    }
}
