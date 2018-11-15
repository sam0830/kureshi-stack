using System.Collections;
using System.Collections.Generic;
using NCMB;

public class HighScoreRanking {
	public int currentRank = 0;
	public List<NCMB.HighScore> topRankers = null;
	// 現プレイヤーのハイスコアを受けとってランクを取得 ---------------
  	public void FetchRank( int currentScore ) {
	    // データスコアの「HighScore」から検索
	    NCMBQuery<NCMBObject> rankQuery = new NCMBQuery<NCMBObject> ("HighScore");
	    rankQuery.WhereGreaterThan("highScore", currentScore);
	    rankQuery.CountAsync((int count , NCMBException e )=>{

		    if(e != null){
		        //件数取得失敗
		    }else{
		        //件数取得成功
		        currentRank = count+1; // 自分よりスコアが上の人がn人いたら自分はn+1位
		    }
	    });
	}

	// サーバーからトップ5を取得 ---------------
  	public void FetchTopRankers() {
	    // データストアの「HighScore」クラスから検索
	    NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
	    query.OrderByDescending ("highScore");
	    query.Limit = 100;
	    query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {

		    if (e != null) {
		      //検索失敗時の処理
		    } else {
		        //検索成功時の処理
		        List<NCMB.HighScore> list = new List<NCMB.HighScore>();
		        // 取得したレコードをHighScoreクラスとして保存
		        foreach (NCMBObject obj in objList) {
		            int    s = System.Convert.ToInt32(obj["highScore"]);
		            string n = System.Convert.ToString(obj["userId"]);
		            list.Add( new HighScore( s, n ) );
		        }
		        topRankers = list;
		    }
		});
  	}
}
