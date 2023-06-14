using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script compiled before I could change name (mistapped enter) and now it's just NewBehaviourScript but the purpose is to stop collision between the player and attack hitbox
public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Player;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //something is going on here to cause it to not ignore the collision despite our best efforts and despite the lack of errors
            Physics2D.IgnoreCollision(Player.GetComponent<CapsuleCollider2D>(), GetComponent<BoxCollider2D>());
            //ignore collision is working, though it still pushes the player (for unknown reasons)
            Debug.Log("collision with player");
        }
        Invoke(nameof(kurt), 1f);
    }
    void kurt()
    {
        //this destroys the attack hitbox (works just fine)
        Destroy(gameObject);
    }
    //tried to get a void awake function in the physics.ignore collision, did not work
    //tried to put the physics.ignorecollision on player, did not work. Maybe try putting the physics.ignorecollision on the player?
}
