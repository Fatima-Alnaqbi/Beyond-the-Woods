using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public class Respawn : MonoBehaviour
{
    private Health health;
    private Rigidbody2D rb;
    private Vector3 checkpointPosition;
    private bool respawning;

    void Awake()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        checkpointPosition = transform.position;
    }

    void OnEnable()
    {
        health.Died += OnDeath;
    }

    void OnDisable()
    {
        health.Died -= OnDeath;
    }

    public void SetCheckpoint(Vector3 position)
    {
        checkpointPosition = position;
        Debug.Log("Checkpoint activated!");
    }

    void OnDeath()
    {
        if (!respawning)
            StartCoroutine(RespawnPlayer());
    }

    IEnumerator RespawnPlayer()
    {
        respawning = true;

        // Wait 1 second after death
        yield return new WaitForSeconds(1f);

        rb.linearVelocity = Vector2.zero;
        rb.position = checkpointPosition;

        health.ResetFull();

        respawning = false;
    }
}
