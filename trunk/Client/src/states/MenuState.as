package states
{
	import flash.utils.Dictionary;
	import game.GameObject;
	import org.flixel.*;
	import playerio.*;
	import states.PlayState;
	import ui.Input;
	import ui.Label;
	import game.GameInfo;

	/**
	 * ...
	 * @author GDSkeptic
	 */
	public class MenuState extends FlxState
	{
		private var playGame:Boolean;
		private var btnJoinGame:FlxButton;
		private var btnLogOut:FlxButton;
		private var chatLabel:FlxText;
		private var userList:Label;
		private var chatLog:Array;
		private var chatLogText:Label;
		private var chatBox:Input;
		private var namesCount:int;
		private var names:Dictionary;
		
		public function MenuState():void
		{
		}

		override public function create():void
		{
			//GameInfo.client.multiplayer.developmentServer = "localhost:8184";
			GameInfo.client.multiplayer.createJoinRoom("public", "WotMLobby", false, null, null, registerSelf, joinError);
			names = new Dictionary();
			namesCount = 0;
			userList = new Label("");
			userList.backgroundColor = 0;
			userList.textColor = 0xffffffff;
			userList.borderColor = 0xffffffff;
			userList.x = FlxG.width - 130;
			userList.y = 5;
			userList.width = 125;
			userList.height = FlxG.height - 30;
			addChild(userList);
			chatLabel = new FlxText(200, FlxG.height - 22, 50, "Chat:");
			chatLabel.setFormat(null, 10);
			add(chatLabel);
			chatBox = new Input("");
			chatBox.backgroundColor = 0;
			chatBox.textColor = 0xffffffff;
			chatBox.borderColor = 0xffffffff;
			chatBox.x = chatLabel.right;
			chatBox.y = FlxG.height - 25;
			chatBox.height = 20;
			chatBox.width = FlxG.width - 110 - 200;
			addChild(chatBox);
			chatLog = new Array();
			chatLogText = new Label("");
			chatLogText.backgroundColor = 0;
			chatLogText.textColor = 0xffffffff;
			chatLogText.borderColor = 0xffffffff;
			chatLogText.x = chatLabel.x;
			chatLogText.y = 5;
			chatLogText.width = userList.x - chatLogText.x - 5;
			chatLogText.height = userList.height;
			addChild(chatLogText);
		}
		
		override public function update():void
		{
			if ( FlxG.keys.pressed("ENTER") )
			{
				// send chat message
				if (chatBox.text != "")
				{
					GameInfo.connection.send("WizardText", chatBox.text);
					chatBox.text = "";
					chatBox.width = FlxG.width - 110 - 200;
				}
				//FlxG.fade.start(0xee000000, .5, onFade);
			}
			super.update();
		}
		
		private function buildWizardList():void
		{
			userList.text = "";
			var i:int = 0;
			for (var id:String in names)
			{
				i++;
				if (i > namesCount) break;
				userList.text = userList.text + names[id] + "\n";
			}
			//userList.text += "---\n";
			userList.width = 125;
			userList.height = FlxG.height - 30;
		}
		
		private function onFade():void
		{
			FlxG.state = new PlayState();
		}
		
		private function registerSelf(connection:Connection):void
		{
			GameInfo.connection = connection;
			// todo: add message handlers
			connection.addMessageHandler("WizardJoined", wizardJoined);
			connection.addMessageHandler("WizardText", wizardText);
			connection.addMessageHandler("WizardLeft", wizardLeft);
			connection.addMessageHandler("WizardList", wizardList);
			
			// todo: register this wizard
			connection.send("WizardJoined", GameInfo.username);
		}
		
		private function wizardJoined(m:Message, id:int, name:String):void
		{
			if (names[id] == undefined)
			{
				namesCount++;
			}
			names[id] = name;
			
			buildWizardList();
		}
		
		private function wizardText(m:Message, id:int, message:String):void
		{
			//todo: add message to message log;
			chatLog.push(names[id] + ": " + message);
			if (chatLog.length > 29) chatLog.shift();
			chatLogText.text = "";
			for (var i:int = 0; i < chatLog.length; ++i )
				chatLogText.text += chatLog[i] + "\n";
			//chatLogText.text += "---\n";
			chatLogText.width = FlxG.width - 335;
			chatLogText.height = FlxG.height - 30;
		}
		
		private function wizardLeft(m:Message, id:int):void
		{
			// remove the wizard from the list
			if (names[id] == undefined) return;
			delete names[id];
			namesCount--;
			//todo: rebuild userlist text
			buildWizardList();
		}
		
		private function wizardList(m:Message):void
		{
			var count:int = m.getInt(0);
			for (var i:int = 0; i < count; ++i)
			{
				var id:int = m.getInt(i * 2 + 1);
				if (names[id] == undefined) namesCount++;
				names[id] = m.getString(i * 2 + 2);
			}
			buildWizardList();
		}
		
		private function joinError(error:PlayerIOError):void
		{
			//todo: error stuffs
			trace(error.name + error.message);
			//GameInfo.connection.disconnect();
			logout();
		}
		
		private function logout():void
		{
			FlxG.state = new AuthentiState();
		}
		
	}
	
}
