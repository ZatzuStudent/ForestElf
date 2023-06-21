using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    public CollectableType type;

    public string targetTag = "Player";
    public float followRange = 10f;
    public float moveSpeed = 5f;

    private GameObject targetObject;

    private void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
    }

    private void Update()
    {
        if (targetObject != null)
        {
            float distance = Vector3.Distance(transform.position, targetObject.transform.position);

            if (distance <= followRange)
            {
                Vector3 direction = (targetObject.transform.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            player.inventory.Add(type);
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, BERRIES
}