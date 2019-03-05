using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RaycastController))]
public class RedPaddle : MonoBehaviour
{
    public float speed = 1;



    void Start()
    {
        
    }

    void Update()
    {
        float moveAmount = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * moveAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * moveAmount);
        }
    }


    /*void HorizontalCollisions(ref Vector2 moveAmount)
    {
        float directionX = collisions.faceDir;
        float rayLength = Mathf.Abs(moveAmount.x) + skinWidth;

        if (Mathf.Abs(moveAmount.x) < skinWidth)
            rayLength = 2 * skinWidth;

        //Ledge stuff
        float ledgeHangPosY = 0;    //Used to set the player's Y position to the ledge's Y position
        float ledgeHangPosX = 0;    //Used to set the player's X position to the ledge's X position

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength * 3, Color.red);

            if (hit)
            {
                //If the thing we hit is a through platform OR we are literally inside of what we are hitting, skip this ray
                if (hit.collider.tag == "Through" || hit.distance == 0)
                    continue;

                float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

                //If this is the bottomLeft/bottomRight ray AND we are not hitting a steep slope, climb the slope
                if (i == 0 && slopeAngle <= maxSlopeAngle)
                {
                    //Handle suddenly climbing a slope immediately after having been descending a slope
                    if (collisions.descendingSlope)
                    {
                        collisions.descendingSlope = false;
                        moveAmount = collisions.moveAmountOld;
                    }

                    //Handle snapping the player to the slope in order to start climbing
                    float distanceToSlopeStart = 0;
                    if (slopeAngle != collisions.slopeAngleOld)
                    {
                        distanceToSlopeStart = hit.distance - skinWidth;
                        moveAmount.x -= distanceToSlopeStart * directionX;
                    }

                    ClimbSlope(ref moveAmount, slopeAngle, hit.normal);
                    moveAmount.x += distanceToSlopeStart * directionX;
                }

                //If we are not climbing slope OR we are hitting a steep slope/wall, detect wall collisions as normal
                if (!collisions.climbingSlope || slopeAngle > maxSlopeAngle)
                {
                    moveAmount.x = (hit.distance - skinWidth) * directionX;
                    rayLength = hit.distance;

                    //Handle colliding with wall while climbing slope
                    if (collisions.climbingSlope)
                        moveAmount.y = Mathf.Tan(collisions.slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(moveAmount.x);

                    //Ledge thing
                    if (hit.collider.tag == "Ledge")
                        collisions.numLedgeRayHits++;

                    collisions.left = directionX == -1;
                    collisions.right = directionX == 1;
                }

                if (hit.collider.tag == "Ledge" && ledgeCooldownTimer <= 0)
                {
                    ledgeHangPosX = (collisions.left) ? (hit.collider.bounds.max.x + 0.5f) : (hit.collider.bounds.min.x - 0.5f);  //If the player is colliding the right side of the ledge, set them to the right of it, else set them to the left of it
                    ledgeHangPosY = hit.collider.bounds.max.y - 0.5f;
                }
            }
        }

        if (collisions.hangingOnLedge == false && ledgeCooldownTimer <= 0 && collisions.numLedgeRayHits >= horizontalRayCount * 0.9f)
            SnapToLedge(ledgeHangPosX, ledgeHangPosY);
    }

    void VerticalCollisions(ref Vector2 moveAmount)
    {
        float directionY = Mathf.Sign(moveAmount.y);
        float rayLength = Mathf.Abs(moveAmount.y) + skinWidth;

        for (int i = 0; i < verticalRayCount; i++)
        {

            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + moveAmount.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength * 3, Color.red);

            if (hit)
            {
                //Handle Through platform stuff
                if (hit.collider.tag == "Through")
                {
                    //If we're traveling up through a Through platform, skip this ray
                    if (directionY == 1 || hit.distance == 0)
                        continue;
                    //If we're falling through a Through platform, skip this ray
                    if (collisions.fallingThroughPlatform)
                        continue;
                    //If we're on a Through platform and the player presses DOWN and SPACE, make them fall through
                    if (playerInput.y == -1 && Input.GetKeyDown(KeyCode.Space))
                    {
                        collisions.fallingThroughPlatform = true;
                        GetComponent<Player>().canCheckForGraceJump = false;
                        Invoke("ResetFallingThroughPlatform", .1f);
                        continue;
                    }
                }

                moveAmount.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;   //POTENTIALLY REMOVE THIS

                //Handle hitting a ceiling while moving up a slope
                if (collisions.climbingSlope)
                    moveAmount.x = moveAmount.y / Mathf.Tan(collisions.slopeAngle * Mathf.Deg2Rad) * Mathf.Sign(moveAmount.x);

                collisions.below = directionY == -1;
                collisions.above = directionY == 1;
            }
        }*/
    }
}