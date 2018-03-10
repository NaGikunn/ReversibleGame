using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMake : MonoBehaviour {
    int[] RoteAngle = { 90, 180, -90,-180}; //回転角度
    int RotaPattern = 0;//回転した時のswitch文でのパターンの数字
    int Bx, By, Bz;//for文で回す値スタートで全部書くと長くなったからやむなし
    int min, max;//回転するときの最大値と最小値
    int AngleMemory;//RoteAngleで決めた配列番号記憶
    public int Bpoint = 0, Wpoint = 0;//ポイントマス取得した回数記録
    public int BpointContinuation = 0, WpointContinuation = 0;//ポイントマスを継続しているときに加算される
    float RotationTime = 0; //時間 
    public GameObject CenterCube;//盤面部分のcube
    public GameObject InsideCube;//内側にあるcube
    public GameObject[,,] RubikArray = new GameObject[5, 5, 5];//cubeを配列で管理するため
    public GameObject[,,] kariRubuk = new GameObject[5, 5, 5];//仮で納める配列
    Vector3 Instantiatepos;//InstantiateがVector3の形じゃないとposition指定できなかったため
    Quaternion q = new Quaternion();//InstantiateがQuaternionを宣言しないととposition指定できなかったため
    PositionTeach ToTeach;
    // Use this for initialization
    void Start () {
        for (Bx = 0; Bx <= 4; Bx++)
        {//幅(X)
            for (By = 0; By <= 4; By++)
            {//高さ(Y)
                for (Bz = 0; Bz <= 4; Bz++)
                {//奥行き(Z)
                    Instantiatepos = new Vector3(Bx-2, By-4, Bz-2);
                    if (By == 4)//Y座標４のcubeを作るためにメソッドにとんでいる
                    {
                        BWMake();
                    }
                    else
                    {//それ以外のcubeを作るため
                        CubuMake();
                    }
                }
            }
        }
    }
    void BWMake()//Y軸状の座標４のcubeを作成している
    {
        //cubeの生成
        if (Bx == 0 || Bx == 4)
        {
            RubikArray[Bx, By, Bz] = Instantiate(CenterCube, Instantiatepos, q);
        }
        else
        {
            RubikArray[Bx, By, Bz] = Instantiate(CenterCube, Instantiatepos, q);
        }
    }
    void CubuMake()
    {
        if (By == 0)
        {//底面を生成するとき
            if (Bx == 0 || Bx == 4)
            {
                RubikArray[Bx, By, Bz] = Instantiate(CenterCube, Instantiatepos, q);
            }
            else
            {
                RubikArray[Bx, By, Bz] = Instantiate(CenterCube, Instantiatepos, q);
            }
        }
        else//底面以外のcubeを生成するとき
        {
            if (Bx == 0 || Bx == 4)
            {
                RubikArray[Bx, By, Bz] = Instantiate(CenterCube, Instantiatepos, q);
            }
            else
            {//karicubeを生成している
                if (Bz == 0 || Bz == 4)
                {//sidecubeを生成している
                    RubikArray[Bx, By, Bz] = Instantiate(CenterCube, Instantiatepos, q);
                }
                else
                {//karicubeを作っている
                    RubikArray[Bx, By, Bz] = Instantiate(InsideCube, Instantiatepos, q);
                }
            }
        }
    }
    // Update is called once per frame
    void Update ()
	{
        switch (RotaPattern)//回すメソッドに飛ぶ
        {
            case 1:
                XRotationStage();
                break;
            case 2:
                YRotationStage();
                break;
            case 3:
                ZRotationStage();
                break;
        }
    }
    public void RandomRote()//回転させる軸を決めている
    {
        min = Random.Range(0, 5);//回転させるposition指定
        max = Random.Range(1, 4);//回転させるposition指定
        AngleMemory = Random.Range(0, 4);//角度の配列番号選択
        RotaPattern = Random.Range(1, 4);//どの軸を回転させるか決める
        switch (RotaPattern)
        {
            case 1:
                XParent();
                break;
            case 2:
                YParent();
                break;
            case 3:
                ZParent();
                break;
        }
    }
    void XParent()//X軸の親オブジェクトを決めて範囲内のオブジェクトを親オブジェクトの子にしている
    {
        if (max >= min){
            for (Bx = min; Bx <= max; Bx++){
                for (By = 0; By <= 4; By++){
                    for (Bz = 0; Bz <= 4; Bz++){
                        if (min == 0){//回転させるときの親オブジェクトをInsidecubeにするための処理
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[min+1, 2, 2].transform;
                        }else if (min == 4){
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[min-1, 2, 2].transform;
                        }else{
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[min, 2, 2].transform;
                        }   
                    }
                }
            }
        }else{
            int i = max;
            max = min;
            min = i;
            for (Bx = min; Bx <= max; Bx++){
                for (By = 0; By <= 4; By++){
                    for (Bz = 0; Bz <= 4; Bz++){
                        if (min == 0){//回転させるときの親オブジェクトをInsidecubeにするための処理
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[min + 1, 2, 2].transform;
                        }else if (min == 4){
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[min - 1, 2, 2].transform;
                        }else{
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[min, 2, 2].transform;
                        }
                    }
                }
            }
        }
    }
    void XRotationStage()//Xの親オブジェクトを基準に回転させている
    {
        RotationTime += Time.deltaTime;
        float rote = Mathf.LerpAngle(0, RoteAngle[AngleMemory], RotationTime);
        if (RotationTime <= 1)
        {
            if (min == 0){//回転させるときの親オブジェクトをInsidecubeにするための処理
                RubikArray[min+1, 2, 2].transform.eulerAngles = new Vector3(rote, 0, 0);
            }else if (min == 4){
                RubikArray[min-1, 2, 2].transform.eulerAngles = new Vector3(rote, 0, 0);
            }else{
                RubikArray[min, 2, 2].transform.eulerAngles = new Vector3(rote, 0, 0);
            }
        }else{
            if (min == 0)
            {//親オブジェクトから子オブジェクトを切り離す処理
                RubikArray[min + 1, 2, 2].transform.eulerAngles = new Vector3(RoteAngle[AngleMemory], 0, 0);//回転処理だけでは正しい値まで少しだけいけないので補正
                RubikArray[min + 1, 2, 2].transform.DetachChildren();//親子関係を解除
            }
            else if (min == 4)
            {
                RubikArray[min - 1, 2, 2].transform.eulerAngles = new Vector3(RoteAngle[AngleMemory], 0, 0);//回転処理だけでは正しい値まで少しだけいけないので補正
                RubikArray[min - 1, 2, 2].transform.DetachChildren();//親子関係を解除
            }
            else
            {
                RubikArray[min, 2, 2].transform.eulerAngles = new Vector3(RoteAngle[AngleMemory], 0, 0);//回転処理だけでは正しい値まで少しだけいけないので補正
                RubikArray[min, 2, 2].transform.DetachChildren();//親子関係を解除
            }
            RoteArray();
            RotationTime = 0;
            RotaPattern = 0;
        }
    }
    void YParent()//Y軸の親オブジェクトを決めて範囲内のオブジェクトを親オブジェクトの子にしている
    {
        if (max >= min){
            for (Bx = 0; Bx <= 4; Bx++){
                for (By = min; By <= max; By++){
                    for (Bz = 0; Bz <= 4; Bz++){
                        if (min == 0){//回転させるときの親オブジェクトをInsidecubeにするための処理
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, min + 1, 2].transform;
                        }else if (min == 4){
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, min - 1, 2].transform;
                        }else{
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, min, 2].transform;
                        }
                    }
                }
            }
        }else{
            int i = max;
            max = min;
            min = i;
            for (Bx = 0; Bx <= 4; Bx++){
                for (By = min; By <= max; By++){
                    for (Bz = 0; Bz <= 4; Bz++){
                        if (min == 0){//回転させるときの親オブジェクトをInsidecubeにするための処理
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, min + 1, 2].transform;
                        }else if (min == 4){
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, min - 1, 2].transform;
                        }else{
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, min, 2].transform;
                        }
                    }
                }
            }
        }
    }
    void YRotationStage()//Yの親オブジェクトを基準に回転させている
    {
        RotationTime += Time.deltaTime;
        if (RotationTime <= 1){//Yの親オブジェクトを基準に回転させている
            float rote = Mathf.LerpAngle(0, RoteAngle[AngleMemory], RotationTime);
            if (min == 0){
                RubikArray[2, min+1, 2].transform.eulerAngles = new Vector3(0, rote, 0);
            }else if (min == 4){
                RubikArray[2, min-1, 2].transform.eulerAngles = new Vector3(0, rote, 0);
            }else{
                RubikArray[2, min, 2].transform.eulerAngles = new Vector3(0, rote, 0);
            }      
        }else{
            if (min == 0)
            {//親オブジェクトから子オブジェクトを切り離している
                RubikArray[2, min+1, 2].transform.eulerAngles = new Vector3(0, RoteAngle[AngleMemory], 0);//回転処理だけでは正しい値まで少しだけいけないので補正
                RubikArray[2, min+1, 2].transform.DetachChildren();
            }
            else if (min == 4){
                RubikArray[2, min - 1, 2].transform.eulerAngles = new Vector3(0, RoteAngle[AngleMemory], 0);//回転処理だけでは正しい値まで少しだけいけないので補正
                RubikArray[2, min - 1, 2].transform.DetachChildren();
            }
            else{
                RubikArray[2, min, 2].transform.eulerAngles = new Vector3(0, RoteAngle[AngleMemory], 0);//回転処理だけでは正しい値まで少しだけいけないので補正
                RubikArray[2, min, 2].transform.DetachChildren();
            }
            RoteArray();
            RotationTime = 0;
            RotaPattern = 0;
        }
    }
    void ZParent()//Z軸の親オブジェクトを決めて範囲内のオブジェクトを親オブジェクトの子にしている
    {
        if (max >= min){
            for (Bx = 0; Bx <= 4; Bx++){
                for (By = 0; By <= 4; By++){
                    for (Bz = min; Bz <= max; Bz++){
                        RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, 2, min].transform;
                        if (min == 0){//回転させるときの親オブジェクトをInsidecubeにするための処理
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, 2, min + 1].transform;
                        }else if (min == 4){
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, 2, min - 1].transform;
                        }else{
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, 2, min].transform;
                        }
                    }
                }
            }
        }else{
            int i = max;
            max = min;
            min = i;
            for (Bx = 0; Bx <= 4; Bx++){
                for (By = 0; By <= 4; By++){
                    for (Bz = min; Bz <= max; Bz++){
                        if (min == 0){//回転させるときの親オブジェクトをInsidecubeにするための処理
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, 2, min + 1].transform;
                        }else if (min == 4){
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, 2, min - 1].transform;
                        } else{
                            RubikArray[Bx, By, Bz].transform.parent = RubikArray[2, 2, min].transform;
                        }
                    }
                }
            }
        }
    }
    void ZRotationStage()
    {
        RotationTime += Time.deltaTime;
        if (RotationTime <= 1){//Zの親オブジェクトを基準に回転させている
            float rote = Mathf.LerpAngle(0, RoteAngle[AngleMemory], RotationTime);
            if (min == 0){
                RubikArray[2, 2, min+1].transform.eulerAngles = new Vector3(0, 0, rote);
            }else if (min == 4){
                RubikArray[2, 2, min-1].transform.eulerAngles = new Vector3(0, 0, rote);
            }else{
                RubikArray[2, 2, min].transform.eulerAngles = new Vector3(0, 0, rote);
            }  
        }else{
            if (min == 0)
            {//Zの親オブジェクトから子オブジェクトを切り離している
                RubikArray[2, 2, min+1].transform.eulerAngles = new Vector3(0, 0, RoteAngle[AngleMemory]);//回転処理だけでは正しい値まで少しだけいけないので補正
                RubikArray[2, 2, min+1].transform.DetachChildren();
            }
            else if (min == 4){
                RubikArray[2, 2, min - 1].transform.eulerAngles = new Vector3(0, 0, RoteAngle[AngleMemory]);//回転処理だけでは正しい値まで少しだけいけないので補正
                RubikArray[2, 2, min-1].transform.DetachChildren();
            }
            else{
                RubikArray[2, 2, min].transform.eulerAngles = new Vector3(0, 0, RoteAngle[AngleMemory]);//回転処理だけでは正しい値まで少しだけいけないので補正
                RubikArray[2, 2, min].transform.DetachChildren();
            }
            RoteArray();
            RotationTime = 0;
            RotaPattern = 0;
        }
    }
    void RoteArray()
    {//各cubeのポジションを取得するためにPointPlaceを読んでいる
        for (Bx = 0; Bx <= 4; Bx++)
        {
            for (By = 0; By <= 4; By++)
            {
                for (Bz = 0; Bz <= 4; Bz++)
                {
                    ToTeach = RubikArray[Bx, By, Bz].GetComponent<PositionTeach>();
                    ToTeach.ArrayChange();
                }
            }
        }//PointPlaceで仮配列に入れてそれを入れ替えている
        for (Bx = 0; Bx <= 4; Bx++)
        {
            for (By = 0; By <= 4; By++)
            {
                for (Bz = 0; Bz <= 4; Bz++)
                {
                    RubikArray[Bx, By, Bz] = kariRubuk[Bx, By, Bz];
                }
            }
        }
        for (Bx = 1; Bx <= 3; Bx++)
        {
            for (By = 1; By <= 3; By++)
            {
                for (Bz = 1; Bz <= 3; Bz++)
                {
                    RubikArray[Bx, By, Bz].transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }
    }
}
