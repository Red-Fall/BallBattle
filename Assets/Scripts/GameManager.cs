using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Directions {North = -1, South = 1};

    private static GameManager instance;
    public BallController ball;

    public Directions attackerGoalDirection = Directions.South;

    private void Awake() {
        instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    public static GameManager getInstance() {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
