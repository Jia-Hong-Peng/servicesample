

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

//�ϥνd�ҡG bar1 = new jsBar(workBar, "bar1", 0, 0, 0, 0, "atBottom", 20, 100, 18, "testBar", "#4C4C4C" );
//
//               div��ID    ID   �M��    �M���r���� �I���Ϯ�    �l���e��
function jsMenu(mParent, mId, mTheMenu, mTextHeight, mBackgroud, mSubMenuContainer, mWorkframe ){

	//****************************************** TKLI���� ***********************************************************************//
	//
	//		
	//
	//***************************************************************************************************************************//
	
	//�N�J�ݩ�
	//this.parent =  document.getElementById(mParentId); 
	this.parent =  mParent; 
	this.id = mId;
	
	this.textHeight = mTextHeight;
	this.backgroud = mBackgroud;
	
	this.theMenu = mTheMenu;  //�M��
	
	this.menuActive = false;
	this.menuBoards = new Array();
	this.subMenuContainer = mSubMenuContainer;
	this.workframe = mWorkframe;
    //	this.workframe.style.visibility = "visible";
	
	
	//****************************************** TKLI���� ***********************************************************************//
	// ���o �Y�� ���زM�檺�l���A�� root �ɡA���o �Ĥ@�h
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
		        menuItems[counter] = parent.lastChild;   //�ѩ� �̫�@���I �S����@�ӡA�ҥH�|�Ǧ^ null
		        counter++;		    
		        break;
		    }
		}
		
		return menuItems;
	
	}
	

	//****************************************** TKLI���� ***********************************************************************//
	// �]�w �Ĥ@�h�����
	// �P�ɡA�]�� ��l�ƾ�ӥ\���
	//***************************************************************************************************************************//
	this.setupFirstLeval = function(){
	
        //���� table
	    this.holder = document.createElement("table");
	    this.holder.owner = this;
	    this.parent.appendChild(this.holder);

	    
		//�]�w<TABLE>���ݩ�
		this.holder.style.zIndex = parseInt(this.parent.style.zIndex) + 100;
		this.holder.style.position = "absolute";

	    //����<TBODY>
	    var tablebody = document.createElement("tbody");
	    this.holder.appendChild(tablebody);
				
		//����<TR>
		this.holderLine = document.createElement("tr");
		this.holderLine.owner = this;
		tablebody.appendChild(this.holderLine);
					
		//�]�w<TR>�ݩ�
		this.holderLine.style.width = this.holder.width ;
		this.holderLine.style.zIndex = this.holder.zIndex +5;
		
		//���U �[�J �M�涵��
		var firstLevalMenus = this.getMenuItems(this.theMenu.root);
		
		for (var i=0; i<firstLevalMenus.length; i++){
		    this.addFirstLevelItem(firstLevalMenus[i]);		
		}		
		
		//alert("hi3");
	
	}
	
	
	//****************************************** TKLI���� ***********************************************************************//
	// �W�[�@�� �Ĥ@�h ����涵�� 
	//***************************************************************************************************************************//
	this.addFirstLevelItem = function(menuItem){
		var d = document.createElement("td");
		this.holderLine.appendChild(d);
		d.owner = this;
		
		d.menuItem = menuItem;

		//d.style.width = "100";
		d.style.paddingRight = "10px";
		d.innerHTML = menuItem.data.title;
		

	    //****************************************** TKLI���� ***********************************************************************//
	    // �]�w ��涵��  onclick �� ���ʧ@
	    //***************************************************************************************************************************//
		d.onclick = function(){
		    //alert("goto " + link);
		    
		    this.menuActive = true;
		    this.owner.subMenuContainer.style.visibility = "visible";
		    this.owner.setupSubMenus(2, this, this.menuItem );
		    
		}
		
	    //****************************************** TKLI���� ***********************************************************************//
	    // �]�w ��涵��  onmouseover �� ���ʧ@
	    //***************************************************************************************************************************//
		d.onmouseover = function(){
		    
		    if (this.owner.subMenuContainer.style.visibility  == "visible"){
	            this.owner.setupSubMenus(2, this, this.menuItem );
	        }

		}
		
	}

	
    //****************************************** TKLI���� ***********************************************************************//
    // �]�w �ĤG�h�H�W����涵��  
    //***************************************************************************************************************************//
	this.setupSubMenus = function(level, upperTD, parent ){
	    if (level <=1){ alert("���~�����h��!!"); return;}
	    
	    //alert("���ͤl��� for " + parent.data.title);
	    
	    //this.menuBoards
		//var d = document.createElement("td");
		//this.holderLine.appendChild(d);
		
		//var index = this.menuBoards.length; 
		var index = level; 
		for (var i= index; i<this.menuBoards.length; i++){
		    if (this.menuBoards[i] != null) this.menuBoards[i].style.display="none";    //�M�� �� level �H�U�Ҧ� ����� boards
		}

	    if (parent.lastChild == null) return;

		//if (this.menuBoards[index] != null) delete this.menuBoards[index] ;
		this.menuBoards[index] = document.createElement("div");
		
		var theBoard = this.menuBoards[index];
		//theBoard.innerHTML = "����";
		theBoard.style.position = "absolute";
		theBoard.style.zIndex = 10000;
		theBoard.style.left = 0;
		theBoard.style.top = 0;
		//theBoard.style.overflow = "auto";
		
		this.subMenuContainer.appendChild(theBoard );
		

        //���� table
	    var holder = document.createElement("table");
	    theBoard.appendChild(holder);

	    
		//�]�w<TABLE>���ݩ�
		holder.style.zIndex = parseInt(theBoard.style.zIndex) + 1;
		holder.style.position = "absolute";
		//alert(  upperTD.innerHTML + ","+  upperTD.style.left);
	    if (level ==2){
	        holder.style.left = upperTD.getBoundingClientRect().left ;
	    }
	    else{
	        holder.style.left = upperTD.getBoundingClientRect().right ;   //�`�N�AupperTD.getBoundingClientRect().right ���o�O �۹�� ������� �� right��m
	        holder.style.top = parseInt(upperTD.offsetTop)  ;     //�`�N�AupperTD.offsetTop ���o�O �۹�� �Ҧb�e�� �� top��m
	    }
	    

	    //����<TBODY>
	    var tablebody = document.createElement("tbody");
	    holder.appendChild(tablebody);
				
		//�]�w<TR>�ݩ�
		//holderLine.style.width = holder.width ;
		//holderLine.style.zIndex = parseInt(holder.zIndex) +5;
		
		//���U �[�J �M�涵��
		var subMenuItems = this.getMenuItems(parent);
		
		for (var i=0; i<subMenuItems.length; i++){
		    this.addSubMenuItem(level, subMenuItems[i], tablebody);		
		}		
		
	    
	}

	
	//****************************************** TKLI���� ***********************************************************************//
	// �W�[�@�� �ĤG�h�H ����涵�� 
	//***************************************************************************************************************************//
	this.addSubMenuItem = function(level, menuItem, holder){

	    if (level <=1){ alert("���~�����h��!!"); return;}

		//����<TR>
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
		

	    //****************************************** TKLI���� ***********************************************************************//
	    // �]�w ��涵��  onclick �� ���ʧ@
	    //***************************************************************************************************************************//
		d.onclick = function(){
		    //alert("goto " + link);
		    
		    //this.menuActive = true;
		    //this.owner.subMenuContainer.style.visibility = "visible";
		    if (this.menuItem.lastChild != null){
		        //this.owner.setupSubMenus(level+1, this, this.menuItem );   //�令 onmouseover �NĲ�o
		    }
		    else {
		        this.owner.gotolink(this.menuItem.data.link);
		    }
		    
		}
		

	    //****************************************** TKLI���� ***********************************************************************//
	    // �]�w ��涵��  onmouseover �� ���ʧ@
	    //***************************************************************************************************************************//
		d.onmouseover = function(){
		    
	        this.owner.setupSubMenus(level+1, this, this.menuItem );
		    
		}
		
		
	}

	
	//****************************************** TKLI���� ***********************************************************************//
	// ���� ��涵��  
	//***************************************************************************************************************************//
	this.gotolink = function(link){
	    //alert("gotolink: " + link);
	    this.workframe.style.visibility  = "visible";
	    this.workframe.src = link;
	}
	
	
	//****************************************** TKLI���� ***********************************************************************//
	// �I�s  
	//***************************************************************************************************************************//
	this.setupFirstLeval();
	
}











