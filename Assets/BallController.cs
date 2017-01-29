using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	//得点を表示させるテキスト
	private GameObject gameScoreText;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		//シーン中のgameScoreTextオブジェクトを取得
		this.gameScoreText = GameObject.Find("GameScoreText");

	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		if (tag == "SmallStarTag") {
			this.gameScoreText.GetComponent<Text> ().text = "10";
		} else if (tag == "LargeStarTag") {
			this.gameScoreText.GetComponent<Text> ().text = "20";
		}else if(tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			this.gameScoreText.GetComponent<Text> ().text = "30";
		}
	}

}