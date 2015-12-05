using UnityEngine;
using System.Collections;

public class WalkingScript : StateMachineBehaviour {

    Transform leftPivot;
    Transform leftLeg;
    Transform rightPivot;
    Transform rightLeg;


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
        leftLeg.Rotate(leftLeg.forward, 5000 * Time.deltaTime);
        rightLeg.Rotate(leftLeg.forward, -5000 * Time.deltaTime);

	}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
