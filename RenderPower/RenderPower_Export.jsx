
(function(me){

	//-------------------------------------------------------------------------
	var winObj = ( me instanceof Panel) ? me : new Window("palette", "Form1", [ 0,  0,  260,  240]  ,{maximizeButton:true, minimizeButton:true});
	//-------------------------------------------------------------------------
	var yPos = 10;
	var lbInfo = winObj.add("statictext", [  10,   yPos,   10+ 240,   yPos +  24], "レンダリング情報ファイル作成");
	yPos += 30;
	var lbBlockCount = winObj.add("statictext",[  20, yPos, 20 + 180, yPos + 20], "レンダリングブロックの枚数");
	var edBlockCount = winObj.add("edittext",  [ 180, yPos,180 +  60, yPos + 20], "50");
	yPos += 30;
	var btnGetStatus = winObj.add("button",  [ 20, yPos,20 +  220, yPos + 20], "フレーム情報の獲得");
	yPos += 30;
	var lbStartFrame = winObj.add("statictext",[  20, yPos, 20 + 180, yPos + 20], "スタートフレーム");
	var edStartFrame = winObj.add("edittext",  [ 180, yPos,180 +  60, yPos + 20], "1");
	yPos += 30;
	var lbLastFrame = winObj.add("statictext", [  20, yPos, 20 + 180, yPos + 20], "ラストフレーム");
	var edLastFrame = winObj.add("edittext",  [ 180, yPos,180 +  60, yPos + 20], "0");
	yPos += 30;

	var btnExport = winObj.add("button", [  90,  yPos,   90+ 132,  yPos+  40], "export" );
	//-------------------------------------------------------------------------
	var getNumber = function(ed)
	{
		var ret = -1;
		if ((ed==null)||(ed.text == undefined)) return ret;
		ret = ed.text * 1;
		if (isNaN(ret)){
			ret = -1;
		}
		return ret;
	}
	//-------------------------------------------------------------------------
	var crlf = "\r\n";
	//-------------------------------------------------------------------------
	var listMake = function(s,l,bs)
	{
		var ret = "";
		var fc = l - s + 1;
		if (fc<=0) return ret;
		var c = Math.floor(fc / bs);
		var cm = fc % bs;
		
		var count = 0;
		if (c>0){
			for ( var i=0; i<c; i++)
			{
				ret += (s + i * bs) + "," + (s + (i+1)*bs -1) + ",,,w" + crlf;
				count += bs;
			}
		}
		if (cm>0)
		{
			ret += (s + c*bs) + "," + l+ ",,,w" + crlf;
		}
		return ret;
	}
	//-------------------------------------------------------------------------
	var exportRIF = function()
	{
		var exportFile = "";
		var exportListFile = "";
		var str = "RIF v1.00" + crlf;
		try{
			//aerenderを探す
			var f = new File(BridgeTalk.getAppPath(BridgeTalk.appName));
			if (f.exists==true) {
				str +=  "aerender:\"" + f.parent.fsName + "\\aerender.exe" + "\"" + crlf;
			}else{
				alert("none aerender!");
				return;
			}
			//aepの確認
			if ( (app.project.file == null)||(app.project.file.exists==false)){
				alert("aepが保存されていません！");
			}else{
				exportFile = app.project.file.fsName +".rif";
				exportListFile = app.project.file.fsName +".rifList";
			}
			str += "aep:\"" + app.project.file.fsName + "\"" + crlf;
			//各パレメータの獲得
			var v = getNumber(edBlockCount);
			if (v<=0) {
				alert("Error! : " + lbBlockCount.text);
				return;
			}
			str += "blockCount:" + v  + crlf;
			var blockCount = v;
			var v = getNumber(edStartFrame);
			if (v<0) {
				alert("Error! : " + lbStartFrame.text);
				return;
			}
			str += "startFrame:" + v  + crlf;
			var startFrame = v;
			var v = getNumber(edLastFrame);
			if (v<0) {
				alert("Error! : " + lbLastFrame.text);
				return;
			}
			str += "lastFrame:" + v  + crlf;
			var lastFrame = v;
			if( startFrame>lastFrame)
			{
				alert("Error! : スタート・ラストフレームが異常です" );
				return;
			}
			//レンダーキューの確認
			var isRQ = false;
			if ( app.project.renderQueue.numItems>0)
			{
				for (var i=1;i<=app.project.renderQueue.numItems;i++)
				{
					if (app.project.renderQueue.items[i].status == RQItemStatus.QUEUED)
					{
						isRQ = true;
					}
				}
			}
			if(isRQ==false)
			{
				alert("Error! : 有効なレンダーキューがありません" );
				return;
			}
			//書き出し
			var f = new File(exportFile);
			if (f.exists==true)
			{
				f.remove();
			}
			if (f.open("w")){
				try{
					f.encoding = "UTF-8";
					f.write(str);
					f.close();
				}catch(e){
					alert("Export失敗！");
				}
			}
			if (f.exists==true)
			{
					alert("Export OK!"+ crlf + f.fsName);
			}
			var str2 = listMake(startFrame,lastFrame,blockCount);
			var f2 = new File(exportListFile);
			if (f2.exists==true)
			{
				f2.remove();
			}
			if (f2.open("w")){
				try{
					f2.encoding = "UTF-8";
					f2.write(str2);
					f2.close();
				}catch(e){
					alert("Export List 失敗！");
				}
			}
			if ((f.exists==true)&&(f2.exitsts))
			{
					alert("Export OK!"+ crlf + f.fsName);
			}
			
			
		}catch(e){
		}
		 
	}
	btnExport.onClick = exportRIF;
	//-------------------------------------------------------------------------
	var getCompInfo = function()
	{
		var ac = app.project.activeItem;
		if ((ac ==null)||( (ac instanceof CompItem)==false))
		{
			alert("コンポがアクティブじゃない！");
			return;
		}
		var fps = ac.frameRate;
		var st = ac.workAreaStart + ac.displayStartTime;
		var lt = ac.workAreaDuration + st;
		st *= fps;
		lt = lt * fps -1;
		if ( app.project.displayStartFrame>0)
		{
			st+=1;
			lt+=1;
		}
		edStartFrame.text = st;
		edLastFrame.text = lt;
	}
	btnGetStatus.onClick = getCompInfo;
	//-------------------------------------------------------------------------
	if ( ( me instanceof Panel) == false){
		winObj.center(); 
		winObj.show();
	}
	//-------------------------------------------------------------------------
})(this);
