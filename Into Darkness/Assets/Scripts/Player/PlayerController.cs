using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private InputHandler input;
    [SerializeField] private float speed;
    private Vector2 dirLocal = Vector2.zero;

    void Start() {
        input = FindObjectOfType<InputHandler>();
    }

    void FixedUpdate() {
        if (IsClient && IsOwner) {
            UpdateClient();
        }
    }
/**
    - reads local input
    - checks for data mismatch and updates server with rpc calls if mismatch
    - DOES NOT UPDATE NETWORK VARIABLES. Only update network variabes through RPC calls
*/
    private void UpdateClient() {            
        // fetch input and set if mismatched with local input\
        if (dirLocal != input.dir) {
            dirLocal = input.dir;
            InputMovementServerRpc(input.dir);
        }
    }

    [ServerRpc] private void InputMovementServerRpc(Vector2 dir) {
        dir.Normalize();

        SyncFacingClientRpc(dir.x);

        rbody.velocity = Vector2.zero;
        rbody.AddForce(speed * dir, ForceMode2D.Impulse);

        if (dir != Vector2.zero) {
            animator.SetBool("running", true);
        } else {
            animator.SetBool("running", false);
        }
    }

    [ClientRpc] private void SyncFacingClientRpc(float dir) {
        if (dir > 0) {
            spriteRenderer.flipX = false;
        }
        else if (dir < 0) {
            spriteRenderer.flipX = true;
        }
    }
}
