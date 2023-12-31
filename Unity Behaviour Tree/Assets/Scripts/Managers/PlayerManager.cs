using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamagable
{
    public static PlayerManager Instance { get; private set; }

    public int Health { get; private set; } = 5;
    public int MaxHealth { get; private set; } = 5;
    public float Speed;
    public bool IsAttacked = false;

    private Rigidbody2D rb;

    public void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        InputManager.Instance.OnW += OnW;
        InputManager.Instance.OnA += OnA;
        InputManager.Instance.OnS += OnS;
        InputManager.Instance.OnD += OnD;
    }

    public void Move(Vector2 dir)
    {
        rb.AddForce(dir * Speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnW()
    {
        Move(Vector2.up);
    }

    private void OnA()
    {
        Move(Vector2.left);
    }

    private void OnS()
    {
        Move(Vector2.down);
    }

    private void OnD()
    {
        Move(Vector2.right);
    }

    public void TakeDamage(int amount)
    {
        if (Health - amount > 0)
        {
            Health -= amount;
        }
        else
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player Died");
    }
}