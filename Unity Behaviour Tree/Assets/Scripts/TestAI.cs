using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAI : MonoBehaviour
{
    public Text CurrentBranch;
    public Text CurrentNode;
    public GameObject ParticlePrefab;

    private BT bt = new BT();

    public void Start()
    {
        InitBlackboard();

        //Behaviour
        Patrol patrol = new Patrol();
        patrol.SetArea(new Vector2(-20, 20), new Vector2(20, -20));
        bt.Add(patrol);
    }

    public void FixedUpdate()
    {
        CurrentBranch.text = bt.Blackboard.Get<string>("CurrentBranch");
        CurrentNode.text = bt.Blackboard.Get<string>("CurrentNode");
        bt.Tick();
    }

    public void InstantiateObject(GameObject _prefab, Vector2 _pos)
    {
        Instantiate(_prefab, new Vector3(_pos.x, _pos.y, 0), Quaternion.identity);
    }

    private void InitBlackboard()
    {
        bt.Blackboard.AddType<Rigidbody2D>();
        bt.Blackboard.AddType<GameObject>();
        bt.Blackboard.AddType<Vector2>();
        bt.Blackboard.AddType<TestAI>();
        bt.Blackboard.AddType<string>();
        bt.Blackboard.AddType<float>();

        bt.Blackboard.Add<Rigidbody2D>("RB2D", GetComponent<Rigidbody2D>());
        bt.Blackboard.Add<GameObject>("Body", gameObject);
        bt.Blackboard.Add<GameObject>("Particle", ParticlePrefab);
        bt.Blackboard.Add<TestAI>("TestAI", this);
        bt.Blackboard.Add<string>("CurrentBranch");
        bt.Blackboard.Add<string>("CurrentNode");
        bt.Blackboard.Add<float>("Speed", 10);
    }
}
