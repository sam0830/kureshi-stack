using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankScrollView : MonoBehaviour {

	[SerializeField]
	private GameObject rankPanel;
	[SerializeField]
	private RectTransform content;

	[SerializeField]
	private Text userRankLabel;

	private HighScoreRanking highScoreRanking;
	private NCMB.HighScore currentHighScore;

	private bool isScoreFetched;
	private bool isRankFetched;
	private bool isLeaderBoardFetched;

	private void Start() {
		if(userRankLabel == null) {
			userRankLabel = GameObject.Find("UserRankLabel").GetComponent<Text>();
		}
		content = GetComponent<ScrollRect>().content;
		highScoreRanking = new HighScoreRanking();
		// 現在のハイスコアを取得
	    currentHighScore = new NCMB.HighScore( -1, UserAuthManager.Instance.GetCurrentUserId());
	    currentHighScore.Fetch();
	}

	private void Update() {
    // 現在のハイスコアの取得が完了したら1度だけ実行
    if( currentHighScore.Score != -1 && !isScoreFetched ){
      	highScoreRanking.FetchRank( currentHighScore.Score );
      	isScoreFetched = true;
    }

    // 現在の順位の取得が完了したら1度だけ実行
    if( highScoreRanking.currentRank != 0 && !isRankFetched ){
		userRankLabel.text = highScoreRanking.currentRank + "位";
      	highScoreRanking.FetchTopRankers();
      	isRankFetched = true;
    }

    // ランキングの取得が完了したら1度だけ実行
    if( highScoreRanking.topRankers != null && !isLeaderBoardFetched){

      	// 取得したトップ100ランキングを表示
		for(int i=0;i<highScoreRanking.topRankers.Count;i++) {
			GameObject panel = (GameObject)Instantiate(rankPanel);
			panel.transform.Find("RankLabel").GetComponent<Text>().text = (i+1)+"位";
			panel.transform.Find("UserIdLabel").GetComponent<Text>().text = highScoreRanking.topRankers[i].Name;
			panel.transform.Find("ScoreLabel").GetComponent<Text>().text = highScoreRanking.topRankers[i].Score.ToString();
			panel.transform.SetParent(content, false);
		}
      	isLeaderBoardFetched = true;
    }
  }
}
