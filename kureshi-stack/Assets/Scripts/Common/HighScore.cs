using System.Collections;
using System.Collections.Generic;
using NCMB;

namespace NCMB {
	public class HighScore {
		public int Score   { get; set; }
    	public string Name { get; private set; }
		// コンストラクタ -----------------------------------
	    public HighScore(int score, string name) {
	        Score = score;
	        Name  = name;
	    }

		// サーバーにハイスコアを保存 -------------------------
	    public void Save() {
	      // データストアの「HighScore」クラスから、Nameをキーにして検索
	      NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
	      query.WhereEqualTo ("userId", Name);
	      query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {

	        //検索成功したら
	        if (e == null) {
	          objList[0]["highScore"] = Score;
	          objList[0].SaveAsync();
	        }
	      });
	    }

		// サーバーからハイスコアを取得  -----------------
	    public void Fetch() {
		    // データストアの「HighScore」クラスから、Nameをキーにして検索
		    NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
		    query.WhereEqualTo ("userId", Name);
		    query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {

		    //検索成功したら
			    if (e == null) {
			        // ハイスコアが未登録だったら
			        if( objList.Count == 0 ) {
			            NCMBObject obj = new NCMBObject("HighScore");
			            obj["userId"]  = Name;
			            obj["highScore"] = 0;
			            obj.SaveAsync();
			            Score = 0;
			        }
			        // ハイスコアが登録済みだったら
			        else {
			            Score = System.Convert.ToInt32( objList[0]["highScore"] );
			        }
			    }
		    });
	    }
	}
}
