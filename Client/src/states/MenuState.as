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
		private var chatLog:Label;
		private var chatBox:Input;
		private var namesCount:int;
		private var names:Dictionary;
		
		public function MenuState():void
		{
		}

		override public function create():void
		{
			GameInfo.client.multiplayer.joinRoom("WotMLobby", GameInfo.username, registerSelf, joinError);
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
			chatBox.x = chatLabel.right + 5;
			chatBox.y = FlxG.height - 25;
			chatBox.height = 20;
			chatBox.width = FlxG.width - 110;
			addChild(chatBox);
			chatLog = new Label("");
			chatLog.backgroundColor = 0;
			chatLog.textColor = 0xffffffff;
			chatLog.borderColor = 0xffffffff;
			chatLog.x = chatLabel.x;
			chatLog.y = 5;
			chatLog.width = userList.x - chatLog.x - 5;
			chatLog.height = userList.height;
			addChild(chatLog);
		}
		
		override public function update():void
		{
			if ( FlxG.keys.pressed("ENTER") )
			{
				// send chat message
				//FlxG.fade.start(0xee000000, .5, onFade);
			}
			super.update();
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
			if (names[id.toString()] == undefined) namesCount++;
			names[id.toString()] = name;
		}
		
		private function wizardText(m:Message, id:int, message:String):void
		{
			//todo: add message to message log;
		}
		
		private function wizardLeft(m:Message, id:int):void
		{
			// remove the wizard from the list
			if (names[id.toString()] == undefined) return;
			delete names[id.toString()];
			namesCount--;
			//todo: rebuild userlist text
		}
		
		private function wizardList(m:Message):void
		{
			var count:int = m.getInt(0);
			for (var i:int = 0; i < count; ++i)
			{
				var go:GameObject = new GameObject();
				go.id = m.getInt(i * 2 + 1);
				go.name = m.getString(i * 2 + 2);
				names.push(go);
			}
		}
		
		private function joinError(error:PlayerIOError):void
		{
			//todo: error stuffs
			logout();
		}
		
		private function logout():void
		{
			FlxG.state = new AuthentiState();
		}
		
	}
	
}
