

/*
-----------------------------------------------------------------------------
	D520 jsMenu beta
-----------------------------------------------------------------------------
	Copyright (c) 2008 tkli

	This script can be used freely as long as all copyright messages are intact.
-----------------------------------------------------------------------------
*/

//global variables 


// jsMenu class

//使用範例： bar1 = new jsBar(workBar, "bar1", 0, 0, 0, 0, "atBottom", 20, 100, 18, "testBar", "#4C4C4C" );
//
//               div的ID    ID   清單    清單文字高度 背景圖案    子選單容器
function jsMenu(mParent, mId, mTheMenu, mTextHeight, mBackgroud, mSubMenuContainer, mWorkframe ){

	//****************************************** TKLI註解 ***********************************************************************//
	//
	//		
	//
	//***************************************************************************************************************************//
	
	//代入屬性
	//this.parent =  document.getElementById(mParentId); 
	this.parent =  mParent; 
	this.id = mId;
	
	this.textHeight = mTextHeight;
	this.backgroud = mBackgroud;
	
	this.theMenu = mTheMenu;  //清單
	
	this.menuActive = false;
	this.menuBoards = new Array();
	this.subMenuContainer = mSubMenuContainer;
	this.workframe = mWorkframe;
    //	this.workframe.style.visibility = "visible";
	
	
	//****************************************** TKLI註解 ***********************************************************************//
	// 取得 某個 項目清單的子項，當為 root 時，取得 第一層
	//***************************************************************************************************************************//
	this.getMenuItems = function(parent){

        //alert(parent);
		var menuItems = new Array();
		//var root =  this.theMenu.root;
		parent.moveToBeforeFirst();
		
		var counter = 0;
		while(true){
		    var menuItem = parent.nextChild();
		    //alert (menuItem.data.title );
		    if (menuItem != null) {
		        menuItems[counter] = menuItem;
		        counter++;
		    }
		    else {
		        menuItems[counter] = parent.lastChild;   //由於 最後一個點 沒有後一個，所以會傳回 null
		        counter++;		    
		        break;
		    }
		}
		
		return menuItems;
	
	}
	

	//****************************************** TKLI註解 ***********************************************************************//
	// 設定 第一層的選單
	// 同時，也先 初始化整個功能表
	//***************************************************************************************************************************//
	this.setupFirstLeval = function(){
	
        //產生 table
	    this.holder = document.createElement("table");
	    this.holder.owner = this;
	    this.parent.appendChild(this.holder);

	    
		//設定<TABLE>的屬性
		this.holder.style.zIndex = parseInt(this.parent.style.zIndex) + 100;
		this.holder.style.position = "absolute";

	    //產生<TBODY>
	    var tablebody = document.createElement("tbody");
	    this.holder.appendChild(tablebody);
				
		//產生<TR>
		this.holderLine = document.createElement("tr");
		this.holderLine.owner = this;
		tablebody.appendChild(this.holderLine);
					
		//設定<TR>屬性
		this.holderLine.style.width = this.holder.width ;
		this.holderLine.style.zIndex = this.holder.zIndex +5;
		
		//底下 加入 清單項目
		var firstLevalMenus = this.getMenuItems(this.theMenu.root);
		
		for (var i=0; i<firstLevalMenus.length; i++){
		    this.addFirstLevelItem(firstLevalMenus[i]);		
		}		
		
		//alert("hi3");
	
	}
	
	
	//****************************************** TKLI註解 ***********************************************************************//
	// 增加一個 第一層 的選單項目 
	//***************************************************************************************************************************//
	this.addFirstLevelItem = function(menuItem){
		var d = document.createElement("td");
		this.holderLine.appendChild(d);
		d.owner = this;
		
		d.menuItem = menuItem;

		//d.style.width = "100";
		d.style.paddingRight = "10px";
		d.innerHTML = menuItem.data.title;
		

	    //****************************************** TKLI註解 ***********************************************************************//
	    // 設定 選單項目  onclick 時 的動作
	    //***************************************************************************************************************************//
		d.onclick = function(){
		    //alert("goto " + link);
		    
		    this.menuActive = true;
		    this.owner.subMenuContainer.style.visibility = "visible";
		    this.owner.setupSubMenus(2, this, this.menuItem );
		    
		}
		
	    //****************************************** TKLI註解 ***********************************************************************//
	    // 設定 選單項目  onmouseover 時 的動作
	    //***************************************************************************************************************************//
		d.onmouseover = function(){
		    
		    if (this.owner.subMenuContainer.style.visibility  == "visible"){
	            this.owner.setupSubMenus(2, this, this.menuItem );
	        }

		}
		
	}

	
    //****************************************** TKLI註解 ***********************************************************************//
    // 設定 第二層以上的選單項目  
    //***************************************************************************************************************************//
	this.setupSubMenus = function(level, upperTD, parent ){
	    if (level <=1){ alert("錯誤的選單層數!!"); return;}
	    
	    //alert("產生子選單 for " + parent.data.title);
	    
	    //this.menuBoards
		//var d = document.createElement("td");
		//this.holderLine.appendChild(d);
		
		//var index = this.menuBoards.length; 
		var index = level; 
		for (var i= index; i<this.menuBoards.length; i++){
		    if (this.menuBoards[i] != null) this.menuBoards[i].style.display="none";    //清除 此 level 以下所有 的選單 boards
		}

	    if (parent.lastChild == null) return;

		//if (this.menuBoards[index] != null) delete this.menuBoards[index] ;
		this.menuBoards[index] = document.createElement("div");
		
		var theBoard = this.menuBoards[index];
		//theBoard.innerHTML = "測試";
		theBoard.style.position = "absolute";
		theBoard.style.zIndex = 10000;
		theBoard.style.left = 0;
		theBoard.style.top = 0;
		//theBoard.style.overflow = "auto";
		
		this.subMenuContainer.appendChild(theBoard );
		

        //產生 table
	    var holder = document.createElement("table");
	    theBoard.appendChild(holder);

	    
		//設定<TABLE>的屬性
		holder.style.zIndex = parseInt(theBoard.style.zIndex) + 1;
		holder.style.position = "absolute";
		//alert(  upperTD.innerHTML + ","+  upperTD.style.left);
	    if (level ==2){
	        holder.style.left = upperTD.getBoundingClientRect().left ;
	    }
	    else{
	        holder.style.left = upperTD.getBoundingClientRect().right ;   //注意，upperTD.getBoundingClientRect().right 取得是 相對於 視窗邊框 的 right位置
	        holder.style.top = parseInt(upperTD.offsetTop)  ;     //注意，upperTD.offsetTop 取得是 相對於 所在容器 的 top位置
	    }
	    

	    //產生<TBODY>
	    var tablebody = document.createElement("tbody");
	    holder.appendChild(tablebody);
				
		//設定<TR>屬性
		//holderLine.style.width = holder.width ;
		//holderLine.style.zIndex = parseInt(holder.zIndex) +5;
		
		//底下 加入 清單項目
		var subMenuItems = this.getMenuItems(parent);
		
		for (var i=0; i<subMenuItems.length; i++){
		    this.addSubMenuItem(level, subMenuItems[i], tablebody);		
		}		
		
	    
	}

	
	//****************************************** TKLI註解 ***********************************************************************//
	// 增加一個 第二層以 的選單項目 
	//***************************************************************************************************************************//
	this.addSubMenuItem = function(level, menuItem, holder){

	    if (level <=1){ alert("錯誤的選單層數!!"); return;}

		//產生<TR>
		var holderLine = document.createElement("tr");
		holder.appendChild(holderLine);
					
		var d = document.createElement("td");
		holderLine.appendChild(d);
		d.owner = this;
		
		d.menuItem = menuItem;

		d.style.width = "100";
		d.style.paddingLeft = "2px";
		d.style.paddingRight = "2px";
		d.innerHTML = menuItem.data.title;
		if (menuItem.lastChild != null) d.innerHTML += ">";
		

	    //****************************************** TKLI註解 ***********************************************************************//
	    // 設定 選單項目  onclick 時 的動作
	    //***************************************************************************************************************************//
		d.onclick = function(){
		    //alert("goto " + link);
		    
		    //this.menuActive = true;
		    //this.owner.subMenuContainer.style.visibility = "visible";
		    if (this.menuItem.lastChild != null){
		        //this.owner.setupSubMenus(level+1, this, this.menuItem );   //改成 onmouseover 就觸發
		    }
		    else {
		        this.owner.gotolink(this.menuItem.data.link);
		    }
		    
		}
		

	    //****************************************** TKLI註解 ***********************************************************************//
	    // 設定 選單項目  onmouseover 時 的動作
	    //***************************************************************************************************************************//
		d.onmouseover = function(){
		    
	        this.owner.setupSubMenus(level+1, this, this.menuItem );
		    
		}
		
		
	}

	
	//****************************************** TKLI註解 ***********************************************************************//
	// 執行 選單項目  
	//***************************************************************************************************************************//
	this.gotolink = function(link){
	    //alert("gotolink: " + link);
	    this.workframe.style.visibility  = "visible";
	    this.workframe.src = link;
	}
	
	
	//****************************************** TKLI註解 ***********************************************************************//
	// 呼叫  
	//***************************************************************************************************************************//
	this.setupFirstLeval();
	
}











