using UnityEngine;
using System.Collections;

public class FollowTargger : MonoBehaviour {
    public Transform player1;
    public Transform player2;

    private Vector3 mOffset;
    private Camera mCamera;
	// Use this for initialization
	void Start () {
        mOffset = transform.position - (player1.position + player2.position) / 2;
        mCamera = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player1 == null || player2 == null)
        {
            StartCoroutine("BattleEndStay");
            return;
        } 
        transform.position = (player1.position + player2.position) / 2 + mOffset;
        float distance = Vector3.Distance(player1.position, player2.position);
        float size = distance * 0.58f;
        if (size > 6) {
            mCamera.orthographicSize = size;
        }
        else
        {
            size = 6;
        }
	}

    private IEnumerator BattleEndStay()
    {
        yield return new WaitForSeconds(5f);
        BattleEnd.Instance.GameIsOver();
    }
}
