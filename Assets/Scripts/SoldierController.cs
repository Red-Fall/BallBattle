using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public enum Roles {Attacker, Defender};
    public enum States {Spawning, Active, Inactive};

    public Roles role;
    public Material attackerColor;
    public Material defenderColor;
    public Material inactiveColor;
    public float spawnTime = 0.5f;
    public float attackerInactiveTime = 2.5f;
    public float defenderInactiveTime = 4.0f;
    public float attackerNormalMoveSpeed = 1.5f;
    public float defenderNormalMoveSpeed = 1.0f;
    public float attackerMoveSpeedWithBall = 0.75f;

    private GameManager gameManager;
    private States currentState;
    private float stateTime = 0;
    private Vector3 startPosition;
    private bool hasTheBall = false;

    // Start is called before the first frame update
    void Start() {
        Init();
        this.GetComponent<Rigidbody>().AddForce(new Vector3((float)gameManager.attackerGoalDirection * -1.0f, 0, 0), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update() {
        stateTime += Time.deltaTime;
        switch(currentState) {
            case States.Spawning:
                if(stateTime > spawnTime)
                    setState(States.Active);
                break;
            case States.Active:
                if(role == Roles.Attacker) {
                    float speed = hasTheBall ? attackerMoveSpeedWithBall : attackerNormalMoveSpeed;
                    if(gameManager.ball.isInPossession()) {
                        this.transform.Translate(new Vector3((float)gameManager.attackerGoalDirection * -1.0f, 0, 0) * speed * stateTime);
                    } else {
                        this.transform.position = Vector3.Lerp(startPosition, gameManager.ball.transform.position, speed * stateTime);
                    }
                }
                break;
        }
    }

    public void Init(Roles newRole) {
        role = newRole;
        Init();
    }

    private void Init() {
        gameManager = GameManager.getInstance();
        setState(States.Spawning);
        startPosition = this.transform.position;
    }

    private void setState(States newState) {
        switch(newState) {
            case States.Spawning:
                this.gameObject.SetActive(true);
                this.GetComponent<MeshRenderer>().material = inactiveColor;
                break;
            case States.Active:
                this.GetComponent<MeshRenderer>().material = role == Roles.Attacker ? attackerColor : defenderColor;
                break;
        }
        currentState = newState;
        stateTime = 0;
    }

    private void OnCollisionEnter(Collision other) {
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == gameManager.ball.gameObject) {
            // hasTheBall = true;
            // gameManager.ball.setInPossesionState(true);
            Debug.Log("OnTriggerEnter");
        }
    }
}
