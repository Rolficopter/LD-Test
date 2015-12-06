using UnityEngine;
using System.Collections;

public class WalkingScript : StateMachineBehaviour {

    Transform leftPivot;
    Transform leftLeg;
    Transform rightPivot;
    Transform rightLeg;

    float leftZ, rightZ;
    bool leftGoingLeft, rightGoingLeft = true;


	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        leftPivot = animator.transform.Find("leg_left");
        leftLeg = leftPivot.Find("left");
        rightPivot = animator.transform.Find("leg_right");
        rightLeg = rightPivot.Find("right");
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (leftGoingLeft)
        {
            leftZ += Time.deltaTime * 200 * animator.GetFloat("Velocity");
            if (leftZ > 45)
            {
                leftGoingLeft = false;
            }
        }
        else
        {
            leftZ -= Time.deltaTime * 200 * animator.GetFloat("Velocity");
            if (leftZ < -45)
            {
                leftGoingLeft = true;
            }
        }
        leftLeg.eulerAngles = new Vector3(0, 0, leftZ);

        if (rightGoingLeft)
        {
            rightZ += Time.deltaTime * 200 * animator.GetFloat("Velocity");
            if (rightZ > 45)
            {
                rightGoingLeft = false;
            }
        }
        else
        {
            rightZ -= Time.deltaTime * 200 * animator.GetFloat("Velocity");
            if (rightZ < -45)
            {
                rightGoingLeft = true;
            }
        }

        rightLeg.eulerAngles = new Vector3(0, 0, rightZ);

	}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
