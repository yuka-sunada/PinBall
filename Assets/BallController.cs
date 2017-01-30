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

	//スコア計算用変数
	private  int score = 0; 

		 
	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		//シーン中のgameScoreTextオブジェクトを取得
		this.gameScoreText = GameObject.Find("GameScoreText");

		//初期スコアを代入して表示
		score   = 0;
		SetScore();

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
			 score += 10;
		} else if (tag == "LargeStarTag") {
			 score += 20;
		}else if(tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			score += 30;
		}
		SetScore();
	}

	void SetScore()
	{
		this.gameScoreText.GetComponent<Text> ().text = score.ToString();
	}

}