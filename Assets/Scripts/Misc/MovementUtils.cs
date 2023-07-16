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
            float dot = Vector3.Dot(hit.normal, transform.right);

            if(dot < 0.3 || dot > -0.3)
                return dot;
        }

        return 0f;
    }

    public bool IsGrounded()
    {

        RaycastHit2D hit = Physics2D.CircleCast(GroundCheck.transform.position, 0.5f, -GroundCheck.transform.up, 0.5f, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
