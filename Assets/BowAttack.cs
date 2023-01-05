using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAttack : MonoBehaviour
{

    //currently does no damage

    public float bowDamage = 3f;
    public float bowLevelMultiplier = 1.0f; 
    public float attackCooldown = 0.8f;
    public float arrowSpeed = 5f;
    private float timeSinceLast = 0.0f;
    public GameObject arrowToShoot;

    void Start(){
        timeSinceLast = 0.0f;
    }

    void Update(){
        timeSinceLast += Time.deltaTime;
    }

    void Attack(){
        Vector2 startLoc = transform.position;
        startLoc.y = startLoc.y - 0.06f;
        Vector3 clickLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickLoc.z = 0f;
        Vector2 bulletVector = new Vector2(clickLoc.x - startLoc.x, clickLoc.y - startLoc.y);
        bulletVector.Normalize();

        GameObject freshSpawn = Instantiate(arrowToShoot);
        freshSpawn.transform.position = startLoc;
        freshSpawn.GetComponent<Rigidbody2D>().velocity = bulletVector * arrowSpeed;
        float angle = Mathf.Atan2(bulletVector.y, bulletVector.x) * Mathf.Rad2Deg;
        freshSpawn.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        freshSpawn.GetComponent<FriendlyProjectile>().damageToDeal = bowDamage * bowLevelMultiplier;
    }

    void OnFire(){
        if (timeSinceLast >= attackCooldown){
            timeSinceLast = 0f;
            Attack();
        }else{
            //not ready
        }
    }
}
