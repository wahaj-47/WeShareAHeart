using UnityEngine;

public class MovementUtils : MonoBehaviour
{
    [SerializeField] private GameObject GroundCheck;
    [SerializeField] private GameObject SlopeCheck;

    public float CheckSlope()
    {
        RaycastHit2D hit = Physics2D.Raycast(SlopeCheck.transform.position, -SlopeCheck.transform.up, 5f, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            return Vector3.Dot(hit.normal, transform.right);
        }

        return 0f;
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(GroundCheck.transform.position, -GroundCheck.transform.up, 0.5f, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
