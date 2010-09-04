
/*
-----------------------------------------------------------------------------
	CYU Window Menu beta
-----------------------------------------------------------------------------
	Copyright (c) 2006 tkli

	This script can be used freely as long as all copyright messages are intact.
-----------------------------------------------------------------------------
*/

//�r�� �B�z
String.prototype.trim=trim;  //�Ǧ^�h���e��ťժ���

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
		if (this.lastChild == null) this.lastChild = node;     //�H�U��@ cyclic linked list
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
		if (this.getNode(nodeId) != null) return false;  // node �w�s�b

		var parentNode = this.getNode(parentId);
		if (parentNode == null) return false;       //���`�I���s�b
		
		var newNode = new JsNode(nodeId, data);
		parentNode.addChild(newNode);
		return true;
	}
	
	this.getNode = function(nodeId){
		//use DFS
		//1. ���� �l�`�I�ɡA���ʨ� �Ĥ@�� �l�`�I�A
		//2. �L �l�`�I�ɡA�B ���O ���l�ɡA���ʨ� �U�� �S�̸`�I�A
		//3. ���ŦX�W�z����ɡA
		//	�M�� �̪�@�� �����`�I �B �����O ���l�A���ʨ� ���`�I �� �U�� �S�̸`�I�A
		//	�Y�䤣��A�Ǧ^ null
		currentNode = this.root;
		while (	currentNode != null){
			if (nodeId == currentNode.id) return currentNode;
			
			//���� �`�I
			if (currentNode.lastChild != null){
				currentNode = currentNode.lastChild.next;	//���ʨ� �Ĥ@�Ӥl�`�I
			}		
			else {
				if (currentNode == this.root) return null;
				while (currentNode == currentNode.parent.lastChild ){
					
					currentNode = currentNode.parent;	
					if (currentNode == this.root) return null; //���ɪ� �䤣�� �A�������`�I
				}
				
				currentNode = currentNode.next;		//���ʨ� �U�� �S�̸`�I
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
   //�غc�l ����	
   //***************************************************************************	
	//var functions = functionList.split("\n");
	var functions = functionList;   // 20081104 tkli �׭q
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
		    alert("���~���𪬵��c�I");
		    return;
		}
		
		count++;
		
	}
	
	//alert("There are " + count + " items.");
   //***************************************************************************	
	
	
	
}





