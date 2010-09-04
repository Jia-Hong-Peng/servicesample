
/*
-----------------------------------------------------------------------------
	CYU Window Menu beta
-----------------------------------------------------------------------------
	Copyright (c) 2006 tkli

	This script can be used freely as long as all copyright messages are intact.
-----------------------------------------------------------------------------
*/

//字串 處理
String.prototype.trim=trim;  //傳回去除前後空白的值

function trim() {
  return this.replace(/^\s+|\s+$/g, "");
} 


function JsData(title, link){
	this.title = title;
	this.link = link;	
}


function JsNode(nodeId, data ){   //nodeId:int; data: data object
	
	this.id = nodeId;
	this.data = data;
	this.next = null;
	this.parent = null;
	this.lastChild = null;
	
	this.currentChild = this.lastChild;
	
	this.addChild = function(node){
		node.parent = this;		
		if (this.lastChild == null) this.lastChild = node;     //以下實作 cyclic linked list
		node.next = this.lastChild.next;
		this.lastChild.next = node;
		this.lastChild = node;
		
	}
	
	this.getFirst = function(){
		if (this.lastChild != null) return this.lastChild.next;	
	}
	
	this.moveToBeforeFirst = function(){
		if (this.lastChild != null) this.currentChild = this.lastChild;				
	}
	
	this.nextChild = function(){
		if (this.currentChild.next != this.lastChild) {
			this.currentChild = this.currentChild.next;
			return this.currentChild;	
		}
		else {
			return null;	
		}
	}
	
	this.getData = function(){
		return this.data;	
	}
	
}


function JsTree(functionList){
	
	this.root = null;
	
	this.setRoot = function(nodeId, data){
		this.root = new JsNode(nodeId, data);	
	}
	
	this.addNode = function(nodeId, parentId, data){
		if (this.getNode(nodeId) != null) return false;  // node 已存在

		var parentNode = this.getNode(parentId);
		if (parentNode == null) return false;       //父節點不存在
		
		var newNode = new JsNode(nodeId, data);
		parentNode.addChild(newNode);
		return true;
	}
	
	this.getNode = function(nodeId){
		//use DFS
		//1. 往有 子節點時，移動到 第一個 子節點，
		//2. 無 子節點時，且 不是 幼子時，移動到 下個 兄弟節點，
		//3. 不符合上述條件時，
		//	尋找 最近一個 祖先節點 且 它不是 幼子，移動到 父節點 的 下個 兄弟節點，
		//	若找不到，傳回 null
		currentNode = this.root;
		while (	currentNode != null){
			if (nodeId == currentNode.id) return currentNode;
			
			//移動 節點
			if (currentNode.lastChild != null){
				currentNode = currentNode.lastChild.next;	//移動到 第一個子節點
			}		
			else {
				if (currentNode == this.root) return null;
				while (currentNode == currentNode.parent.lastChild ){
					
					currentNode = currentNode.parent;	
					if (currentNode == this.root) return null; //此時表 找不到 適當的祖先節點
				}
				
				currentNode = currentNode.next;		//移動到 下個 兄弟節點
			}
			
		} //end of while
	}//end of getNode

/*	
	this.BFScurrent = this.root;
	this.DFScurrent = this.root;

	this.setBFSStart = function(){
		this.BFScurrent = this.root;	
	}
	
	this.getBFSNext = function(){
		
		
	}
	
	this.setDFSStart = function(){
		this.DFScurrent = this.root;	
	}

	this.getDFSNext = function(){
		
		
	}
*/

   //***************************************************************************	
   //建構子 部份	
   //***************************************************************************	
	//var functions = functionList.split("\n");
	var functions = functionList;   // 20081104 tkli 修訂
	var data = new JsData("root", "root")
	this.setRoot("0", data);
	var count =0;
	for (i = 0 ;i <functions.length; i++){
		
		//alert(functions[i]);
		
		if (functions[i].trim() == "") continue;

		var content = functions[i].split(",");
		content[0] = content[0].trim();
		content[1] = content[1].trim();
		content[2] = content[2].trim();
		content[3] = content[3].trim();
		//alert(content[3]);
		data = new JsData(content[2], content[3]);
		
		var b = this.addNode(content[0], content[1], data);
		//alert(functions[i] + "==>" + b);
		if (!b){
		    alert("錯誤的樹狀結構！");
		    return;
		}
		
		count++;
		
	}
	
	//alert("There are " + count + " items.");
   //***************************************************************************	
	
	
	
}





