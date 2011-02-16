package states
{
	import flash.events.Event;
	import flash.ui.Mouse;
	import flash.utils.Dictionary;
	import game.GameObject;
	import org.aswing.VectorListModel;
	import org.flixel.*;
	import playerio.*;
	import states.PlayState;
	import game.GameInfo;
	import ui.ChatPanel;
	import ui.ErrorPanel;

	/**
	 * ...
	 * @author GDSkeptic
	 */
	public class MenuState extends FlxState
	{
		private var playGame:Boolean;
		private var namesCount:int;
		private var names:Dictionary;
		private var chat:ChatPanel;
		private var errorBox:ErrorPanel;
		private var gameList:VectorListModel;
		
		public function MenuState():void
		{
		}

		override public function create():void
		{
			//GameInfo.client.multiplayer.developmentServer = "localhost:8184";
			GameInfo.client.multiplayer.createJoinRoom("public", "WotMLobby", false, null, null, registerSelf, joinError);
			names = new Dictionary();
			namesCount = 0;
			chat = new ChatPanel();
			chat.getBtnLogOut().addActionListener(logout);
			chat.getBtnJoinGame().addActionListener(joinGame);
			chat.getBtnCreateGame().addActionListener(createGame);
			addChild(chat);
			Mouse.show();
			GameInfo.client.multiplayer.listRooms("WotMMatch", null, 100, 0, updateGameList, otherError);
			gameList = new VectorListModel();
			gameList.addListDataListener(chat.getGameList());
		}
		
		override public function update():void
		{
			if ( FlxG.keys.pressed("ENTER") )
			{
				// send chat message
				if (chat.getChatBox().getText() != "")
				{
					GameInfo.connection.send("WizardText", chat.getChatBox().getText());
					chat.getChatBox().setText("");
				}
				
				//FlxG.fade.start(0xee000000, .5, onFade);
			}
			super.update();
		}
		
		private function buildWizardList():void
		{
			
			chat.getUserList().setText("");
			//var i:int = 0;
			for (var id:String in names)
			{
				//i++;
				//if (i > namesCount) break;
				chat.getUserList().appendText(names[id] + "\n");
			}
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
			chat.getChatLog().appendText(names[id] + ": " + message + "\n");
			chat.getChatLog().scrollToBottomLeft();
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
			errorBox = new ErrorPanel(this, error.name, error.message);
			logout(new Event(""));
		}
		
		private function otherError(error:PlayerIOError):void
		{
			errorBox = new ErrorPanel(this, error.name, error.message);
		}
		
		private function logout(e:Event):void
		{
			FlxG.state = new AuthentiState();
		}
		
		private function joinGame(e:Event):void
		{
			//TODO: join a game
		}
		
		private function createGame(e:Event):void
		{
			//TODO: create a game
			//GameInfo.client.multiplayer.createRoom
		}
		
		private function updateGameList(rooms:Array):void
		{
			// TODO: update game list
			gameList.clear();
			for (var i:int = 0; i < rooms.length; ++i )
			{
				var ri:RoomInfo = rooms[i];
				// skip full rooms
				if (ri.onlineUsers >= ri.data["maxplayers"])
					continue;
				gameList.append(ri);
			}
		}
		
	}
	
}
